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
using InstaShop.DbContext.Lojas;
using InstaShop.Features.Login.Services;
using InstaShop.DbContext.Lojas.Domain;
using InstaShop.DbContext.Erros;
using System.Web;
using System.Text;

namespace InstaShop.Features.ColetaUsuario.Services
{
    public class ColetaLojaService
    {
        public bool ProcessarLoja(string username)
        {
            var clientDbContext = new LojasDbContext();
            var lojaExiste = clientDbContext.Obter(username);

            if (lojaExiste != null)
            {
                var diferenca = (DateTime.UtcNow - lojaExiste.UltimaAtualizacao.Value).TotalMinutes;

                if (diferenca < 14)
                {
                    return false;
                }
            }

            return true;
        }

        public ObjectResult ExecutarLoja(string username, ILogger log)
        {
            var startDate = DateTime.Now;
            long idColeta = 0;
            LoginResult resultLogin = null;

            try
            {
                log.LogInformation("Iniciando requisicao usuario.");

                if (string.IsNullOrEmpty(username)) return new BadRequestObjectResult("Usuario nao informado");

                var clientDbContext = new LojasDbContext();

                var devoProcessarLoja = ProcessarLoja(username);

                var lojaExiste = clientDbContext.Obter(username);

                if (!devoProcessarLoja)
                {
                    var cachedResult = new
                    {
                        Status = "CACHED",
                        Login = resultLogin,
                        Machine = Environment.MachineName,
                        Time = DateTime.Now
                    };

                    return new OkObjectResult(cachedResult);
                }
                else
                {
                    if (lojaExiste == null)
                        clientDbContext.IncluirLoja(username, StatusLoja.ATIVA);
                }

                var loginService = new LoginService();
                resultLogin = loginService.Logar(log);

                if (!resultLogin.Sucesso) return new UnprocessableEntityObjectResult($"Falha ao logar, {resultLogin.Erro}");
                if (resultLogin.Cookies == null) return new UnprocessableEntityObjectResult($"Falha ao logar Cookies, {resultLogin.Erro}");
                if (!resultLogin.Cookies.Any()) return new UnprocessableEntityObjectResult($"Falha ao logar Cookies !Any, {resultLogin.Erro}");

                idColeta = clientDbContext.IniciarColeta(username, resultLogin.UsuarioLogado);

                var clientUsuario = new BaseHttpClient<HastTags.Models.PerfilClass.Root>();
                var resultadoUsuario = clientUsuario.CallPageWithCookies($"https://www.instagram.com/{username}", "window._sharedData =", resultLogin.Cookies);

                if (!resultadoUsuario.Sucess)
                {
                    if (resultadoUsuario.HttpStatus == (int)HttpStatusCode.TooManyRequests)
                    {
                        loginService.InativarPorTooManyRequests(resultLogin.UsuarioLogado);
                    }

                    throw new Exception($"Falha ao obter usuario do insta, Status: {resultadoUsuario?.HttpStatus} - Content: {resultadoUsuario.StringResult}");
                }

                if (resultadoUsuario.Data == null) throw new Exception("Dados da pagina nao encontrados (Data)");
                if (resultadoUsuario.Data.entry_data == null) throw new Exception("Dados da pagina nao encontrados (Entry Data)");
                if (resultadoUsuario.Data.entry_data.ProfilePage == null) throw new Exception("Dados da pagina nao encontrados (Profile Page)");

                var dataEntryObject = resultadoUsuario.Data.entry_data.ProfilePage.FirstOrDefault();

                if (dataEntryObject == null)
                {
                    throw new Exception("Dados da pagina nao encontrados");
                }

                var objNext = dataEntryObject.graphql.user.edge_owner_to_timeline_media.page_info;
                var hasNext = objNext.has_next_page;

                var profile = dataEntryObject.graphql.user.id;

                var next = objNext.end_cursor;

                var dadosUsuario = dataEntryObject.graphql.user;

                var listaResultadoPaginas = new List<HastTags.Models.InstaNextPageClass.Data>();

                var counter = 0;

                while (hasNext && counter++ <= 5)
                {
                    System.Threading.Thread.Sleep(50);

                    var loopInstance = new BaseHttpClient<HastTags.Models.InstaNextPageClass.Root>();

                    var url = "https://www.instagram.com/graphql/query/?query_hash=bfa387b2992c3a52dcbe447467b4b771&variables={\"id\":\"" + profile + "\",\"first\":50,\"after\":\"" + next + "\"}";
                    var dataRequest = loopInstance.CallApi(url);

                    listaResultadoPaginas.Add(dataRequest.Data.data);

                    hasNext = dataRequest.Data.data.user.edge_owner_to_timeline_media.page_info.has_next_page;
                    next = dataRequest.Data.data.user.edge_owner_to_timeline_media.page_info.end_cursor;
                }

                var dadosLojaColetados = new DadosColetados()
                {
                    MaquinaColetada = Environment.MachineName,
                    Biografia = dadosUsuario.biography,
                    DataCriacao = DateTime.Now,
                    NomeDescricao = dadosUsuario.full_name,
                    Seguindo = dadosUsuario.edge_follow.count,
                    Seguidores = dadosUsuario.edge_followed_by.count,
                    QuantidadePublicacoes = dadosUsuario.edge_owner_to_timeline_media.count,
                    Link = dadosUsuario.external_url,
                    UsuarioColeta = resultLogin.UsuarioLogado,
                    Publicacoes = new List<Publicacoes>(),
                    Imagens = new List<ImagensPublicacoes>()
                };

                foreach (var edge in dadosUsuario.edge_owner_to_timeline_media.edges)
                {
                    if (dadosLojaColetados.Publicacoes.Where(x => x.ShortCode.Equals(edge.node.shortcode, StringComparison.InvariantCultureIgnoreCase)).Count() > 1)
                        continue;

                    var publicacao = new Publicacoes()
                    {
                        TipoConteudo = edge.node.__typename,
                        Comentarios = edge.node.edge_media_to_comment.count,
                        Curtidas = edge.node.edge_liked_by.count,
                        Descricao = edge.node.edge_media_to_caption.edges.FirstOrDefault()?.node?.text,
                        ShortCode = edge.node.shortcode,
                        HorarioPublicacao = DateTimeOffset.FromUnixTimeSeconds(edge.node.taken_at_timestamp).DateTime
                    };

                    var listaImg = new List<ImagensPublicacoes>();

                    if (publicacao.TipoConteudo.Equals("GraphSidecar", StringComparison.InvariantCulture))
                    {
                        if (edge.node.edge_sidecar_to_children != null)
                        {
                            foreach (var item in edge.node.edge_sidecar_to_children.edges)
                            {
                                listaImg.Add(new ImagensPublicacoes()
                                {
                                    Src = item.node.display_url,
                                    Height = item.node.dimensions.height,
                                    Width = item.node.dimensions.width,
                                    ShortCode = edge.node.shortcode
                                });
                            }
                        }
                        else
                        {
                            foreach (var item in edge.node.thumbnail_resources)
                            {
                                listaImg.Add(new ImagensPublicacoes()
                                {
                                    Src = item.src,
                                    Height = item.config_height,
                                    Width = item.config_width,
                                    ShortCode = edge.node.shortcode
                                });
                            }
                        }
                    }
                    else if (publicacao.TipoConteudo.Equals("GraphImage", StringComparison.InvariantCulture))
                    {
                        var maiorImagem = edge.node.thumbnail_resources.OrderByDescending(x => x.config_width).FirstOrDefault();
                        listaImg.Add(new ImagensPublicacoes()
                        {
                            Src = maiorImagem.src,
                            Height = maiorImagem.config_height,
                            Width = maiorImagem.config_width,
                            ShortCode = edge.node.shortcode
                        });
                    }

                    dadosLojaColetados.Imagens.AddRange(listaImg);

                    dadosLojaColetados.Publicacoes.Add(publicacao);
                }

                foreach (var results in listaResultadoPaginas)
                {
                    var edges = results.user.edge_owner_to_timeline_media.edges;

                    foreach (var edge in edges)
                    {
                        if (dadosLojaColetados.Publicacoes.Where(x => x.ShortCode.Equals(edge.node.shortcode, StringComparison.InvariantCultureIgnoreCase)).Count() > 1)
                            continue;

                        var publicacao = new Publicacoes()
                        {
                            TipoConteudo = edge.node.__typename,
                            Comentarios = edge.node.edge_media_to_comment.count,
                            Curtidas = edge.node.edge_media_preview_like.count,
                            Descricao = edge.node.edge_media_to_caption.edges.FirstOrDefault()?.node?.text,
                            ShortCode = edge.node.shortcode,
                            HorarioPublicacao = DateTimeOffset.FromUnixTimeSeconds(edge.node.taken_at_timestamp).DateTime
                        };

                        var listaImg = new List<ImagensPublicacoes>();

                        if (publicacao.TipoConteudo.Equals("GraphSidecar", StringComparison.InvariantCulture))
                        {
                            if (edge.node.edge_sidecar_to_children != null)
                            {
                                foreach (var item in edge.node.edge_sidecar_to_children.edges)
                                {
                                    listaImg.Add(new ImagensPublicacoes()
                                    {
                                        Src = item.node.display_url,
                                        Height = item.node.dimensions.height,
                                        Width = item.node.dimensions.width,
                                        ShortCode = edge.node.shortcode
                                    });
                                }
                            }
                            else
                            {
                                foreach (var item in edge.node.thumbnail_resources)
                                {
                                    listaImg.Add(new ImagensPublicacoes()
                                    {
                                        Src = item.src,
                                        Height = item.config_height,
                                        Width = item.config_width,
                                        ShortCode = edge.node.shortcode
                                    });
                                }
                            }
                        }
                        else if (publicacao.TipoConteudo.Equals("GraphImage", StringComparison.InvariantCulture))
                        {
                            var maiorImagem = edge.node.thumbnail_resources.OrderByDescending(x => x.config_width).FirstOrDefault();
                            listaImg.Add(new ImagensPublicacoes()
                            {
                                Src = maiorImagem.src,
                                Height = maiorImagem.config_height,
                                Width = maiorImagem.config_width,
                                ShortCode = edge.node.shortcode
                            });
                        }

                        dadosLojaColetados.Imagens.AddRange(listaImg);

                        dadosLojaColetados.Publicacoes.Add(publicacao);
                    }
                }

                dadosLojaColetados.DataInicioProcessamento = startDate;
                dadosLojaColetados.DataFimProcessamento = DateTime.Now;
                dadosLojaColetados.StatusColeta = StatusColeta.PROCESSADO;

                clientDbContext.IncluirDados(username, idColeta, dadosLojaColetados);
                clientDbContext.AtualizarUmaAlteracaoLoja(username);
                clientDbContext.AtualizarStatusColeta(idColeta, StatusColeta.PROCESSADO);

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
                var clientDbContext = new LojasDbContext();
                clientDbContext.AtualizarStatusColeta(idColeta, StatusColeta.ERRO);

                var errorCOntext = new ErrosDbContext();
                errorCOntext.InserirLogErro("Usuario", username, Environment.MachineName, $" (Usuario: {resultLogin?.UsuarioLogado} - TipoLogin: {resultLogin?.TipoLogin} - EX: {ex.ToString()}");

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
