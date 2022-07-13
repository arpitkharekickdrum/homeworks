using Microsoft.IdentityModel.Protocols;
using MySqlConnector;
using System.Configuration;
using System.Data.SqlClient;

namespace Inset_update_delete_HW
{
    internal class Program
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["NorthwindDb"].ConnectionString;

        static void Main(string[] args)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var place = "india";
                //SqlCommand cmd = new SqlCommand($"Insert into Region (RegionID,RegionDescription)  values(4,'{place}')", sqlConnection);
                //Console.WriteLine("Insert Executed");
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();

                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();

                var sql = $"Insert into Products (ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued)  " +
                    $"values('abc',12,2,'100 ml',12,50,12,1,1)";
                command = new SqlCommand(sql, sqlConnection);
                adapter.InsertCommand = new SqlCommand(sql,sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();
                Console.WriteLine("Insert Executed");

                sql = "Select * from Products";

                command = new SqlCommand(sql, sqlConnection);

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]} , {dataReader[1]} , {dataReader[2]} ,{dataReader[3]} ,{dataReader[4]} ," +
                        $"{dataReader[5]} , {dataReader[6]} , {dataReader[7]} , {dataReader[8]} , {dataReader[9]}");
                }



                dataReader.Close();

                sql = "Update Products set QuantityPerUnit='111ml' where ProductID=78";


                command = new SqlCommand(sql, sqlConnection);

                adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();
                Console.WriteLine("Update Executed");

                sql = "Select * from Products";

                command = new SqlCommand(sql, sqlConnection);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]} , {dataReader[1]} , {dataReader[2]} ,{dataReader[3]} ,{dataReader[4]} ," +
                        $"{dataReader[5]} , {dataReader[6]} , {dataReader[7]} , {dataReader[8]} , {dataReader[9]}");
                }



                dataReader.Close();

                sql = "Delete Products where ProductID=78";

                command = new SqlCommand(sql, sqlConnection);

                adapter.DeleteCommand = new SqlCommand(sql, sqlConnection);
                adapter.DeleteCommand.ExecuteNonQuery();
                Console.WriteLine("Delete Executed");


                sql = "Select * from Products";

                command = new SqlCommand(sql, sqlConnection);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]} , {dataReader[1]} , {dataReader[2]} ,{dataReader[3]} ,{dataReader[4]} ," +
                        $"{dataReader[5]} , {dataReader[6]} , {dataReader[7]} , {dataReader[8]} , {dataReader[9]}");
                }



                dataReader.Close();


                command.Dispose(); 
		//cnn.Close();

            }
                //Console.WriteLine("Hello, World!");
        }
    }
}