using System;
using System.Net;
using InstaShop.ConstsVariables;
using InstaShop.DbContext.Erros;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace InstaShop.Functions.Coletadores.Queues
{
    public static class PerfisQueue
    {
        [Singleton(Mode = SingletonMode.Function)]
        [FunctionName("PerfisQueue")]
        public static void Run([QueueTrigger(QueuesVars.FILA_PERFIS, Connection = "instarobo_STORAGE")] string profileName, ILogger log)
        {
            var errosDbContext = new ErrosDbContext();
            try
            {
                log.LogInformation($"Executando PerfisQueue em {DateTime.Now} - Payoad: {profileName}");
                new WebClient().DownloadString($"https://{InstaShop.ConstsVariables.Host.PATH_BASE}/api/coletador/usuario/{profileName}");
            }
            catch (Exception ex)
            {
                errosDbContext.InserirLogErro("PerfisQueue", profileName, Environment.MachineName, ex.ToString());
                log.LogError(ex.ToString());
            }
        }
    }
}
