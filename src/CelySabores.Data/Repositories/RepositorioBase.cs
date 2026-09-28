using System.Data.SqlClient;

namespace CelySabores.Data.Repositories
{
    public abstract class RepositorioBase
    {
        protected readonly Database.CommandHelper Db;

        protected RepositorioBase(Database.CommandHelper commandHelper)
        {
            Db = commandHelper;
        }

        protected static SqlParameter Nulo(string nome, string valor)
        {
            return new SqlParameter(nome, (object)valor ?? System.DBNull.Value);
        }

        protected static SqlParameter Nulo(string nome, int? valor)
        {
            return new SqlParameter(nome, (object)valor ?? System.DBNull.Value);
        }

        protected static SqlParameter Nulo(string nome, decimal? valor)
        {
            return new SqlParameter(nome, (object)valor ?? System.DBNull.Value);
        }
    }
}
