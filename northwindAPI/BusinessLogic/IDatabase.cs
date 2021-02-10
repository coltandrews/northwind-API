using System.Data.SqlClient;

namespace northwindAPI
{
    public interface IDatabase
    {
        SqlConnection getConnection();
    }
}