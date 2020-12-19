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
using InstaShop.DbContext.Lojas;
using InstaShop.DbContext.Lojas.Domain;
using InstaShop.DbContext.Erros;
using InstaShop.Features.ColetaUsuario.Services;

namespace InstaShop.Functions.Coletadores.HTTP
{
    public static class Usuario
    {
        [FunctionName("Usuario")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "coletador/usuario/{username}")] HttpRequest req,
            string username,
            ILogger log)
        {
            var service = new ColetaLojaService();
            return service.ExecutarLoja(username, log);
        }
    }
}
