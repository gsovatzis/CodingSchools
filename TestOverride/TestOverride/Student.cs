using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverride
{
   public class Student : Person
   {
      public new void myMethod()
      {
         Console.WriteLine("myMethod from Student");
      }
   }
}
