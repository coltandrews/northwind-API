using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public class CustomersRepo : ICustomersRepo
    {
        IDatabase _database;

        public CustomersRepo(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Customer> getCustomers()
        {
            using (SqlConnection connection = _database.getConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT CustomerID, CompanyName FROM Customers");
                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Customer> results = new List<Customer>();
                while (reader.Read())
                {
                    Customer customer = new Customer(reader.GetString(0), reader.GetString(1));
                    results.Add(customer);
                }

                connection.Close();
                return results;

            }
        }
    }
}