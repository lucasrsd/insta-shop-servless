using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace InstaShop.HastTags.Models
{
    public class Processamentos
    {
        public string Usuario { get; set; }
        public string Status { get; set; }
        public string Host { get; set; }
        public string Login { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
    }
}
