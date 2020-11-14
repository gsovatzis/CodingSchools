using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEshop.Models;

namespace TestEshop.Database
{
   public interface IDatabaseHandler<TEntity> //, TDescriptor> 
      //where TDescriptor : IDescriptor
      where TEntity : IEntity
   {
      //TDescriptor descriptor { get; }

      void Insert(TEntity entity);  // Inserts an entity into a table
      void Delete(TEntity entity);  // Deletes an entity from a table (only Id is needed actually)
      void Update(TEntity entity);  // Updates an entity on a table
      TEntity GetById(int Id);      // Retrieves an entity from the table by Id
      List<TEntity> GetAll();       // Retrieves all entities from the table
   }

   public interface IGenericHandler
   {

   }
}
