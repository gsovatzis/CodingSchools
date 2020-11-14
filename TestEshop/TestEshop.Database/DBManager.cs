using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace TestEshop.Database
{
   public sealed class DBManager
   {
      private static DBManager _instance;
      private static readonly object padlock = new object();   // This is just a lock object to achieve thread-safety
      private SqlConnection _connection;

      private DBManager()
      {
         // Private constructor: Cannot directly create objects for this class
      }

      public static DBManager instance
      {
         get
         {
            if (_instance == null)
            {
               lock (padlock)  // This prevents any other thread from getting a new instance of our singleton
               {
                  if (_instance == null)
                  {
                     _instance = new DBManager();
                  }
               }
            }
            return _instance;
         }
      }
      
      public SqlConnection Connection
      {
         get {
            // Get the connection String (you must reference System.Configuration.dll in order to access ConfigurationManager class!)
            Configuration config = null;
            string exeConfigPath = this.GetType().Assembly.Location; // In order to read App.config from the DLL path, we need this.
            config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);

            string conString = config.ConnectionStrings.ConnectionStrings["myConn"].ConnectionString;

            // By using this singleton object, we make sure that we have only one open connection
            try
            {
               if (_connection == null)
               {
                  _connection = new SqlConnection(conString);
                  _connection.Open();
               }
               else if (_connection.State == System.Data.ConnectionState.Closed)
               {
                  _connection.ConnectionString = conString;
                  _connection.Open();
               }
            } catch(Exception ex)
            {
               throw ex;
            }

            return _connection;
         }
      }

    }
}
