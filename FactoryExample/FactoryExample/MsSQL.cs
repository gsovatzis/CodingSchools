using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
    public class MsSQL<T> : IDatabase<T> where T : Entity
    {
        
        public void Add(T entity)
        {
            Console.WriteLine($"Adding entity {entity.ToString()} to Microsoft SQL Server...");
        }

        public bool Delete(T entity)
        {
            Console.WriteLine($"Deleting entity {entity.ToString()} from Microsoft SQL Server...");
            return true;
        }

        public T FindById(string id)
        {
            Console.WriteLine($"Finding Microsoft SQL Server entity with id {id}");
            return null;
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            Console.WriteLine("Getting all Microsoft SQL Server entity records...");
            return null;
        }

        public bool Update(T entity)
        {
            Console.WriteLine($"Updating Microsoft SQL Server entity {entity.ToString()}...");
            return true;
        }
    }
}
