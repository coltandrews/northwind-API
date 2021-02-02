using System;
using System.Text;
using System.Data.SqlClient;

namespace northwindAPI

{
    public class Database : IDisposable
    {
        public static string FirstName;
        public static string LastName;

        protected SqlConnection _connection = new SqlConnection();

        protected void Connect()
        {
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";
                builder.UserID = "sa";
                builder.Password = "<YourMothers@Man>";
                builder.InitialCatalog = "Northwind";

                // Connect to SQL
                Console.WriteLine("Connecting to SQL Server ... ");
                _connection = new SqlConnection(builder.ConnectionString);
                _connection.Open();
              
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
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