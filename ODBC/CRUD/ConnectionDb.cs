using System;
using System.Data.SqlClient;

namespace CRUD
{
    public class ConnectionDb
    {
        public SqlConnection GetConnection()
        {
            string connectionString =
                 "Data source = localhost; Initial Catalog =PRODUCT;User =sa; password=sontre96";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
