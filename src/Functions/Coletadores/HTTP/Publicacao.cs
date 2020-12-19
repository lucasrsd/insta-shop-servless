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
using InstaShop.Features.Login.Services;
using InstaShop.Sender.Perfil;
using InstaShop.DbContext.Erros;
using InstaShop.Features.Login.Models;

namespace InstaShop.Functions.Coletadores.HTTP
{
    public static class Publicacao
    {
        [FunctionName("Publicacao")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "coletador/publicacao/{shortcode}")] HttpRequest req,
            string shortcode,
            ILogger log)
        {
            LoginResult resultLogin = null;
            try
            {
                log.LogInformation("Iniciando requisicao Publicacao");

                if (string.IsNullOrEmpty(shortcode)) return new BadRequestObjectResult("Post nao informado");

                var loginService = new LoginService();
                resultLogin = loginService.Logar(log);

                if (!resultLogin.Sucesso) return new UnprocessableEntityObjectResult($"Falha ao logar, {resultLogin.Erro}");

                var clientPublicacao = new BaseHttpClient<HastTags.Models.PostClass.Root>();

                var resultPublicacao = clientPublicacao.CallPageWithCookies($"https://www.instagram.com/p/{shortcode}", "window.__additionalDataLoaded(", resultLogin.Cookies);

                if (!resultPublicacao.Sucess)
                {
                    if (resultPublicacao.HttpStatus == (int)HttpStatusCode.TooManyRequests)
                    {
                        loginService.InativarPorTooManyRequests(resultLogin.UsuarioLogado);
                    }
                    return new BadRequestObjectResult($"Erro ao obter perfil: Status:{resultPublicacao.HttpStatus} - Conteudo: {resultPublicacao.StringResult} ");
                }

                var usuario = resultPublicacao.Data.graphql.shortcode_media.owner.username;

                var sender = new PerfilSender();
                sender.PostMessage(usuario);

                var result = new
                {
                    Status = "OK",
                    Login = resultLogin,
                    Machine = Environment.MachineName,
                    Time = DateTime.Now
                };

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                var errorCOntext = new ErrosDbContext();
                errorCOntext.InserirLogErro("Publicacao", shortcode, Environment.MachineName, ex.ToString());

                var result = new
                {
                    Error = ex.ToString(),
                    Login = resultLogin,
                    Machine = Environment.MachineName,
                    Time = DateTime.Now
                };
                return new BadRequestObjectResult(result);
            }
        }

        public static string EscreverCookies(Dictionary<string, string> cookies)
        {
            var result = "";
            cookies.ToList().ForEach(x => result += $"Chave{x.Key} Valor{x.Value} --- ");
            return result;
        }
    }
}
