using System;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace InstaShop.ConstsVariables
{
    public static class Host
    {
        public static string PATH_BASE = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");
    }
}