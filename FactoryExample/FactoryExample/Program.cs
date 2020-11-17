using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
   public static class Program
   {
      public static void Main(string[] args)
      {
         string setting = "mysql";

         DBFactory dBFactory = new DBFactory(setting);
         IDatabase<Product> dbHandler = dBFactory.GetDatabase<Product>();

         Product p = new Product();
         /*
         switch (setting)
         {
            case "mssql":
               MsSQL<Product> mssql = new MsSQL<Product>();
               mssql.Add(p);
               break;
            case "mongodb":
               MongoDB<Product> mongo = new MongoDB<Product>();
               mongo.Add(p);
               break;

         }
         */


         dbHandler.Add(p);

         Console.ReadLine();

      }
   }
}
