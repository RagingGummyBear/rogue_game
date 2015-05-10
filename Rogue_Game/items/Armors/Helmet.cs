using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Game.items.Armors
{
    [Serializable]
    public class Helmet : Item
    {

        //Constructors
        public Helmet(String Name, d3vector Requirements, Osobini Bonus, int mValue, int value, String img)
            : base(Name, Requirements, Bonus, mValue, value, img)
        {

        }
        //funkcii
        public override void kill()
        {
            //  test.Dispose();
            // bitmap.Dispose();
        }
        override public void draw(Graphics g,Point p)
        {
            if (selected)
            {
                Brush brush = new SolidBrush(Color.Blue);
                Point Poin = p;
                // Poin.X += 24;
                //  Poin.Y += 22;
                Size size = new Size(48, 45);
                g.FillRectangle(brush, new Rectangle(Poin, size));
                brush.Dispose();
                Poin.X += 4;
                Poin.Y += 4;
                Image test;
                Bitmap bitmap;
                test = Image.FromFile(img_Path);
                bitmap = new Bitmap(test, 40, 37);
                g.DrawImage(bitmap, Poin);
                test.Dispose();
                bitmap.Dispose();
            }
            else
            {
                Image test;
                Bitmap bitmap;
                test = Image.FromFile(img_Path);
                bitmap = new Bitmap(test, 48, 45);
                g.DrawImage(bitmap, p);
                test.Dispose();
                bitmap.Dispose();
            }
        }
        override public void draw(Graphics g)
        {
            Image test;
            Bitmap bitmap;
            test = Image.FromFile(img_Path);
            bitmap = new Bitmap(test, 48, 45);
            g.DrawImage(bitmap, new Point(0, 0));
            test.Dispose();
            bitmap.Dispose();
            // draw vo inventoryto;
        }
        public override bool decrement_B()
        {
            return false;
        }
        public override void increment_B()
        {
            //throw new NotImplementedException();
        }
        override public void i_draw(Graphics g)
        {
            Image test;
            Bitmap bitmap;
            //56.119
            test = Image.FromFile(img_Path);
            bitmap = new Bitmap(test, 65, 45);
            g.DrawImage(bitmap, new Point(0, 0));
            test.Dispose();
            bitmap.Dispose();
            // draw vo inventoryto;
        }
        override public String type()
        {
            return "helmet";
        }
        override public void effect()
        {
            //Nothing :D
        }
        public override string ToString()
        {
            return String.Format("{9} Helmet\nRequirements: Str {0} Dex {1} Int {2}\n\tBonus:\n Attack Min: {3}\nAttack Max:{4}\nDodge: {5}\nArmor:{6}\nHealth: {7}\nMana: {8}\n", requirements.x, requirements.y, requirements.z, bonus.dmgMin, bonus.dmgMax, bonus.dodge, bonus.armor, bonus.health, bonus.mana, name);
        }
    }
}
