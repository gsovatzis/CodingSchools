using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Models;

namespace TestEshop.Client
{
   class Program
   {
      static void Main(string[] args)
      {
         ProductServiceReference.ProductServiceClient productServiceClient = new ProductServiceReference.ProductServiceClient();
         
         /*
         List<Product> products = productServiceClient.GetAllProducts();
         foreach(Product p in products)
         {
            Console.WriteLine(p.Product_Name);
         }
                          
         Product p2 = productServiceClient.GetProduct(2);
         Console.WriteLine(p2.Product_Name);

         Product p3 = new Product { Product_Name = "AKAI", Price = 500, SKU = "AK032" };
         productServiceClient.InsertProduct(p3);
         */
         SupplierServiceReference.SupplierServiceClient supplierServiceClient = new SupplierServiceReference.SupplierServiceClient();
         //Supplier s1 = new Supplier { Supplier_Name = "SONY", Supplier_Address = "Japan" };
         //supplierServiceClient.InsertSupplier(s1);

         var x = supplierServiceClient.GetSupplier(4);
         Console.WriteLine(x.Supplier_Name);

         Console.ReadKey();
      }
   }
}
