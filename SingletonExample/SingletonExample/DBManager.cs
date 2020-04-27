using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonExample
{
    // We create a sealed class so that it cannot be sub-classed
    public sealed class DBManager
    {

        private static DBManager _instance;
        private static readonly object padlock = new object();  // This is just a "lock" object to achieve thread-safety
        private Guid gid = Guid.NewGuid(); 

        DBManager()
        {
            // private constructor: Cannot directly create objects for this class
        }

        /// <summary>
        /// This is where the singleton work is done!
        /// </summary>
        public static DBManager instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)  // This prevents any other thread from getting a new instance of our singleton
                    {
                        if (_instance == null)
                        {
                            _instance = new DBManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public string getId()
        {
            return this.gid.ToString();
        }

        public bool getConnection()
        {
            Console.WriteLine("I am getting a DB connection from the pool...");
            return true;    // Normally we would return a connection object and not bool
        }

        public void disconnect()
        {
            Console.WriteLine("I am disconnecting from the DB...");
        }

    }
}
