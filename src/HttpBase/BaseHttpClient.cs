using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;
using InstaShop.HastTags.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace InstaShop.HastTags
{
    public class BaseHttpClient<T>
    {
        public BaseResultModel<T> CallPage(string url)
        {
            var startDate = DateTime.Now;
            var client = new RestClient(url);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Parameters.Clear();
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new BaseResultModel<T>((int)response.StatusCode, response.Content);
            }

            var content = response.Content;

            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var dados = doc.DocumentNode.Descendants("script");

            if (dados == null || !dados.Any())
            {
                var msgErroGeral = "Please wait a few minutes before you try again";
                if (content.Contains(msgErroGeral, StringComparison.InvariantCultureIgnoreCase))
                {
                    return new BaseResultModel<T>((int)HttpStatusCode.TooManyRequests, content);
                }

                return new BaseResultModel<T>((int)HttpStatusCode.UnprocessableEntity, content);
            }

            var scriptQueQuero = dados.Where(x => x.OuterHtml.Contains("window._sharedData =", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            var resultContent = "";

            var posicaoInicio = scriptQueQuero.OuterHtml.IndexOf("{");

            var split1 = scriptQueQuero.OuterHtml.Substring(posicaoInicio);
            var split2 = split1.Substring(0, split1.LastIndexOf("}") + 1);

            resultContent = split2;

            BaseResultModel<T> resultado = null;

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                resultado = new BaseResultModel<T>(JsonConvert.DeserializeObject<T>(resultContent));
                resultado.Cookies = new Dictionary<string, string>();

                foreach (var item in response.Cookies)
                    if (!string.IsNullOrEmpty(item.Value))
                        resultado.Cookies.Add(item.Name, item.Value);

                resultado.StringResult = content;
                return resultado;
            }
            else
            {
                resultado = new BaseResultModel<T>((int)response.StatusCode, content);
                return resultado;
            }
        }

        public BaseResultModel<T> CallPageWithCookies(string url, string scriptPrefix, Dictionary<string, string> Cookies)
        {
            var startDate = DateTime.Now;
            var client = new RestClient(url);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Parameters.Clear();
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");

            if (Cookies != null && Cookies.Any())
            {
                foreach (var cook in Cookies)
                    if (!string.IsNullOrEmpty(cook.Value))
                        request.AddCookie(cook.Key, cook.Value);
            }

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new BaseResultModel<T>((int)response.StatusCode, response.Content);
            }

            var content = response.Content;

            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var dados = doc.DocumentNode.Descendants("script");

            if (dados == null || !dados.Any())
            {
                var msgErroGeral = "Please wait a few minutes before you try again";
                if (content.Contains(msgErroGeral, StringComparison.InvariantCultureIgnoreCase))
                {
                    return new BaseResultModel<T>((int)HttpStatusCode.TooManyRequests, content);
                }

                return new BaseResultModel<T>((int)HttpStatusCode.UnprocessableEntity, content);
            }

            var scriptQueQuero = dados.Where(x => x.OuterHtml.Contains(scriptPrefix, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            var resultContent = "";

            var posicaoInicio = scriptQueQuero.OuterHtml.IndexOf("{");

            var split1 = scriptQueQuero.OuterHtml.Substring(posicaoInicio);
            var split2 = split1.Substring(0, split1.LastIndexOf("}") + 1);

            resultContent = split2;

            BaseResultModel<T> resultado = null;

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                resultado = new BaseResultModel<T>(JsonConvert.DeserializeObject<T>(resultContent));
                resultado.Cookies = new Dictionary<string, string>();

                foreach (var item in response.Cookies)
                {
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        if (resultado.Cookies.ContainsKey(item.Name))
                            resultado.Cookies.Remove(item.Name);

                        resultado.Cookies.Add(item.Name, item.Value);
                    }
                }

                return resultado;
            }
            else
            {
                resultado = new BaseResultModel<T>((int)response.StatusCode, content);
                return resultado;
            }
        }

        public string CallPageStringWithCookies(string url, Dictionary<string, string> Cookies)
        {
            var startDate = DateTime.Now;
            var client = new RestClient(url);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Parameters.Clear();
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");

            if (Cookies != null && Cookies.Any())
            {
                foreach (var cook in Cookies)
                    if (!string.IsNullOrEmpty(cook.Value))
                        request.AddCookie(cook.Key, cook.Value);
            }

            var response = client.Execute(request);

            var content = response.Content;

            return content;
        }

        public BaseResultModel<T> CallApi(string url)
        {
            var startDate = DateTime.Now;
            var client = new RestClient(url);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Parameters.Clear();

            var response = client.Execute(request);

            Console.WriteLine($"Resultado url: {url} StatusCode: {response.StatusCode}");

            var content = response.Content;

            if (response.StatusCode.Equals(HttpStatusCode.OK))
                return new BaseResultModel<T>(JsonConvert.DeserializeObject<T>(content));
            else
                return new BaseResultModel<T>((int)response.StatusCode, content);
        }
    }
}
