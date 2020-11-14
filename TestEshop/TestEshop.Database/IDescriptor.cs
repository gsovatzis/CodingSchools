using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop.Database
{
   /// <summary>
   /// This interface represents an entity descriptor
   /// </summary>
   public interface IDescriptor
   {
      QueryDefinition QueryDef { get; }
   }

   
}
