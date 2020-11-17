using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverride
{
   public class Hawk : Bird, IFlyable
   {
      public override void eat()
      {
         Console.WriteLine("Hawk is flying");
      }
      
      public void fly()
      {
         Console.WriteLine("Bird is eating");
      }

   }
}
