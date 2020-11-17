using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
   public class Oracle<T> : IDatabase<T> where T: Entity
   {
      public void Add(T entity)
      {
         throw new NotImplementedException();
      }

      public bool Delete(T entity)
      {
         throw new NotImplementedException();
      }

      public T FindById(string id)
      {
         throw new NotImplementedException();
      }

      public T FindById(int id)
      {
         throw new NotImplementedException();
      }

      public List<T> GetAll()
      {
         throw new NotImplementedException();
      }

      public bool Update(T entity)
      {
         throw new NotImplementedException();
      }
   }
}
