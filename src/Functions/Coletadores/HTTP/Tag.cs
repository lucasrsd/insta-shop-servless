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
using InstaShop.Sender.Postagens;
using InstaShop.DbContext.Erros;
using InstaShop.Features.Login.Models;

namespace InstaShop.Functions.Coletadores.HTTP
{
    public static class Tag
    {
        [FunctionName("Tag")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "coletador/tag/{tagname}/{pages:int}")] HttpRequest req,
            string tagName,
            int pages,
            ILogger log)
        {
            LoginResult resultLogin = null;
            try
            {
                log.LogInformation("Iniciando requisicao Tag.");

                if (string.IsNullOrEmpty(tagName)) return new BadRequestObjectResult("Tag nao informado");

                if (pages == 0) return new BadRequestObjectResult("Informe a quantidade de paginas");

                var loginService = new LoginService();
                resultLogin = loginService.Logar(log);

                if (!resultLogin.Sucesso) return new UnprocessableEntityObjectResult($"Falha ao logar, {resultLogin.Erro}");

                var clientTag = new BaseHttpClient<HastTags.Models.InstaHastTagClass.Root>();
                var tagResult = clientTag.CallPageWithCookies($"https://www.instagram.com/explore/tags/{tagName}", "window._sharedData =", resultLogin.Cookies);

                if (!tagResult.Sucess)
                {
                    if (tagResult.HttpStatus == (int)HttpStatusCode.TooManyRequests)
                    {
                        loginService.InativarPorTooManyRequests(resultLogin.UsuarioLogado);
                    }

                    return new BadRequestObjectResult($"Erro na listagem de tags: Status:{tagResult.HttpStatus} - Conteudo: {tagResult.StringResult} ");
                }

                if (tagResult.Data == null) throw new Exception("Dados da pagina nao encontrados (Data)");
                if (tagResult.Data.entry_data == null) throw new Exception("Dados da pagina nao encontrados (Entry Data)");
                if (tagResult.Data.entry_data.TagPage == null) throw new Exception("Dados da pagina nao encontrados (Tag Page)");

                var dataEntryObject = tagResult.Data.entry_data.TagPage.FirstOrDefault();

                if (dataEntryObject == null)
                {
                    throw new Exception("Dados da pagina nao encontrados");
                }

                var objNext = dataEntryObject.graphql.hashtag.edge_hashtag_to_media.page_info;
                var hasNext = objNext.has_next_page;
                var next = objNext.end_cursor;

                var listaResultadoPaginas = new List<HastTags.Models.InstaNextTagClass.Data>();

                var loop = 0;

                while (hasNext && loop++ < pages)
                {
                    System.Threading.Thread.Sleep(500);

                    var loopInstance = new BaseHttpClient<HastTags.Models.InstaNextTagClass.Root>();

                    var url = "https://www.instagram.com/graphql/query/?query_hash=9b498c08113f1e09617a1703c22b2f32&variables={\"tag_name\":\"" + tagName + "\",\"first\":20,\"after\":\"" + next + "\"}";
                    var dataRequest = loopInstance.CallApi(url);

                    listaResultadoPaginas.Add(dataRequest.Data.data);

                    hasNext = dataRequest.Data.data.hashtag.edge_hashtag_to_media.page_info.has_next_page;
                    next = dataRequest.Data.data.hashtag.edge_hashtag_to_media.page_info.end_cursor;
                }

                var listaShortCodes = new List<string>();

                foreach (var item in tagResult.Data.entry_data.TagPage)
                {
                    foreach (var edge in item.graphql.hashtag.edge_hashtag_to_media.edges)
                    {
                        listaShortCodes.Add(edge.node.shortcode);
                    }
                }

                foreach (var item in listaResultadoPaginas)
                {
                    foreach (var edge in item.hashtag.edge_hashtag_to_media.edges)
                    {
                        listaShortCodes.Add(edge.node.shortcode);
                    }
                }

                listaShortCodes.Distinct();

                var postagemSender = new PostagensSender();
                foreach (var item in listaShortCodes)
                {
                    postagemSender.PostMessage(item);
                }

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
                errorCOntext.InserirLogErro("Tags", tagName, Environment.MachineName, ex.ToString());

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
