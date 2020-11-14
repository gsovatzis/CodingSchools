using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop.Models
{
    public class Product : BaseTable
    {
      public int Id { get; set; }
      public string SKU { get; set; }
      public string Product_Name { get; set; }
      public Supplier Supplier { get; set; }
      public List<Category> Categories { get; set; }
      public decimal Price { get; set; }

      public Product()
      {
         this.Categories = new List<Category>();   // Initialize list on object construction
      }
    }
}
