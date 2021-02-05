using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public class EmployeesRepo : Database, IEmployeesRepo
    {
        public EmployeesRepo(DatabaseProperties databaseProperties) : base(databaseProperties)
        {

        }

        public IEnumerable<Employee> getEmployees()
        {
            Connect();

            SqlCommand cmd = new SqlCommand("SELECT EmployeeID, FirstName, LastName FROM Employees");
            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> results = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                results.Add(employee);
            }

            return results;

        }
        public Employee getEmployee(string id)
        {
            Connect();

            SqlCommand cmd = new SqlCommand("SELECT EmployeeID, FirstName, LastName FROM Employees WHERE EmployeeID = @id");
            cmd.Parameters.Add(new SqlParameter("@id", id));

            cmd.Connection = _connection;

            Employee employee = null;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employee = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            return employee;
        }
       
    }
}