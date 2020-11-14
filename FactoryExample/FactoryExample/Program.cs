using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
   public static class Program
   {
      public static void Main(string[] args)
      {
         Console.WriteLine("Hello");

         DBFactory dBFactory = new DBFactory("mssql");
         IDatabase<Product> dbHandler = dBFactory.GetDatabase<Product>();
         Product p = new Product();

         dbHandler.Add(p);

      }
   }
}
