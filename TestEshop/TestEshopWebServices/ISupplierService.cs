using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Models;

namespace TestEshop.Services
{
   [ServiceContract]
   public interface ISupplierService
   {
      [OperationContract]
      List<Supplier> GetAllSuppliers();

      [OperationContract]
      Supplier GetSupplier(int Id);

      [OperationContract]
      void InsertSupplier(Supplier p);

      [OperationContract]
      void DeleteSupplier(int Id);

      [OperationContract]
      void UpdateSupplier(Supplier p);
   }
}
