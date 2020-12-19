using System;
using Azure.Storage.Queues;
using InstaShop.ConstsVariables;
using InstaShop.Helpers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace InstaShop.Sender.Postagens
{
    public class PostagensSender
    {
        private QueueClient client { get; }

        public PostagensSender()
        {
            string connectionString = Environment.GetEnvironmentVariable("instarobo_STORAGE");
            this.client = new QueueClient(connectionString, QueuesVars.FILA_POSTAGENS);
            this.client.CreateIfNotExists();
        }

        public void PostMessage(string payload)
        {
            if (this.client.Exists())
            {
                var base64Value = Base64Helper.Encode(payload);
                this.client.SendMessage(base64Value);
            }
        }
    }
}
