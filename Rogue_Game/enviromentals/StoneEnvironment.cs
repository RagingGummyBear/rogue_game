using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Rogue_Game.enviromentals
{
    class StoneEnvironment: environment
    {
        override public void draw(Graphics g,Point x)
        {
            test = Image.FromFile(@"Resources\Rock.gif");
            bitmap = new Bitmap(test, 90, 90);
            g.DrawImage(bitmap, x);
            test.Dispose();
            bitmap.Dispose();
        }
        public override string ToString()
        {
            return String.Format("Stone environment");
        }
        override public int value() //1 tree , 2 stone, 3 hrana
        {
            return 2;
        }
    }
}
