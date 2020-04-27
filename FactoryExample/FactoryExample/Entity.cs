using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryExample
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string OwnerId { get; set; }
        public bool Deleted { get; set; }
    }
}
