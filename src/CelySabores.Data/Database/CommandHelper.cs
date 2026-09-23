using System.Data;
using System.Data.SqlClient;
using CelySabores.Data.Connections;

namespace CelySabores.Data.Database
{
    public class CommandHelper
    {
        private readonly IConnectionFactory _connectionFactory;

        public CommandHelper(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public SqlConnection CreateConnection()
        {
            return _connectionFactory.Create();
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            using (var command = CriarComando(connection, sql, parameters))
            {
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            using (var command = CriarComando(connection, sql, parameters))
            {
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            using (var command = CriarComando(connection, sql, parameters))
            using (var adapter = new SqlDataAdapter(command))
            {
                connection.Open();
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        private SqlCommand CriarComando(SqlConnection connection, string sql, SqlParameter[] parameters)
        {
            var command = new SqlCommand(sql, connection)
            {
                CommandType = CommandType.Text,
                CommandTimeout = 30
            };

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command;
        }
    }
}