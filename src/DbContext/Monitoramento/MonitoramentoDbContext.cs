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
using System.Security.Authentication;
using InstaShop.DbContext.Lojas.Domain;
using InstaShop.DbContext.Base;

namespace InstaShop.DbContext.Monitoramento
{
    public class MonitoramentoDbContext
    {
        private BaseTransientDbContext lojaDbContext { get; }

        public MonitoramentoDbContext()
        {
            this.lojaDbContext = new BaseTransientDbContext();
        }
        public IEnumerable<string> ObterLojasMonitoramento()
        {
            var query = @" select ds_username  FROM TB_MONITORAMENTO_LOJAS ";
            return this.lojaDbContext.ObterListagem<string>(query);
        }
    }
}
