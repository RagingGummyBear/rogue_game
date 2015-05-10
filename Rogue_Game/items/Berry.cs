using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Game.items
{
    [Serializable]
    public class Berry:Item
    {
        int stack = 1;
       //Constructors
        public Berry()
            : base()
        {
            this.mValue = 100;
            this.img_Path = @"Resources\BushBerryInv.gif";
            this.requirements= new d3vector(0,0,0);
        }
        //funkcii
       override public void increment_B()
        {
            this.mValue += 100;
            stack++;
        }
       override public bool decrement_B()
        {
            if(stack> 1)
            {
                this.mValue -= 100;
                stack--;
                return false;
            }
            else
            {
            //    System.Windows.Forms.MessageBox.Show("TESTERAION ");
                this.mValue -= 100;
                stack--;
                return true;
            }
        }
        override public void draw(Graphics g,Point p)
        {
            
            
            if(selected)
            {
                Brush brush = new SolidBrush(Color.Blue);
                Point Poin = p;
            //    Poin.X += 24;
             //   Poin.Y += 22;
                Size size = new Size(48, 45);
                g.FillRectangle(brush, new Rectangle(Poin, size));
                brush.Dispose();
                Poin.X += 2;
                Poin.Y += 2;
                Image test;
                Bitmap bitmap;
                test = Image.FromFile(img_Path);
                bitmap = new Bitmap(test, 44, 41);
                g.DrawImage(bitmap, p);
                test.Dispose();
                bitmap.Dispose();
                Font drawFont = new Font("Impact", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                g.DrawString(this.stack.ToString(), drawFont, drawBrush, new Point(p.X += 10, p.Y += 25));
                drawBrush.Dispose();
                drawFont.Dispose();

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
                Font drawFont = new Font("Impact", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                g.DrawString(this.stack.ToString(), drawFont, drawBrush, new Point(p.X += 10, p.Y += 25));
                drawBrush.Dispose();
                drawFont.Dispose();
            }
            // draw vo inventoryto;
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
            Font drawFont = new Font("Impact", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(this.stack.ToString(), drawFont, drawBrush, new Point( 10, 25));
            drawBrush.Dispose();
            drawFont.Dispose();
            // draw vo inventoryto;
        }
        override public void i_draw(Graphics g)
        {
            //56.119
            Image test;
            Bitmap bitmap;
            test = Image.FromFile(img_Path);
            bitmap = new Bitmap(test, 56, 119);
            g.DrawImage(bitmap, new Point(0, 0));
            test.Dispose();
            bitmap.Dispose();
            Font drawFont = new Font("Impact", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(this.stack.ToString(), drawFont, drawBrush, new Point(10, 95));
            drawBrush.Dispose();
            drawFont.Dispose();
            // draw vo inventoryto;
        }
        override public String type()
        {
            return "Berry";
        }
        override public void effect()
        {
            //Nothing :D
        }
        public override string ToString()
        {
            return String.Format("Just a berry\n");
        }
        public override void kill()
        {
            
        }
    }
}
