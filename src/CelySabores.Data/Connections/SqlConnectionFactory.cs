using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CelySabores.Data.Connections
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private static readonly string ConnectionString;

        static SqlConnectionFactory()
        {
            var config = ConfigurationManager.ConnectionStrings["CelySabores"];
            if (config == null || string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new InvalidOperationException(
                    "A ligação com o banco de dados não está configurada. Verifique o App.config (connection string 'CelySabores').");
            }

            ConnectionString = config.ConnectionString;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}