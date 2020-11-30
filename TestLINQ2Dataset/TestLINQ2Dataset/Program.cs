using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ2Dataset
{
   public static class Program
   {
      // Download sample DB from here: https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks
      static DataSet ds = new DataSet();

      static void Setup()
      {
         // Create a new adapter and give it a query to fetch sales order, contact,
         // address, and product information for sales in the year 2002. Point connection
         // information to the configuration setting "AdventureWorks".
         string connectionString = "Data Source=q-lap-gsova;Initial Catalog=AdventureWorks2016;Integrated Security=true;";

         SqlDataAdapter da = new SqlDataAdapter(
             "SELECT SalesOrderID, CustomerID, OrderDate, OnlineOrderFlag, " +
             "TotalDue, SalesOrderNumber, Status, ShipToAddressID, BillToAddressID " +
             "FROM Sales.SalesOrderHeader " +
             //"WHERE DATEPART(YEAR, OrderDate) = @year AND CustomerID IN (SELECT BusinessEntityID FROM Person.Person); " +

             "SELECT d.SalesOrderID, d.SalesOrderDetailID, d.OrderQty, " +
             "d.ProductID, d.UnitPrice " +
             "FROM Sales.SalesOrderDetail d " +
             "INNER JOIN Sales.SalesOrderHeader h " +
             "ON d.SalesOrderID = h.SalesOrderID  " +
             //"WHERE DATEPART(YEAR, OrderDate) = @year AND d.SalesOrderID IN (SELECT SalesOrderID FROM Sales.SalesOrderHeader); " +

         "SELECT p.ProductID, p.Name, p.ProductNumber, p.MakeFlag, " +
         "p.Color, p.ListPrice, p.Size, p.Class, p.Style, p.Weight  " +
         "FROM Production.Product p; " +

         "SELECT DISTINCT a.AddressID, a.AddressLine1, a.AddressLine2, " +
         "a.City, a.StateProvinceID, a.PostalCode " +
         "FROM Person.Address a " +
         "INNER JOIN Sales.SalesOrderHeader h " +
         "ON  a.AddressID = h.ShipToAddressID OR a.AddressID = h.BillToAddressID " +
         //"WHERE DATEPART(YEAR, OrderDate) = @year; " +

         "SELECT DISTINCT c.BusinessEntityID, c.Title, c.FirstName, c.LastName, e.EmailAddress, p.PhoneNumber " +
         "FROM Person.Person c " +
         "INNER JOIN Person.EmailAddress e ON c.BusinessEntityID = e.BusinessEntityID " +
         "INNER JOIN Person.PersonPhone p ON c.BusinessEntityID = p.BusinessEntityID " +
         "INNER JOIN Sales.SalesOrderHeader h ON c.BusinessEntityID = h.CustomerID " ,
         //"WHERE DATEPART(YEAR, OrderDate) = @year;",
         connectionString);

         // Add table mappings.
         //da.SelectCommand.Parameters.AddWithValue("@year", 2012);
         da.TableMappings.Add("Table", "SalesOrderHeader");
         da.TableMappings.Add("Table1", "SalesOrderDetail");
         da.TableMappings.Add("Table2", "Product");
         da.TableMappings.Add("Table3", "Address");
         da.TableMappings.Add("Table4", "Person");

         // Fill the DataSet.
         ds.Locale = CultureInfo.InvariantCulture;
         da.Fill(ds);

         // Add data relations.
         DataTable orderHeader = ds.Tables["SalesOrderHeader"];
         DataTable orderDetail = ds.Tables["SalesOrderDetail"];
         //DataRelation order = new DataRelation("SalesOrderHeaderDetail",
         //                         orderHeader.Columns["SalesOrderID"],
         //                         orderDetail.Columns["SalesOrderID"], true);
         //ds.Relations.Add(order);

         //DataTable contact = ds.Tables["Person"];
         //DataTable orderHeader2 = ds.Tables["SalesOrderHeader"];
         //DataRelation orderContact = new DataRelation("SalesOrderContact",
         //                                contact.Columns["BusinessEntityID"],
         //                                orderHeader2.Columns["CustomerID"], true);
         //ds.Relations.Add(orderContact);
      }

      static void SelectQueries()
      {
         // LINQ Select example (Query expression syntax)
         DataTable products = ds.Tables["Product"];
         var query = from product in products.AsEnumerable()
                     select new
                     {
                        ProductName = product.Field<string>("Name"),
                        ProductNumber = product.Field<string>("ProductNumber"),
                        Price = product.Field<decimal>("ListPrice")
                     };

         Console.WriteLine("Product Names with LINQ SELECT Query expression:");
         foreach (var prod in query)
         {
            Console.WriteLine($"{prod.ProductName}\t{prod.ProductNumber}\t{prod.Price}");
         }
         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();

         // LINQ SELECT example (Method based syntax)
         var query2 = products.AsEnumerable().
                      Select(product => new
                      {
                         ProductName = product.Field<string>("Name"),
                         ProductNumber = product.Field<string>("ProductNumber"),
                         Price = product.Field<decimal>("ListPrice")
                      });

         Console.WriteLine("Product Names with LINQ SELECT Method expression:");
         foreach (var prod in query2)
         {
            Console.WriteLine($"{prod.ProductName}\t{prod.ProductNumber}\t{prod.Price}");
         }
         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
         
      }

      static void SelectManyQueries()
      {
         DataTable contacts = ds.Tables["Person"];
         DataTable orders = ds.Tables["SalesOrderHeader"];

         // LINQ SELECT MANY example (Query expression syntax)
         var query =
             (from contact in contacts.AsEnumerable()
             from order in orders.AsEnumerable()
             where contact.Field<int>("BusinessEntityID") == order.Field<int>("CustomerID")
                 && order.Field<decimal>("TotalDue") < 500.00M
             select new
             {
                ContactID = contact.Field<int>("BusinessEntityID"),
                LastName = contact.Field<string>("LastName"),
                FirstName = contact.Field<string>("FirstName"),
                OrderID = order.Field<int>("SalesOrderID"),
                Total = order.Field<decimal>("TotalDue")
             }).Skip(2).Take(10);      // Skip the first 2 records, take next 10 records (partitioning)

         foreach (var smallOrder in query)
         {
            Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
                smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
                smallOrder.OrderID, smallOrder.Total);
         }


         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();

         // LINQ SELECT MANY example (Method-based query syntax)
         var query2 =
             contacts.AsEnumerable().SelectMany(
                 contact => orders.AsEnumerable().Where(order =>
                     (contact.Field<Int32>("BusinessEntityID") == order.Field<Int32>("CustomerID"))
                         && order.Field<decimal>("TotalDue") < 500.00M)
                     .Select(order => new
                     {
                        ContactID = contact.Field<int>("BusinessEntityID"),
                        LastName = contact.Field<string>("LastName"),
                        FirstName = contact.Field<string>("FirstName"),
                        OrderID = order.Field<int>("SalesOrderID"),
                        Total = order.Field<decimal>("TotalDue")
                     })).Skip(2).Take(10);   // Skip the first 2 records, take next 10 records (partitioning)

         foreach (var smallOrder in query2)
         {
            Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
                  smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
                  smallOrder.OrderID, smallOrder.Total);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectPartitioning()
      {
         DataTable products = ds.Tables["Product"];

         // SKIP RECORDS with < 300 ListPrice
         IEnumerable<DataRow> skipWhilePriceLessThan300 =
             products.AsEnumerable()
                 .OrderBy(listprice => listprice.Field<decimal>("ListPrice"))
                 .SkipWhile(product => product.Field<decimal>("ListPrice") < 300.00M);

         Console.WriteLine("Skip while ListPrice is less than 300.00:");
         foreach (DataRow product in skipWhilePriceLessThan300)
         {
            Console.WriteLine($"{product.Field<string>("Name")} {product.Field<decimal>("ListPrice")}");
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();

         // TAKE RECORDS with < 300 ListPrice
         IEnumerable<DataRow> takeWhileListPriceLessThan300 =
               products.AsEnumerable()
               .OrderBy(listprice => listprice.Field<decimal>("ListPrice"))
               .TakeWhile(product => product.Field<decimal>("ListPrice") < 300.00M);

         Console.WriteLine("First ListPrice less than 300:");
         foreach (DataRow product in takeWhileListPriceLessThan300)
         {
            Console.WriteLine($"{product.Field<string>("Name")} {product.Field<decimal>("ListPrice")}");
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();


      }

      public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
      {
         HashSet<TKey> seenKeys = new HashSet<TKey>();
         foreach (TSource element in source)
         {
            if (seenKeys.Add(keySelector(element)))
            {
               yield return element;
            }
         }
      }

      static void SelectOrdering()
      {
         DataTable contacts = ds.Tables["Person"];


         // LINQ Query Expression syntax
            var query = (from contact in contacts.AsEnumerable()
                          orderby contact.Field<string>("FirstName") descending
                          select new
                          {
                             FName = contact.Field<string>("FirstName")
                          }).Distinct();


            Console.WriteLine("The DISTICT descending sorted list of first names:");
            foreach (var contact in query)
            {
               Console.WriteLine(contact.FName);
            }

            Console.WriteLine("Hit key when ready...");
            Console.ReadKey();

         // LINQ Method-based syntax (ASCENDING ORDER, DISTINCT)
            var query2 = contacts.AsEnumerable()
                                          .Select(c => new
                                          {
                                             FName = c.Field<string>("FirstName")
                                          }).Distinct().OrderBy(c => c.FName);

            foreach (var contact in query2)
            {
               Console.WriteLine(contact.FName);
            }

            Console.WriteLine("Hit key when ready...");
            Console.ReadKey();

      }

      static void SelectAverage()
      {
         var products = ds.Tables["Product"].AsEnumerable();

         // AVERAGE EXAMPLE - Query expression syntax
         var query = from product in products
                     group product by product.Field<string>("Style") into g
                     select new
                     {
                        Style = g.Key,
                        AverageListPrice =
                             g.Average(product => product.Field<Decimal>("ListPrice"))
                     };

         foreach (var product in query)
         {
            Console.WriteLine("Product style: {0} Average list price: {1:0.00}", // Format string with 2 decimals
                product.Style, product.AverageListPrice);
         }
         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();

         // GET AVERAGE PRICE OF ALL PRODUCTS with Method-based syntax
         decimal averageListPrice = products.Average(product => product.Field<Decimal>("ListPrice"));

         Console.WriteLine("The average list price of all the products is ${0:0.00}",
             averageListPrice);

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectCount()
      {
         DataTable contacts = ds.Tables["Person"];
         DataTable orderHeader = ds.Tables["SalesOrderHeader"];

         // GET Count of ORDER per ContactID (method-based syntax)
         var query = contacts.AsEnumerable().SelectMany(
                 contact => orderHeader.AsEnumerable().Where(order =>
                     (contact.Field<Int32>("BusinessEntityID") == order.Field<Int32>("CustomerID"))
                         ).GroupBy(order => order.Field<int>("CustomerID")))
                         .Select(g => new { CustomerID = g.Key, OrderCount = g.Count() }).Take(10);

         foreach (var contact in query)
         {
            Console.WriteLine("CustomerID = {0} \t OrderCount = {1}",
                contact.CustomerID,
                contact.OrderCount);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectSum()
      {
         DataTable orders = ds.Tables["SalesOrderHeader"];

         var query =
             (from order in orders.AsEnumerable()
             group order by order.Field<Int32>("CustomerID") into g
             select new
             {
                Category = g.Key,
                TotalDue = g.Sum(order => order.Field<decimal>("TotalDue")),
             }).Take(10);
         foreach (var order in query)
         {
            Console.WriteLine("ContactID = {0} \t TotalDue sum = {1:0.00}",
                order.Category, order.TotalDue);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectExcept()
      {
         DataTable contactTable = ds.Tables["Person"];

         // Create two tables.
         IEnumerable<DataRow> query1 = from contact in contactTable.AsEnumerable()
                                       where contact.Field<string>("Title") == "Ms."
                                       select contact;

         IEnumerable<DataRow> query2 = from contact in contactTable.AsEnumerable()
                                       where contact.Field<string>("FirstName") == "Sandra"
                                       select contact;

         DataTable contacts1 = query1.CopyToDataTable();
         DataTable contacts2 = query2.CopyToDataTable();

         // Find the contacts that are in the first
         // table but not the second.
         var contacts = contacts1.AsEnumerable().Except(contacts2.AsEnumerable(),
                                                        DataRowComparer.Default);

         Console.WriteLine("Except of employees tables");
         foreach (DataRow row in contacts)
         {
            Console.WriteLine("Id: {0} {1} {2} {3}",
                row["BusinessEntityID"], row["Title"], row["FirstName"], row["LastName"]);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectIntersect()
      {
         DataTable contactTable = ds.Tables["Person"];

         // Create two tables.
         IEnumerable<DataRow> query1 = from contact in contactTable.AsEnumerable()
                                       where contact.Field<string>("LastName") == "Lu"
                                       select contact;

         IEnumerable<DataRow> query2 = from contact in contactTable.AsEnumerable()
                                       where contact.Field<string>("FirstName") == "Sandra"
                                       select contact;

         DataTable contacts1 = query1.CopyToDataTable();
         DataTable contacts2 = query2.CopyToDataTable();

         // Find the intersection of the two tables.
         var contacts = contacts1.AsEnumerable().Intersect(contacts2.AsEnumerable(),
                                                             DataRowComparer.Default);

         Console.WriteLine("Intersection of contacts tables");
         foreach (DataRow row in contacts)
         {
            Console.WriteLine("Id: {0} {1} {2} {3}",
                row["BusinessEntityID"], row["Title"], row["FirstName"], row["LastName"]);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectUnion()
      {
         // Create two tables.
         DataTable contactTable = ds.Tables["Person"];
         IEnumerable<DataRow> query1 = from contact in contactTable.AsEnumerable()
                                       where contact.Field<string>("Title") == "Ms."
                                       select contact;

         IEnumerable<DataRow> query2 = from contact in contactTable.AsEnumerable()
                                       where contact.Field<string>("FirstName") == "Sandra"
                                       select contact;

         DataTable contacts1 = query1.CopyToDataTable();
         DataTable contacts2 = query2.CopyToDataTable();

         // Find the union of the two tables.
         var contacts = contacts1.AsEnumerable().Union(contacts2.AsEnumerable(),
                                                         DataRowComparer.Default);

         Console.WriteLine("Union of contacts tables:");
         foreach (DataRow row in contacts)
         {
            Console.WriteLine("Id: {0} {1} {2} {3}",
                row["BusinessEntityID"], row["Title"], row["FirstName"], row["LastName"]);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectElementAt()
      {
         DataTable addresses = ds.Tables["Address"];

         // SELECT the fifth address where postal code is M4B 1V7 - Query expression syntax
            var fifthAddress = (
                from address in addresses.AsEnumerable()
                orderby address.Field<int>("AddressID")
                where address.Field<string>("PostalCode") == "M4B 1V7"
                select address.Field<string>("AddressLine1"))
            .ElementAt(0);    // zero is the first record 

            Console.WriteLine("Fifth address where PostalCode = 'M4B 1V7': {0}",
                fifthAddress);

            Console.WriteLine("Hit key when ready...");
            Console.ReadKey();

         // SELECT the fifth address where postal code is M4B 1V7 - Method-based syntax
         var fifthAddress2 = addresses.AsEnumerable()
                                       .Where(a => a.Field<string>("PostalCode") == "M4B 1V7")
                                       .Select(a => a.Field<string>("AddressLine1"))
                                       .ElementAt(5);

         Console.WriteLine("Fifth address where PostalCode = 'M4B 1V7': {0}",
             fifthAddress2);

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void SelectFirst()
      {
         DataTable contacts = ds.Tables["Person"];


         // Get first name that is Mary - Query expression syntax
         var query = (
             from contact in contacts.AsEnumerable()
             where contact.Field<string>("FirstName").Equals("Mary")
             select contact)
            .First();
         Console.WriteLine("ContactID: " + query.Field<int>("BusinessEntityID"));
         Console.WriteLine("FirstName: " + query.Field<string>("FirstName"));
         Console.WriteLine("LastName: " + query.Field<string>("LastName"));
         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();

         // Get first name that is Mary - Method-based syntax
         var query2 = contacts.AsEnumerable().Where(c => c.Field<string>("FirstName").Equals("Mary")).Select(c => c).First();
         Console.WriteLine("ContactID: " + query2.Field<int>("BusinessEntityID"));
         Console.WriteLine("FirstName: " + query2.Field<string>("FirstName"));
         Console.WriteLine("LastName: " + query2.Field<string>("LastName"));
         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
                 
      }

      static void GroupJoin()
      {
         var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();
         var details = ds.Tables["SalesOrderDetail"].AsEnumerable();

         // A group join is the equivalent of a left outer join, which returns each element of the first (left) data source, even if no correlated elements are in the other data source.
         var query =
             (from order in orders
             join detail in details
             on order.Field<int>("SalesOrderID") equals detail.Field<int>("SalesOrderID") into ords
             select new
             {
                CustomerID =
                     order.Field<int>("CustomerID"),
                ords = ords.Count()
             }).Take(10);

         foreach (var order in query)
         {
            Console.WriteLine("CustomerID: {0}  Orders Count: {1}",
                order.CustomerID,
                order.ords);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void Join()
      {
         var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();
         var details = ds.Tables["SalesOrderDetail"].AsEnumerable();

         var query =
             (from order in orders
             join detail in details
             on order.Field<int>("SalesOrderID") equals detail.Field<int>("SalesOrderID")
             where order.Field<bool>("OnlineOrderFlag") == true
             && order.Field<DateTime>("OrderDate").Month == 8
             select new
             {
                SalesOrderID =
                     order.Field<int>("SalesOrderID"),
                SalesOrderDetailID =
                     detail.Field<int>("SalesOrderDetailID"),
                OrderDate =
                     order.Field<DateTime>("OrderDate"),
                ProductID =
                     detail.Field<int>("ProductID")
             }).Take(10);

         foreach (var order in query)
         {
            Console.WriteLine("{0}\t{1}\t{2:d}\t{3}",
                order.SalesOrderID,
                order.SalesOrderDetailID,
                order.OrderDate,
                order.ProductID);
         }

         Console.WriteLine("Hit key when ready...");
         Console.ReadKey();
      }

      static void Main(string[] args)
      {
         try
         {

            Setup(); // Read datasets from the DB
            // SelectQueries();
            // SelectManyQueries();
            // SelectPartitioning();
            // SelectOrdering();
            // SelectElementAt();  
            // SelectFirst();
            // SelectAverage();
            // SelectCount();
            // SelectSum();
            // SelectExcept();
            // SelectIntersect();
            // SelectUnion();
            // GroupJoin();
            Join();

            /*
            MyClass c = new MyClass();
            c.Method1();
            c.Method2();
            Console.ReadKey();
            */
         }
         catch (SqlException ex)
         {
            Console.WriteLine("SQL exception occurred: " + ex.Message);
         }
      }
   }
}
