using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Models;

namespace TestEshop.Database
{
   /// <summary>
   /// This creates the appropriate database handler class based on the service that instantiates it.
   /// </summary>
   public static class HandlerFactory<TEntity> where TEntity:IEntity
   {
      public static IDatabaseHandler<TEntity> GetHandler()
      {
         string entityType = typeof(TEntity).ToString();

         switch (entityType.ToLower())
         {
            case "testeshop.models.product":
               return (IDatabaseHandler<TEntity>)new ProductsHandler();
               break;
            case "testeshop.models.supplier":
               return (IDatabaseHandler<TEntity>)new SuppliersHandler();
               break;
         }

         return null;
      }
   }
}
