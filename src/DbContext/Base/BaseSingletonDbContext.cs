using System;
using System.IO;
using System.Threading.Tasks;
using System.Security.Authentication;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace InstaShop.DbContext.Base
{
    public class BaseSingletonDbContext
    {
        public void ExecutarEmSequenciaMantendoConexao(List<BatchRequest> batchRequest)
        {
            using (var sqlInstance = new SqlConnection(Environment.GetEnvironmentVariable("DbInstaRobo")))
            {
                batchRequest.ForEach(x => sqlInstance.Query(x.Query, x.Values, commandTimeout: 180));
            }
        }
    }
}
