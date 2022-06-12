using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ODBC
{
    class Application
    {
        static ConnectionDB connectionDB = new ConnectionDB();
        static SqlConnection connection = connectionDB.GetConnection();

        static void Main(string[] args)
        {
            int choose;
            do
            {
                Menu();
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        AddData();//OK
                        break;
                    case 2:
                        SearchProductById();//OK
                        break;
                    case 3:
                        EditData();//OK
                        break;
                    case 4:
                        DeleteData();
                        break;
                    case 5:
                        ViewAllData();//OK (khong su dung collection)
                        break;
                    case 6:
                        SearchProductByName();//OK
                        break;
                    case 7:
                        Console.WriteLine("Exit Program!!!");
                        break;
                    default:
                        Console.WriteLine("Please you choose again!!! ");
                        break;
                }
            }
            while (choose != 7);
        }

        static void ViewAllData()
        {
            string query = "SELECT * FROM product";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                Console.WriteLine("Product id: " + sqlDataReader[0]
                        + "\tProduct Name : " + sqlDataReader[1]
                        + "\tProduct description: " + sqlDataReader[2]
                        + "\tPrice: " + sqlDataReader[3]);
            }
            sqlDataReader.Close();
            connection.Close();
        }

        static void AddData()   
        {
            Console.WriteLine("Enter name product:");
            string proName = Console.ReadLine();
            Console.WriteLine("Enter description product:");
            string proDesc = Console.ReadLine();
            Console.WriteLine("Enter price product:");
            int Price = Convert.ToInt32(Console.ReadLine());
            string query = "INSERT INTO product(ProName, ProDesc, Price)" +
                "VALUES(@ProName, @ProDesc, @Price)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@ProName", proName);
                sqlCommand.Parameters.AddWithValue("@ProDesc", proDesc);
                sqlCommand.Parameters.AddWithValue("@Price", Price);
                int row = sqlCommand.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("insert data success!");

            } catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void EditData()
        {
            SearchProductById();
            Console.WriteLine("Enter name product:");
            string proName = Console.ReadLine();
            Console.WriteLine("Enter description product:");
            string proDesc = Console.ReadLine();
            Console.WriteLine("Enter price product:");
            int Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product id:");
            int id = Convert.ToInt32(Console.ReadLine());
            string query = "UPDATE product SET proName = @proName, proDesc = @proDesc, " +
                "Price = @Price  WHERE id = @id ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@ProName", proName);
            sqlCommand.Parameters.AddWithValue("@ProDesc", proDesc);
            sqlCommand.Parameters.AddWithValue("@Price", Price);
            sqlCommand.Parameters.AddWithValue("@id", id);
            int row = sqlCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("update data success!");
        }

        public static void DeleteData()
        {
            SearchProductById();
            Console.WriteLine("Enter product id:");
            int id = Convert.ToInt32(Console.ReadLine());
            string query = "Delete product WHERE id = @id ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@id", id);
            int row = sqlCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("delete data success!");
        }

        static void SearchProductById()
        {
            Console.WriteLine("Enter product id:");
            int id = Convert.ToInt32(Console.ReadLine());
            string query = "SELECT * FROM product WHERE id = @id ";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            Console.WriteLine("Product id: " + sqlDataReader[0]
                       + "\tProduct Name : " + sqlDataReader[1]
                       + "\tProduct description: " + sqlDataReader[2]
                       + "\tPrice: " + sqlDataReader[3]);
            sqlDataReader.Close();
            connection.Close();
        }

        static void SearchProductByName()
        {
            Console.WriteLine("Enter name product:");
            string proName = Console.ReadLine();
            string query = "SELECT * FROM product WHERE proName = @proName ";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@proName", proName);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Console.WriteLine("Product id: " + sqlDataReader[0]
                       + "\tProduct Name : " + sqlDataReader[1]
                       + "\tProduct description: " + sqlDataReader[2]
                       + "\tPrice: " + sqlDataReader[3]);
            }
            sqlDataReader.Close();
            connection.Close();
        }

        static void Menu()
        {
            Console.WriteLine("==========Menu==========\n" +
                              "1. Add product\n" +
                              "2. Search product by id\n" +
                              "3. Edit product\n" +
                              "4. Delete product\n" +
                              "5. View all product\n" +
                              "6. Search product by name\n" +
                              "7. Exit!!!\n" +
                              "Choose:");
        }
    }
}

