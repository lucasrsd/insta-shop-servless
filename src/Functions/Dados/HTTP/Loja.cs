using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using InstaShop.DbContext.Lojas;

namespace InstaShop.Functions.Dados.HTTP
{
    public static class Loja
    {
        [FunctionName("Loja")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "dados/loja/{username}")] HttpRequest req,
            string username, ILogger log)
        {
            try
            {
                log.LogInformation("Iniciando requisicao dados loja.");

                if (string.IsNullOrEmpty(username)) return new BadRequestObjectResult("Tag nao informado");

                var dbContext = new LojasDbContext();
                var result = dbContext.Obter(username);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new UnprocessableEntityObjectResult(ex.ToString());
            }
        }
    }
}