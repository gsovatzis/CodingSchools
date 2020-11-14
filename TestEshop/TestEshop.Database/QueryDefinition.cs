using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop.Database
{
   public class QueryDefinition
   {
      public List<Query> Queries { get; set; }
   }

   public class Query
   {
      public string QueryName { get; set; }
      public string SQLQuery { get; set; }
      public List<QueryParameter> QueryParameters { get; set; }
   }

   public class QueryParameter
   {
      public string Name { get; set; }
      public string Type { get; set; }
   }
}
