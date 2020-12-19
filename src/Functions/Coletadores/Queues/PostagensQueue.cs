using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using InstaShop.ConstsVariables;
using InstaShop.DbContext.Erros;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace InstaShop.Functions.Coletadores.Queues
{
    public static class PostagensQueue
    {
        [Singleton(Mode = SingletonMode.Function)]
        [FunctionName("PostagensQueue")]
        public static void Run([QueueTrigger(QueuesVars.FILA_POSTAGENS, Connection = "instarobo_STORAGE")] string shortCode, ILogger log)
        {
            var posts = new List<string>();

            if (shortCode.Contains(","))
                posts = shortCode.Split(",").ToList();
            else
                posts.Add(shortCode);

            var errosDbContext = new ErrosDbContext();

            foreach (var post in posts)
            {
                try
                {
                    log.LogInformation($"Executando PostagensQueue em {DateTime.Now} - Payload: {post}");
                    new WebClient().DownloadString($"https://{InstaShop.ConstsVariables.Host.PATH_BASE}/api/coletador/publicacao/{post}");
                }
                catch (Exception ex)
                {
                    errosDbContext.InserirLogErro("PostagensQueue", post, Environment.MachineName, ex.ToString());
                    log.LogError($"POST: {post} ERRO: {ex.ToString()}");
                }
            }
        }
    }
}
