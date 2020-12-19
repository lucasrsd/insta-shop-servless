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
using InstaShop.DbContext.Base;

namespace InstaShop.DbContext.Login.Domain
{
    public class LoginDomain
    {
        public long IdLogin { get; set; }
        public string Usuario { get; set; }
        public string Maquina { get; set; }
        public List<CookieValue> Cookies { get; set; }
        public DateTime? DataLogin { get; set; }
    }

    public class CookieValue
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
}
