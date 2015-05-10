using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rogue_Game
{
    [Serializable]
    public class d3vector
    {
        public float x { set; get; }
        public float y { set; get; }
        public float z { set; get; }
        public  d3vector(int i, int w, int q)
        {
            x = i;
            y = w;
            z = q;
        }
        public d3vector()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public override string ToString()
        {

            return String.Format("Str: {0}   Dex: {1}   Int: {2} \n",x,y,z);
        }
    }
}
