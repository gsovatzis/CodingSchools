using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Models;

namespace TestEshop.Database
{
   /// <summary>
   /// Class that handles product-related query operations
   /// </summary>
   public class ProductsHandler : DatabaseHandler<Product, ProductDescriptor>
   {
      public override ProductDescriptor descriptor {
         get
         {
            return new ProductDescriptor();
         }
      }
      
      public override void Delete(Product entity)
      {
         throw new NotImplementedException();
      }

      public override List<Product> GetAll()
      {
         List<Product> products = base.GetAll();
         return products;
      }

      public override Product GetById(int Id)
      {
         Product result = base.GetById(Id);
         return result;
      }

      public override void Insert(Product entity)
      {
         base.Insert(entity);
      }

      public override void Update(Product entity)
      {
         throw new NotImplementedException();
      }
   }
}
