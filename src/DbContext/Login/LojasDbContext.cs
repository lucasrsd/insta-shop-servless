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
using InstaShop.DbContext.Login.Domain;
using InstaShop.DbContext.Base;
using InstaShop.Features.Login.Models;

namespace InstaShop.DbContext.Login
{
    public class LoginDbContext
    {
        private BaseTransientDbContext loginDbContext { get; }

        public LoginDbContext()
        {
            this.loginDbContext = new BaseTransientDbContext();
        }

        public void ExcluirAutenticacaoMaquina(string maquina)
        {
            var query = @"  delete from TB_CRAWLER_LOGINS_COOKIES where id_login in (select id FROM TB_CRAWLER_LOGINS where ds_maquina = @maquina)
            delete from  TB_CRAWLER_LOGINS where ds_maquina = @maquina
                            ";

            var parametros = new
            {
                maquina = maquina
            };

            this.loginDbContext.Executar(query, parametros);
        }

        public void IncluirAutenticacao(LoginDomain loginInfo)
        {
            if (loginInfo == null) return;

            ExcluirAutenticacaoMaquina(loginInfo.Maquina);

            var query = @"insert into TB_CRAWLER_LOGINS
                (
                    DS_USUARIO, 
                    DS_MAQUINA , 
                    DT_LOGIN 
                )
                VALUES 
                (
                    @DS_USUARIO, 
                    @DS_MAQUINA , 
                    GETDATE()
                )

             select @@identity
             ";

            var parametros = new
            {
                DS_USUARIO = loginInfo.Usuario,
                DS_MAQUINA = loginInfo.Maquina,
            };

            var idLogin = this.loginDbContext.ObterObjeto<long>(query, parametros);

            if (loginInfo.Cookies != null)
            {
                foreach (var cook in loginInfo.Cookies)
                    InserirCookies(idLogin, cook.Chave, cook.Valor);
            }
        }

        public void InserirCookies(long idLogin, string key, string value)
        {
            var query = @"insert into TB_CRAWLER_LOGINS_COOKIES
                (
                    ID_LOGIN,
                    DS_KEY,
                    DS_VALUE
                )
                values 
                (
                    @idLogin,
                    @DS_KEY,
                    @DS_VALUE
                )";

            var parametros = new
            {
                idLogin = idLogin,
                DS_KEY = key,
                DS_VALUE = value
            };

            this.loginDbContext.Executar(query, parametros);
        }

        public LoginDomain ObterLogin(string maquina)
        {
            var query = @"select id IdLogin, ds_usuario Usuario, ds_maquina Maquina , dt_login DataLogin FROM TB_CRAWLER_LOGINS where ds_maquina =  @maquina";
            var parametros = new { maquina = maquina };
            var loginResult = this.loginDbContext.ObterObjeto<LoginDomain>(query, parametros);

            if (loginResult == null) return null;

            loginResult.Cookies = ObterCookies(loginResult.IdLogin).ToList();

            return loginResult;
        }

        public IEnumerable<CookieValue> ObterCookies(long idLogin)
        {
            var query = @"select ds_key Chave, ds_value Valor  FROM TB_CRAWLER_LOGINS_COOKIES where id_login =  @idLogin";
            var parametros = new { idLogin = idLogin };
            return this.loginDbContext.ObterListagem<CookieValue>(query, parametros);
        }

        public IEnumerable<AutenticacaoResult> ObterLoginsDisponiveis()
        {
            var query = @" select DS_USUARIO Usuario, DS_SENHA Senha  FROM TB_CRAWLER_USUARIOS where (DT_MINIMO_PROXIMO_USO is null or DT_MINIMO_PROXIMO_USO <= getdate()) ";
            return this.loginDbContext.ObterListagem<AutenticacaoResult>(query);
        }

        public void AtualizarProximaValidade(string usuario, DateTime data)
        {
            var query = @"  
                            update TB_CRAWLER_USUARIOS 
                            set DT_MINIMO_PROXIMO_USO = @data
                            where DS_USUARIO = @usuario
                       ";

            var parametros = new { data = data, usuario = usuario };
            this.loginDbContext.Executar(query, parametros);
        }
    }
}
