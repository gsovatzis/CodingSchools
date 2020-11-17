using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverride
{
   class Program
   {
      static void Main(string[] args)
      {
         Person p = new Person();
         p.myMethod();

         Student s = new Student();
         s.myMethod();

         Person ps = new Student();
         ps.myMethod();

         List<Bird> birds = new List<Bird>();
         birds.Add(new Hawk());
         birds.Add(new Chicken());
         birds.Add(new Duck());

         foreach(var bird in birds) {
            //if(bird.GetType().Equals(typeof(Hawk)))
            if(typeof(IFlyable).IsAssignableFrom(bird.GetType()))
            {
               var x = (IFlyable)bird;
               x.fly();
            }
            else
            {
               Console.WriteLine("this bird cannot fly");
            }
         }
         


         Console.ReadKey();

      }
   }
}
