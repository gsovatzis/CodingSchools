using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Models;

namespace TestEshop.Database
{
   /// <summary>
   /// Class that handles supplier-related query operations
   /// </summary>
   public class SuppliersHandler : DatabaseHandler<Supplier, SupplierDescriptor>
   {
      public override SupplierDescriptor descriptor
      {
         get
         {
            return new SupplierDescriptor();
         }
      }

      public override void Delete(Supplier entity)
      {
         throw new NotImplementedException();
      }

      public override List<Supplier> GetAll()
      {
         List<Supplier> suppliers = base.GetAll();
         return suppliers;
      }

      public override Supplier GetById(int Id)
      {
         Supplier result = base.GetById(Id);
         return result;
      }

      public override void Insert(Supplier entity)
      {
         base.Insert(entity);
      }

      public override void Update(Supplier entity)
      {
         throw new NotImplementedException();
      }
   }
}
