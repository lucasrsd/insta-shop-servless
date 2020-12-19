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
using InstaShop.ConstsVariables;

namespace InstaShop.DbContext.Lojas
{
    public class LojasDbContext
    {
        private BaseTransientDbContext lojaDbContext { get; }

        public LojasDbContext()
        {
            this.lojaDbContext = new BaseTransientDbContext();
        }
        public List<Processamentos> ObterProcessamentos()
        {
            var query = @"select top 100 Nm_usuario Usuario, b.ds_status Status, DT_INICIO_COLETA  UltimaAtualizacao ,DS_USUARIO_COLETA  Login , DS_HOST Host                            
                             FROM TB_CRAWLER_DADOS a join TB_TP_CRAWLER_STATUS_COLETA b
                            on a.id_status_coleta = b.id_status
                            where cast(DT_INICIO_COLETA as date)   >= cast(getdate() - 1 as date) 
                            order by DT_INICIO_COLETA desc  ";
            var lista = this.lojaDbContext.ObterListagem<Processamentos>(query);

            return lista.ToList();
        }

        public long IniciarColeta(string usuario, string usuarioColeta)
        {
            var query = @"insert into TB_CRAWLER_DADOS (nm_usuario, dt_inicio_coleta, id_status_coleta, ds_maquina_coleta, DS_USUARIO_COLETA, DS_HOST) 
                            values (@usuario, getdate(), 1, @maquina, @usuarioColeta, @host)
                            select @@identity";
            var parametros = new { usuario = usuario, maquina = Environment.MachineName, usuarioColeta = usuarioColeta, host = Host.PATH_BASE };
            return this.lojaDbContext.ObterObjeto<long>(query, parametros);
        }

        public void AtualizarUmaAlteracaoLoja(string username)
        {
            var query = @"update TB_CRAWLER_LOJAS set dt_ultima_atualizacao = getdate() where nm_usuario = @usuario ";
            var parametros = new { usuario = username };
            this.lojaDbContext.Executar(query, parametros);
        }


        public void AtualizarStatusColeta(long idColeta, StatusColeta status)
        {
            var query = @"update TB_CRAWLER_DADOS set  id_status_coleta = @id_status where id = @id ";
            var parametros = new { id = idColeta, id_status = (int)status };
            this.lojaDbContext.Executar(query, parametros);
        }

        public LojasDomain Obter(string usuario)
        {
            var query = @"select nm_usuario Usuario, 
                            id_status_loja StatusLoja,
                            dt_ultima_atualizacao UltimaAtualizacao
                            from TB_CRAWLER_LOJAS
                            where nm_usuario = @usuario ";
            var parametros = new { usuario = usuario };
            return this.lojaDbContext.ObterObjeto<LojasDomain>(query, parametros);
        }

        public void IncluirLoja(string usuario, StatusLoja status)
        {
            var query = @"insert into tb_crawler_lojas (nm_usuario, id_status_loja, dt_ultima_atualizacao)
                         values (@usuario, @status, getdate()) ";
            var parametros = new { usuario = usuario, status = (int)status };
            this.lojaDbContext.Executar(query, parametros);
        }

        public void IncluirDados(string usuario, long idColeta, DadosColetados dados)
        {
            var query = @"
            
                DROP TABLE IF EXISTS #TEMP_PERFIL;
                DROP TABLE IF EXISTS #TEMP_PUBLICACOES;
                DROP TABLE IF EXISTS #TEMP_IMAGENS;

                SELECT * 
                into #TEMP_PERFIL
                FROM OPENJSON(@json)
                WITH (    
                            StatusColeta        NVARCHAR(MAX)    '$.StatusColeta'               ,
                            NomeDescricao        nvarchar(MAX)    '$.NomeDescricao'               ,
                            Biografia        nvarchar(MAX)    '$.Biografia'               ,
                            Link        nvarchar(MAX)    '$.Link'               ,
                            QuantidadePublicacoes        NVARCHAR(MAX)    '$.QuantidadePublicacoes'               ,
                            Seguidores        NVARCHAR(MAX)    '$.Seguidores'               ,
                            Seguindo        NVARCHAR(MAX)    '$.Seguindo'               ,    
                            DataCriacao        nvarchar(MAX)    '$.DataCriacao'               ,    
                            MaquinaColetada        nvarchar(MAX)    '$.MaquinaColetada'               ,
                            DataInicioProcessamento        nvarchar(MAX)    '$.DataInicioProcessamento'               ,  
                            DataFimProcessamento        nvarchar(max)    '$.DataFimProcessamento'               ,  
                            UsuarioColeta        nvarchar(MAX)    '$.UsuarioColeta'               ,
                            
                            [VAZIO]            NVARCHAR(MAX)   '$.X'   AS JSON                
                    ) AS CORE 


                SELECT * 
                into #TEMP_PUBLICACOES
                FROM 
                    OPENJSON(@json, '$.Publicacoes')
                        WITH
                        (
                            ShortCode NVARCHAR(50) '$.ShortCode',
                        TipoConteudo NVARCHAR(200) '$.TipoConteudo',
                            Descricao NVARCHAR(MAX) '$.Descricao' ,
                                Curtidas NVARCHAR(MAX) '$.Curtidas',
                                Comentarios NVARCHAR(MAX) '$.Comentarios',
                                HorarioPublicacao NVARCHAR(MAX)  '$.HorarioPublicacao',
                                [VAZIO] NVARCHAR(MAX) '$.X' as json 
                        ) AS ARRAY_PUBLICACOES
                        
                SELECT * 
                into #TEMP_IMAGENS
                FROM 
                    OPENJSON(@json, '$.Imagens')
                        WITH
                        (
                            ShortCode NVARCHAR(50) '$.ShortCode',
                        Src NVARCHAR(200) '$.Src',
                            Width NVARCHAR(MAX) '$.Width' ,
                                Height NVARCHAR(MAX) '$.Height',
                                [VAZIO] NVARCHAR(MAX) '$.X' as json 
                        ) AS ARRAY_IMAGENS


                UPDATE A
                SET		ID_STATUS_COLETA  = B.STATUSCOLETA  ,
                        DT_INICIO_COLETA  =   CONVERT(DATETIME, LEFT(B.DATAINICIOPROCESSAMENTO, 23) ,127)   ,
                        DT_FIM_COLETA = CONVERT(DATETIME, LEFT( B.DATAFIMPROCESSAMENTO, 23) ,127)    ,
                        DS_MAQUINA_COLETA = B.MAQUINACOLETADA  ,
                        DS_NOME_DESCRICAO = B.NOMEDESCRICAO  ,
                        DS_BIOGRAFIA = B.BIOGRAFIA  ,
                        DS_LINK     = B.LINK,
                        QT_PUBLICACOES = B.QUANTIDADEPUBLICACOES  ,
                        QT_SEGUIDORES = B.SEGUIDORES  ,
                        QT_SEGUINDO    = B.SEGUINDO ,
                        DS_USUARIO_COLETA = B.USUARIOCOLETA
                FROM TB_CRAWLER_DADOS A
                JOIN #TEMP_PERFIL B
                ON A.ID =  @ID_PUBLICACAO


                INSERT INTO TB_CRAWLER_PUBLICACOES
                            (
                                ID_CRAWLER_DADOS ,
                                DS_SHORT_CODE ,
                                DS_TIPO_CONTEUDO ,
                                DS_DESCRICAO ,
                                QT_CURTIDAS ,
                                QT_COMENTARIOS ,
                                DT_PUBLICACAO_ORIGINAL ,
                                DT_COLETA_PUBLICACAO 
                            ) 
                        
                SELECT @ID_PUBLICACAO, SHORTCODE, TIPOCONTEUDO, DESCRICAO, CURTIDAS, COMENTARIOS, HORARIOPUBLICACAO, GETDATE()  
                FROM #TEMP_PUBLICACOES


                INSERT INTO TB_CRAWLER_PUBLICACOES_IMAGENS 
                        (
                            DS_SHORT_CODE ,
                            ID_CRAWLER_DADOS,
                            DT_GRAVACAO,
                            DS_HASH_GERENCIADOR_IMG ,
                            DS_SRC_ORIGINAL ,
                            QT_WIDTH , 
                            QT_HEIGHT 
                        )
                SELECT SHORTCODE , @ID_PUBLICACAO , GETDATE(), NULL, SRC, WIDTH, HEIGHT 
                FROM #TEMP_IMAGENS       
            ";

            var parametros = new { json = JsonConvert.SerializeObject(dados), ID_PUBLICACAO = idColeta };

            this.lojaDbContext.Executar(query, parametros);
        }
    }
}
