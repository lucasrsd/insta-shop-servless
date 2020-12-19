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

namespace InstaShop.DbContext.Erros
{
    public class ErrosDbContext
    {
        private BaseTransientDbContext lojaDbContext { get; }

        public ErrosDbContext()
        {
            this.lojaDbContext = new BaseTransientDbContext();
        }

        public void InserirLogErro(string function, string chave, string maquina, string exception)
        {
            var query = @"insert into TB_LOG_ERROS (dt_erro, DS_CHAVE , ds_function, ds_maquina, ds_exception ) 
                        values (getdate(), @chave , @function, @maquina, @exception) ";
            var parametros = new { function = function, chave = chave, maquina = maquina, exception = exception };
            this.lojaDbContext.Executar(query, parametros);
        }
    }
}
