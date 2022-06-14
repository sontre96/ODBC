using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssigmentODBC
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
