using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rogue_Game.enviromentals
{
    class TreeEnvironment:environment
    {
        
       
        override public void draw(Graphics g ,Point x)
        {
            test = Image.FromFile(@"Resources\tree.gif");
            bitmap = new Bitmap(test, 90, 90);
            g.DrawImage(bitmap, x);
            test.Dispose();
            bitmap.Dispose();
        }
        public override string ToString()
        {
            return String.Format("Tree environment");
        }
        override public int value() //1 tree , 2 stone, 3 hrana
        {
            return 1;
        }
    }
}
