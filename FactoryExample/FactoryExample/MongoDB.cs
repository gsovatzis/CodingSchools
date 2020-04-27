using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
    public class MongoDB<T> : IDatabase<T> where T : Entity
    {
        
        public void Add(T entity)
        {
            Console.WriteLine($"Adding entity {entity.ToString()} to MongoDB...");
        }

        public bool Delete(T entity)
        {
            Console.WriteLine($"Deleting entity {entity.ToString()} from MongoDB...");
            return true;
        }

        public T FindById(string id)
        {
            Console.WriteLine($"Finding MongoDB entity with id {id}");
            return null;
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            Console.WriteLine("Getting all MongoDB entity records...");
            return null;
        }

        public bool Update(T entity)
        {
            Console.WriteLine($"Updating MongoDB entity {entity.ToString()}...");
            return true;
        }
    }
}
