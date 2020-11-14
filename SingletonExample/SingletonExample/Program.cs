using System;

namespace SingletonExample
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello World!");

         DBManager dBManager = DBManager.instance;
         dBManager.getConnection();
      }
   }
}
