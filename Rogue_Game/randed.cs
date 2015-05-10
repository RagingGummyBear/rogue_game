using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Game
{
    class randed
    {
      public Random rand { set; get; }
      private static randed instance;

       private randed()
       {

           rand = new Random();
        }

       public static randed Instance
   {
      get 
      {
         if (instance == null)
         {
             instance = new randed();
         }
         return instance;
      }
   }
    }
}
