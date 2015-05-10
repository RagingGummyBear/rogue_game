using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Rogue_Game
{
    public class Chest
    {
        public Item item { set; get; }
        public bool oppened = false;
        static Image test;
        Bitmap bitmap;
        public Item open()
        {
            if (!oppened)
            {
                String temp = String.Format("You have recieved: " + item);
                MessageBox.Show(temp);
                oppened = true;
                return item;
            }
            else
                return null;
        }
        public void reset()
        {
            oppened = false;
        }
        public void draw(Graphics g ,Point x)
        {

            if(oppened){

                
                test = Image.FromFile(@"Resources\OChest.gif", true);
                bitmap = new Bitmap(test, 90, 90);
                g.DrawImage(bitmap, x);
                test.Dispose();
                bitmap.Dispose();
                return;
            }
            test = Image.FromFile(@"Resources\Chest.gif", true);
            bitmap = new Bitmap(test, 90, 90);
            g.DrawImage(bitmap, x);
            test.Dispose();
            bitmap.Dispose();
            return;


        }
    }
}
