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
    public class Root
    {
        public bool user { get; set; }
        public string userId { get; set; }
        public bool authenticated { get; set; }
        public bool oneTapPrompt { get; set; }
        public string status { get; set; }
    }
}

