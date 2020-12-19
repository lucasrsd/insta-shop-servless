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

namespace InstaShop.DbContext.Lojas.Domain
{
    public class ImagensPublicacoes
    {
        public string ShortCode { get; set; }
        public string Src { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
    }
}
