using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestEshop.Models;

namespace TestEshop.Services
{
   [ServiceContract]
   public interface IProductService
   {
      [OperationContract]
      List<Product> GetAllProducts();

      [OperationContract]
      Product GetProduct(int Id);

      [OperationContract]
      void InsertProduct(Product p);

      [OperationContract]
      void DeleteProduct(int Id);

      [OperationContract]
      void UpdateProduct(Product p);

   }
        
}
