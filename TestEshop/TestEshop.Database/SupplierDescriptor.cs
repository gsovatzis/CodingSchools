using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestEshop.Database
{
   public class SupplierDescriptor : IDescriptor
   {
      public QueryDefinition QueryDef
      {
         get
         {
            return XMLHelper.getDescriptor($"{Path.GetDirectoryName(this.GetType().Assembly.Location)}\\SupplierQueries.xml");
         }
      }
   }
}
