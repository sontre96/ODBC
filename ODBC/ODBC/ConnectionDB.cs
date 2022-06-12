using System;
using System.Data.SqlClient;


namespace ODBC
{
    public class ConnectionDB
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
