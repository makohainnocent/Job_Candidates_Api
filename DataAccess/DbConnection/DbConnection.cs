using Application.Abstractions;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using System.IO;

namespace DataAccess.DbConnection
{
    public class DbConnection : IDbConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
           
            string connectionString = _configuration.GetConnectionString("sqliteConnectionString");

            
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string relativePath = connectionString.Replace("Data Source=./", string.Empty).Replace("Data Source=", string.Empty);

            
            string fullPath = Path.Combine(baseDirectory, relativePath);

            
            string finalConnectionString = $"Data Source={fullPath}";

            
            Console.WriteLine($"Database Path: {fullPath}");

           
            return new SqliteConnection(finalConnectionString);
        }
    }
}
