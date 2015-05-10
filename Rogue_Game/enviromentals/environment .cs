using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rogue_Game
{
    public abstract class environment

    {
        public static Image test;
        public Bitmap bitmap;
        public bool used=false;
        public abstract void draw(Graphics g,Point x);
        public abstract int value(); //1 tree , 2 stone, 3 hrana


    }
}
