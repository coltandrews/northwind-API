﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public class EmployeesRepo : Database
    {
        public EmployeesRepo()
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

    }
}