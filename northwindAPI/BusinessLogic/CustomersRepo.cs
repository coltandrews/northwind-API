using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public class CustomersRepo : Database
    {
        public CustomersRepo()
        {
        }

        public IEnumerable<Customer> getCustomers()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("SELECT CustomerID, CompanyName FROM Customers");
            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Customer> results = new List<Customer>();
            while (reader.Read())
            {
                Customer customer = new Customer(reader.GetString(0), reader.GetString(1));
                results.Add(customer);
            }

            return results;

        }

    }
}