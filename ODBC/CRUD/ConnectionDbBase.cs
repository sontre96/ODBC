namespace CRUD
{
    public class ConnectionDbBase
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