using System;
using System.Text;
using System.Data.SqlClient;
using northwindAPI.BusinessLogic;

namespace northwindAPI

{
    public class Database : IDisposable
    {
        public static string FirstName;
        public static string LastName;

        protected SqlConnection _connection = new SqlConnection();
        private DatabaseProperties _connectionProperties;

        public Database(DatabaseProperties connectionProperties)
        {
            this._connectionProperties = connectionProperties;
        }

        protected void Connect()
        {
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = _connectionProperties.DataSource;
                builder.UserID = _connectionProperties.UserID;
                builder.Password = _connectionProperties.Password;
                builder.InitialCatalog = _connectionProperties.InitialCatalog;

                // Connect to SQL
                Console.WriteLine("Connecting to SQL Server ... ");

                _connection = new SqlConnection(builder.ConnectionString);
                _connection.Open();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        protected void Close()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }


}