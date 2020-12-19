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
    public static class Processamentos
    {
        [FunctionName("Processamentos")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "dados/Processamentos")] HttpRequest req,
             ILogger log)
        {
            try
            {
                log.LogInformation("Iniciando requisicao dados processamentos.");

                var dbContext = new LojasDbContext();
                var result = dbContext.ObterProcessamentos();

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new UnprocessableEntityObjectResult(ex.ToString());
            }
        }
    }
}