using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop.Models
{
   public class Category : BaseTable
   {
      public int Id { get; set; }
      public string Category_Name { get; set; }
      public Category ParentCategory { get; set; }
   }
}
