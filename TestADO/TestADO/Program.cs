using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace TestADO
{
   class Program
   {
      static void Main(string[] args)
      {
         // Get the connection String (you must reference System.Configuration.dll in order to access ConfigurationManager class!)

         string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

         // You need to install System.Data.SqlClient to get access to ADO.NET functionality
         using (SqlConnection connection = new SqlConnection(conString)) { 
            string query = "INSERT INTO Categories (Category_Name, Parent_Category_Id) VALUES ('Shoes', NULL);";
            string catname = "Shoes";
               
            string query2 = $"SELECT * FROM Categories WHERE Category_Name=@CatName";


            try
            {
               connection.Open();
               SqlCommand command = new SqlCommand(query, connection);
               command.ExecuteNonQuery();

               SqlCommand cmd2 = new SqlCommand(query2, connection);
               cmd2.Parameters.AddWithValue("@CatName", catname);

               SqlDataReader reader = cmd2.ExecuteReader();
               while(reader.Read())
               {
                  Console.WriteLine(reader["Category_Name"]);
               }
               
            } catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
               Console.WriteLine(ex.StackTrace);
            }
         }
                  
         Console.ReadKey();
         
      }
   }
}
