using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Game.items;
using Rogue_Game.GameMode;

namespace Rogue_Game
{
    public class Block
    {
       // static Image test = Image.FromFile("F:/workplace/VisualStudio/Rogue_Game/Rogue_Game/Resources/BlockTest");
      // public static Image test;
       // Bitmap bitmap = new Bitmap(test, 90, 90);
       // Bitmap bitmap;
        Fabrika fact = Fabrika.Instance;
        //location
        //public Point location;
        //sodrzina
        public environment priroda {set;get;}
        public Chest kovceg {set;get;}
        public Character npc { set; get; }
        public bool changeable = true;
        //constructars
       public Block()
        {
          
           /*
            priroda = fact.create_Environment();
            kovceg = fact.create_chest();
            npc = fact.create_Character();
           */
            
        }
        public  Block(environment e,Chest c,Character ch)
        {
            this.priroda = e;
            this.kovceg = c;
            this.npc = ch;
        }
        //funkcii
        public void draw (Graphics g,int x,int y)
        {
           Point p = new Point(x * 90, y * 90);
             //test = Image.FromFile(@"Resources\ground.png");
            //bitmap = new Bitmap(test, 90, 90);
          // g.DrawImage(bitmap,p);
           
           if(priroda!=null) priroda.draw(g,p);
           if(kovceg!=null) kovceg.draw(g,p);
           if(npc!=null) npc.draw(g,p);
          // test.Dispose();
           //bitmap.Dispose();
        }
        public void kill_npc()
        {
            if(npc!=null)npc.kill();
            npc=null;

        }
        public Item open_Chest()
        {
            if (kovceg != null)
            {
                return kovceg.open();
            }
            else
                return null;
        }

       public void show_Content()
        {
            StringBuilder sb = new StringBuilder();
           if(priroda!=null)
           {
               sb.Append(String.Format("{0}\n", priroda.ToString()));
           }
           if(kovceg!=null)
           {
               sb.Append(String.Format("Chest\n"));
           }
           if (npc != null)
           {
               sb.Append(String.Format("Npc: {0}", npc.type));
           }
           System.Windows.Forms.MessageBox.Show(sb.ToString());
        }

    }
        
}
