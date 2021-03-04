using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public class ProductsRepo : IProductsRepo
    {
        IDatabase _database;
        public ProductsRepo(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Product> getAll(string nameFilter = null, int? discontinuedFilter = null)
        {

            using (SqlConnection connection = _database.getConnection())
            {
                connection.Open();

                // create the command without SQL yet, we will build the SQL based on what where conditions (filters) we have
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                // starting point for SQL with no where clause, if no conditions we get everything
                string SQL = "SELECT ProductID, ProductName, Discontinued FROM products";

                // collect all the conditions we will build a where clause with (if any)
                // collect each as a "phrase" of the where clause
                List<string> conditions = new List<string>();

                // do we have a name filter? use LIKE so its treated like a string CONTAINS
                if (!string.IsNullOrWhiteSpace(nameFilter))
                {
                    conditions.Add("ProductName like @NAMEFILTER");

                    // add the parameter to the COMMAND while we are here
                    cmd.Parameters.AddWithValue("NAMEFILTER", "%" + nameFilter + "%");
                }

                // do we have a discontinued filter? We want to handle it being 0, 1, or not supplied (null)
                // that way we can get all products regardless of discontinued by just not providing the filter.
                // note that discontinued is a nullable integer (int?)
                // so we can check if it has a value, if not, we wont add a where condition for it
                if (discontinuedFilter.HasValue)
                {
                    conditions.Add("discontinued = @DISCONTINUEDFILTER");

                    // add the parameter to the COMMAND while we are here
                    cmd.Parameters.AddWithValue("DISCONTINUEDFILTER", discontinuedFilter.Value);
                }

                // now we can build the where clause appending each condition with an AND in between
                string whereClause = "";
                if (conditions.Count > 0)
                {
                    whereClause += " where ";
                    whereClause += String.Join(" and ", conditions.ToArray());
                }

                // stick the where clause on the SQL (it will be empty string if no filters)
                SQL += whereClause;
                cmd.CommandText = SQL;


                SqlDataReader reader = cmd.ExecuteReader();
                List<Product> results = new List<Product>();
                while (reader.Read())
                {
                    results.Add(new Product
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Discontinued = reader.GetBoolean(2)
                    });
                }

                connection.Close();
                return results;
            }
        }

        //public IEnumerable<Product> getWithFilters(string filter)
        //{

        //    using (SqlConnection connection = _database.getConnection())
        //    {
        //        connection.Open();
        //        string sql = "SELECT EmployeeID, FirstName, LastName FROM Employees where LastName like @FILTER";
        //        SqlCommand cmd = new SqlCommand(sql);
        //        cmd.Connection = connection;
        //        cmd.Parameters.AddWithValue("FILTER", "%" + filter + "%");

        //        SqlDataReader reader = cmd.ExecuteReader();
        //        List<Employee> results = new List<Employee>();
        //        while (reader.Read())
        //        {
        //            Employee employee = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
        //            results.Add(employee);
        //        }

        //        connection.Close();
        //        return results;
        //    }
        //}

    }

}