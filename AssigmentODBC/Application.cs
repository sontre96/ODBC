using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssigmentODBC
{
    class Application
    {
        static ConnectionDB connectionDB = new ConnectionDB();
        static SqlConnection connection = connectionDB.GetConnection();

        static List<Product> products;


        static void Main(string[] args)
        {
            try
            {
                int choose;
                do
                {
                    Menu();
                    choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            AddData();//OK
                            break;
                        case 2:
                            SearchProductById();//OK
                            break;
                        case 3:
                            EditData();
                            break;
                        case 4:
                            DeleteData();
                            break;
                        case 5:
                            ViewAllData();//OK
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
            catch (Exception e)
            {
                Console.WriteLine("Only enter Number !!!");
            } 
        }

        static void ViewAllData()
        {
            string query = "SELECT * FROM Product";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            products = new List<Product>();
            while (sqlDataReader.Read())
            {
                Product product = new Product((int)sqlDataReader[0], (string)sqlDataReader[1], (string)sqlDataReader[2], (decimal)sqlDataReader[3]); 
                products.Add(product);
            }

            foreach(Product product in products)
            {
                Console.WriteLine(product.ToString());
            }    

            
            
            connection.Close();
        }

        static void AddData()
        {
            string query = "INSERT INTO Product VALUES(@ProName, @ProDesc, @Price)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            Console.WriteLine("Enter name product:");
            sqlCommand.Parameters.AddWithValue("@ProName", Console.ReadLine());
            Console.WriteLine("Enter description product:");
            sqlCommand.Parameters.AddWithValue("@ProDesc", Console.ReadLine());
            Console.WriteLine("Enter price product:");
            sqlCommand.Parameters.AddWithValue("@Price", double.Parse(Console.ReadLine()));

            connection.Open();

            int row = sqlCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("insert data success!");
        }

        static void EditData()
        {
            int choice;
            Console.WriteLine("Where do you want to edit? ");
            Console.WriteLine("1. Search id product to edit");
            Console.WriteLine("2. Product's Name ");
            Console.WriteLine("3. Product's Description ");
            Console.WriteLine("4. Product's Price ");
            Console.WriteLine("5. Exit ");

            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    SearchProductById();
                    EditData();
                    break;
                case 2:
                    EditName();
                    EditData();
                    break;
                case 3:
                    EditDesc();
                    EditData();
                    break;
                case 4:
                    EditPrice();
                    EditData();
                    break;
                case 5:
                    ViewAllData();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void EditName()
        {
            string query = "UPDATE Product SET proname = @proName WHERE Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            Console.WriteLine("Enter new Name product to change:");
            sqlCommand.Parameters.AddWithValue("@proName", Console.ReadLine());

            Console.WriteLine("Enter Product Id to change:");
            sqlCommand.Parameters.AddWithValue("@Id", double.Parse(Console.ReadLine()));


            connection.Open();

            int row = sqlCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("update Name product data success!");
        }

        static void EditDesc()
        {
            string query = "UPDATE Product SET proDesc = @proDesc WHERE Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            Console.WriteLine("Enter new description product  to change:");
            sqlCommand.Parameters.AddWithValue("@proDesc", Console.ReadLine());

            Console.WriteLine("Enter Product Id to change:");
            sqlCommand.Parameters.AddWithValue("@Id", double.Parse(Console.ReadLine()));
            connection.Open();

            int row = sqlCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("update Description product data success!");
        }

        static void EditPrice()
        {
            string query = "UPDATE Product SET Price = @Price WHERE Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            Console.WriteLine("Enter new Price product  to change:");
            sqlCommand.Parameters.AddWithValue("@Price", double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter Product Id to change:");
            sqlCommand.Parameters.AddWithValue("@Id", double.Parse(Console.ReadLine()));

            connection.Open();

            int row = sqlCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("update Price product data success!");
        }

        static void DeleteData()
        {
            SearchProductById();
            string query = "Delete Product WHERE id = @id ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            Console.WriteLine("Enter product id you want to delete:");
            sqlCommand.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

            connection.Open();

            int row = sqlCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("delete data success!");
        }

        static void SearchProductById()
        {
            string query = "SELECT * FROM Product WHERE id = @id ";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            Console.WriteLine("Enter product id you want to search:");
            sqlCommand.Parameters.AddWithValue("@id", double.Parse(Console.ReadLine()));

            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                if (sqlDataReader != null)
                {
                    Console.WriteLine("Product id: " + sqlDataReader[0]
                       + "\tProduct Name : " + sqlDataReader[1]
                       + "\tProduct description: " + sqlDataReader[2]
                       + "\tPrice: " + sqlDataReader[3]);
                    break;
                }
                else
                {
                    Console.WriteLine(" Id Product not found!");
                }
            }
            connection.Close();
        }

        static void SearchProductByName()
        {
            string query = "SELECT * FROM Product WHERE proName = @proName ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            Console.WriteLine("Enter name product:");
            sqlCommand.Parameters.AddWithValue("@proName", Console.ReadLine());

            connection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                if (sqlDataReader != null)
                {
                    Console.WriteLine("Product id: " + sqlDataReader[0]
                       + "\tProduct Name : " + sqlDataReader[1]
                       + "\tProduct description: " + sqlDataReader[2]
                       + "\tPrice: " + sqlDataReader[3]);
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }
            }
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

