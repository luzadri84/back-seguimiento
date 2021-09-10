using System;

namespace MinCultura.Domain.Common
{
    public class EnvManager
    {
        public readonly string ConnectionString = "";

        public EnvManager()
        {
            var DATABASE_HOST = Environment.GetEnvironmentVariable("DATABASE_HOST");
            var DATABASE_PORT = Environment.GetEnvironmentVariable("DATABASE_PORT");
            var DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");
            var DATABASE_USERNAME = Environment.GetEnvironmentVariable("DATABASE_USERNAME");
            var DATABASE_PASSWORD = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

            // SQLServer
            ConnectionString = "Data Source=" + DATABASE_HOST;
            ConnectionString +=  string.IsNullOrWhiteSpace(DATABASE_PORT) == false ? "," + DATABASE_PORT : string.Empty;
            ConnectionString += ";Initial Catalog=" + DATABASE_NAME;
            ConnectionString += ";persist security info=True;user id=" + DATABASE_USERNAME;
            ConnectionString += ";password=" + DATABASE_PASSWORD;
        }
    }
}
