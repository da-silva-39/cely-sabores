using System.Data.SqlClient;

namespace CelySabores.Data.Connections
{
    public interface IConnectionFactory
    {
        SqlConnection Create();
    }
}