using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop.Models
{
   public abstract class BaseTable : IEntity
   {
      public string CreatedBy { get; set; }
      public string UpdatedBy { get; set; }
      public DateTime DateCreated { get; set; }
      public DateTime DateUpdated { get; set; }
            
   }
}
