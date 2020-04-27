using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
    public class DBFactory //<T> where T : Entity
    {
        private string _dbType;

        public DBFactory(string dbType)
        {
            this._dbType = dbType;
        }

        public IDatabase<T> GetDatabase<T>() where T : Entity
        {
            switch(this._dbType.ToLower())
            {
                case "mssql":
                    return new MsSQL<T>();

                case "mysql":
                    return new MySQL<T>();

                case "mongodb":
                    return new MongoDB<T>();

                default:
                    throw new Exception("Unknown database type");
            }
        }
    }
}
