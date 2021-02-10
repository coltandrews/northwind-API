using System;
using System.Text;
using System.Data.SqlClient;
using northwindAPI.BusinessLogic;

namespace northwindAPI

{
    public class Database : IDatabase
    {
        public static string FirstName;
        public static string LastName;

        private DatabaseProperties _connectionProperties;

        public Database(DatabaseProperties connectionProperties)
        {
            this._connectionProperties = connectionProperties;
        }

        public SqlConnection getConnection()
        {
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = _connectionProperties.DataSource;
                builder.UserID = _connectionProperties.UserID;
                builder.Password = _connectionProperties.Password;
                builder.InitialCatalog = _connectionProperties.InitialCatalog;

                return new SqlConnection(builder.ConnectionString);

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}