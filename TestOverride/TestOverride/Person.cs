using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverride
{
   public class Person
   {
      public virtual void myMethod()
      {
         Console.WriteLine("myMethod from Person");
      }

   }
}
