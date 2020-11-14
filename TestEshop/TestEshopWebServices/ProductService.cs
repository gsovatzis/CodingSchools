using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestEshop.Models;
using TestEshop.Database;

namespace TestEshop.Services
{
   public class ProductService : IProductService
   {
      public void DeleteProduct(int Id)
      {
         throw new NotImplementedException();
      }

      public List<Product> GetAllProducts()
      {
         var handler = HandlerFactory<Product>.GetHandler();

         List<Product> result = handler.GetAll();
         return result;
      }

      public Product GetProduct(int Id)
      {
         var handler = HandlerFactory<Product>.GetHandler();
         Product result = handler.GetById(Id);
         return result;
      }

      public void InsertProduct(Product p)
      {
         var handler = HandlerFactory<Product>.GetHandler();
         handler.Insert(p);
      }

      public void UpdateProduct(Product p)
      {
         throw new NotImplementedException();
      }
   }
}
