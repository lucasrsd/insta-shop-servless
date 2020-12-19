using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using InstaShop.HastTags;
using System.Net;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using InstaShop.HastTags.Models;
using InstaShop.Features.Login.Models;
using InstaShop.DbContext.Login;
using InstaShop.DbContext.Login.Domain;

namespace InstaShop.Features.Login.Services
{
    public class LoginService
    {
        private LoginDbContext loginDbContext { get; set; }
        public LoginService()
        {
            this.loginDbContext = new LoginDbContext();
        }

        public void InativarPorTooManyRequests(string username)
        {
            this.loginDbContext.AtualizarProximaValidade(username, DateTime.UtcNow.AddMinutes(30));
            this.loginDbContext.ExcluirAutenticacaoMaquina(Environment.MachineName);
        }

        public AutenticacaoResult ObterCredenciais()
        {
            var listaLogins = this.loginDbContext.ObterLoginsDisponiveis().ToList();

            if (listaLogins == null) return null;
            if (!listaLogins.Any()) return null;

            int r = new Random().Next(listaLogins.Count);
            return listaLogins[r];
        }

        private Tuple<string, Dictionary<string, string>> VerificacaoOrigemCookies()
        {
            var resultLogin = this.loginDbContext.ObterLogin(Environment.MachineName);

            if (resultLogin == null) return null; ;

            if (resultLogin.DataLogin.HasValue)
            {
                var diferenca = (DateTime.UtcNow - resultLogin.DataLogin.Value).TotalMinutes;

                if (diferenca > 60)
                {
                    this.loginDbContext.ExcluirAutenticacaoMaquina(Environment.MachineName);
                    return null;
                }
            }
            else
            {
                return null;
            }

            var result = new Dictionary<string, string>();

            resultLogin.Cookies.ForEach(x => result.Add(x.Chave, x.Valor));

            return new Tuple<string, Dictionary<string, string>>(resultLogin.Usuario, result);
        }

        private void IncluirAutenticacaoMaquina(string usuario, Dictionary<string, string> cookies)
        {
            var listaCookies = new List<CookieValue>();
            cookies.ToList().ForEach(x => listaCookies.Add(new CookieValue()
            {
                Chave = x.Key,
                Valor = x.Value
            }));

            var loginDomain = new LoginDomain()
            {
                Cookies = listaCookies,
                Maquina = Environment.MachineName,
                Usuario = usuario,
                DataLogin = DateTime.Now
            };

            this.loginDbContext.IncluirAutenticacao(loginDomain);
        }

        public LoginResult Logar(ILogger log)
        {
            var origemCookies = VerificacaoOrigemCookies();

            if (origemCookies != null)
            {
                log.LogInformation("Efetuando login a partir de cookies salvos.");
                return new LoginResult()
                {
                    Sucesso = true,
                    UsuarioLogado = origemCookies.Item1,
                    Cookies = origemCookies.Item2,
                    TipoLogin = "CACHE"
                };
            }

            var credenciais = ObterCredenciais();

            if (credenciais == null)
                throw new ApplicationException("Nenhuma credencial valida disponivel.");

            log.LogInformation($"Efetuando login com {credenciais.Usuario} - {credenciais.Senha}");

            var clientHastTag = new BaseHttpClient<HastTags.Models.LoginClass.Root>();

            var loginResult = clientHastTag.CallPage(@"https://www.instagram.com/accounts/login/");

            var logPaginaLogin = $"Status: {loginResult.HttpStatus} Objeto: {JsonConvert.SerializeObject(loginResult)}";
            log.LogInformation(logPaginaLogin);
            Console.WriteLine(logPaginaLogin);

            if (!loginResult.Sucess)
            {
                if (loginResult.HttpStatus == (int)HttpStatusCode.TooManyRequests)
                {
                    InativarPorTooManyRequests(credenciais.Usuario);
                }

                throw new Exception($"ERRO AO LOGAR: {loginResult.HttpStatus} - {loginResult.StringResult}");
            }

            var passWordLogin = PasswordService.GenerateEncPassword(credenciais.Senha, loginResult.Data.encryption.public_key, loginResult.Data.encryption.key_id, loginResult.Data.encryption.version);

            var client = new RestClient("https://www.instagram.com/accounts/login/ajax/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", credenciais.Usuario);
            request.AddParameter("enc_password", passWordLogin);
            request.AddParameter("queryParams", " {}");
            request.AddParameter("optIntoOneTap", " false");

            request.AddHeader("x-csrftoken", loginResult.Data.config.csrf_token);

            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");

            foreach (var cook in loginResult.Cookies)
                if (!string.IsNullOrEmpty(cook.Value))
                    request.AddCookie(cook.Key, cook.Value);

            IRestResponse response = client.Execute(request);

            var logLogin = "Response login: " + response.StatusCode;
            log.LogInformation(logPaginaLogin);
            Console.WriteLine(logPaginaLogin);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var instaLoginResult = JsonConvert.DeserializeObject<InstaShop.Features.Login.Models.Root>(response.Content);

                if (instaLoginResult.authenticated)
                {
                    var cookies = BuildCookies(response.Cookies);
                    IncluirAutenticacaoMaquina(credenciais.Usuario, cookies);
                    return new LoginResult()
                    {
                        Sucesso = true,
                        UsuarioLogado = credenciais.Usuario,
                        Cookies = cookies,
                        TipoLogin = "NOVO"
                    };
                }
                else
                {
                    return new LoginResult()
                    {
                        Sucesso = false,
                        Erro = "Falha no login",
                        TipoLogin = "NOVO"
                    };
                }
            }
            else
            {
                try
                {
                    var instaLoginResult = JsonConvert.DeserializeObject<InstaShop.Features.Login.Models.Root>(response.Content);

                    return new LoginResult()
                    {
                        Sucesso = false,
                        Erro = response.StatusCode + " - " + instaLoginResult.status
                    };
                }
                catch (Exception ex)
                {
                    return new LoginResult()
                    {
                        Sucesso = false,
                        Erro = response.StatusCode + " - " + response.Content + " - " + ex.ToString()
                    };
                }
            }
        }

        private Dictionary<string, string> BuildCookies(IList<RestResponseCookie> cookies)
        {
            var cookiesResult = new Dictionary<string, string>();
            foreach (var cookiePost in cookies)
            {
                if (!string.IsNullOrEmpty(cookiePost.Value))
                {
                    if (cookiesResult.ContainsKey(cookiePost.Name))
                        cookiesResult.Remove(cookiePost.Name);

                    cookiesResult.Add(cookiePost.Name, cookiePost.Value);
                }
            }

            return cookiesResult;
        }
    }
}