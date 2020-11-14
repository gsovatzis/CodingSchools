using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop.Models
{
   public class Supplier : BaseTable
   {
      public int Id { get; set; }
      public string Supplier_Name { get; set; }
      public string Supplier_Address { get; set; }
   }
}
