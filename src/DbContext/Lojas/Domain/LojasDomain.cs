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
using Newtonsoft.Json.Converters;

namespace InstaShop.DbContext.Lojas.Domain
{

    public class LojasDomain
    {
        public string Usuario { get; set; }
        public StatusLoja StatusLoja { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public List<DadosColetados> Dados { get; set; }
    }

    public class DadosColetados
    {
        public StatusColeta StatusColeta { get; set; }
        public string NomeDescricao { get; set; }
        public string Biografia { get; set; }
        public string Link { get; set; }
        public long? QuantidadePublicacoes { get; set; }
        public long? Seguidores { get; set; }
        public long? Seguindo { get; set; }
        public DateTime? DataCriacao { get; set; }
        public List<Publicacoes> Publicacoes { get; set; }
        public List<ImagensPublicacoes> Imagens { get; set; }
        public string MaquinaColetada { get; set; }
        public DateTime? DataInicioProcessamento { get; set; }
        public DateTime? DataFimProcessamento { get; set; }
        public string UsuarioColeta { get; set; }
    }

    public enum StatusLoja
    {
        ATIVA = 1,
        INATIVA
    }

    public enum StatusColeta
    {
        EM_PROCESSAMENTO = 1,
        PROCESSADO,
        ERRO
    }
}
