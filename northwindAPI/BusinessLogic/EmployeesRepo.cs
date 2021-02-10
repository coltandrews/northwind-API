using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public class EmployeesRepo : IEmployeesRepo
    {
        IDatabase _database;
        public EmployeesRepo(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Employee> getEmployees()
        {

            using (SqlConnection connection = _database.getConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT EmployeeID, FirstName, LastName FROM Employees");
                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Employee> results = new List<Employee>();
                while (reader.Read())
                {
                    Employee employee = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    results.Add(employee);
                }

                connection.Close();
                return results;
            }
        }

        public Employee getEmployeeById(string id)
        {

            using (SqlConnection connection = _database.getConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT EmployeeID, FirstName, LastName FROM Employees where EmployeeId = @ID");
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Employee employee = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                    connection.Close();
                    return employee;
                }
            }
            return null;
        }

    }

}