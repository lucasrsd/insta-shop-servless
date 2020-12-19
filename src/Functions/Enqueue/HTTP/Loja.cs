using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using InstaShop.DbContext.Lojas;
using InstaShop.Sender.Perfil;

namespace InstaShop.Functions.Enqueue.HTTP
{
    public static class Loja
    {
        [FunctionName("EnfileirarLoja")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "enqueue/loja/{username}")] HttpRequest req,
            string username, ILogger log)
        {
            try
            {
                log.LogInformation("Iniciando requisicao enfileirar dados loja.");

                if (string.IsNullOrEmpty(username)) return new BadRequestObjectResult("Usuario nao informado");
 
                var sender = new PerfilSender();
                sender.PostMessage(username);

                return new OkResult();
            }
            catch (Exception ex)
            {
                return new UnprocessableEntityObjectResult(ex.ToString());
            }
        }
    }
}