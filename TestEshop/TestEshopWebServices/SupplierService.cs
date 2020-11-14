using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Database;
using TestEshop.Models;

namespace TestEshop.Services
{
   public class SupplierService : ISupplierService
   {
      public void DeleteSupplier(int Id)
      {
         throw new NotImplementedException();
      }

      public List<Supplier> GetAllSuppliers()
      {
         var handler = HandlerFactory<Supplier>.GetHandler();
         List<Supplier> result = handler.GetAll();
         return result;
      }

      public Supplier GetSupplier(int Id)
      {
         var handler = HandlerFactory<Supplier>.GetHandler();
         Supplier result = handler.GetById(Id);
         return result;
      }

      public void InsertSupplier(Supplier p)
      {
         var handler = HandlerFactory<Supplier>.GetHandler();
         handler.Insert(p);
      }

      public void UpdateSupplier(Supplier p)
      {
         throw new NotImplementedException();
      }
   }
}
