using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverride
{
   class Duck : Bird, ISwimmable
   {
      public override void eat()
      {
         throw new NotImplementedException();
      }

      public void swim()
      {
         throw new NotImplementedException();
      }
   }
}
