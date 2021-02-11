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

        public Employee updateEmployee(Employee emp)
        {

            validate(emp);

            using (SqlConnection connection = _database.getConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("update employees set FirstName = @firstname, LastName = @lastname where EmployeeId = @ID");
                cmd.Parameters.AddWithValue("ID", emp.ID);
                cmd.Parameters.AddWithValue("firstname", emp.FirstName);
                cmd.Parameters.AddWithValue("lastname", emp.LastName);
                cmd.Connection = connection;

                var numRowsAffected = cmd.ExecuteNonQuery();
                return emp;
            }
        }

        public Employee addEmployee(Employee emp)
        {

            // put validation code here (check for required fields, etc.)
            // throw an exception that controller can catch

            validate(emp);

            using (SqlConnection connection = _database.getConnection())
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("insert into employees (FirstName, LastName) values (@firstname, @lastname);select CAST(Scope_Identity() as int)");
                cmd.Parameters.AddWithValue("firstname", emp.FirstName);
                cmd.Parameters.AddWithValue("lastname", emp.LastName);
                cmd.Connection = connection;

                try
                {
                    emp.ID = (int)cmd.ExecuteScalar();

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw new ApiException(System.Net.HttpStatusCode.InternalServerError, "Error adding employee", ex);
                }


                return emp;
            }
        }

        void validate(Employee emp)
        {
            if (string.IsNullOrWhiteSpace(emp.LastName))
            {
                throw new ApiException(System.Net.HttpStatusCode.BadRequest, "Last name required");
            }
        }

    }

}