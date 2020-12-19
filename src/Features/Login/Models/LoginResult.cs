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

namespace InstaShop.Features.Login.Models
{
    public class LoginResult
    {
        public bool Sucesso { get; set; }
        public string Erro { get; set; }
        public Dictionary<string, string> Cookies { get; set; }
        public string TipoLogin { get; set; }
        public string UsuarioLogado { get; set; }
    }
}

