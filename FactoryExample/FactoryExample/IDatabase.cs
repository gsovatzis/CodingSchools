using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
    public interface IDatabase<T> where T : Entity
    {
        void Add(T entity);     // INSERT INTO T VALUES (...)
        bool Delete(T entity);  // DELETE FROM T WHERE ...
        bool Update(T entity);  // UPDATE T SET ...
        T FindById(string id); // SELECT * FROM T WHERE id = '?'
        T FindById(int id); // SELECT * FROM T WHERE id = ?
        List<T> GetAll();   // SELECT * FROM T
    }
}
