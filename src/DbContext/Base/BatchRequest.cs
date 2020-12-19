using System;
using System.IO;
using System.Threading.Tasks;
using System.Security.Authentication;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace InstaShop.DbContext.Base
{
    public class BatchRequest
    {
        public string Query { get; set; }
        public object Values { get; set; }
    }
}
