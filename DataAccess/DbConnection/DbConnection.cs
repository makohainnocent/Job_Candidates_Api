using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbConnection
{
    public class DbConnection: IDbConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("sqliteConnectionString");
            return new SqlConnection(connectionString);
        }

   
    }
}
