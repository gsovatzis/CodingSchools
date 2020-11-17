using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverride
{
   public class Chicken : Bird
   {
      public override void eat()
      {
         throw new NotImplementedException();
      }

   }
}
