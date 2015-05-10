using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Game.GameMode;
using Rogue_Game;
using System.Drawing;
namespace Rogue_Game.Characters
{
  public   class CrazyWhiteTiger:Character
    {



        public CrazyWhiteTiger()
            : base()
        {
            float dmgMin = randed.Instance.rand.Next(1, 15);
            float dmgMax = randed.Instance.rand.Next(50,100);
            float dodge = 0;
            int armor = 0;
            float health = randed.Instance.rand.Next(1, 20); // CHANGE 20 WITH 100;
            float mana = 0;
            magic = false;
            melee = true;
            range = false;
            Osobini Stats = new Osobini(dmgMin, dmgMax, dodge, armor, health, mana);
            fight = Combat.Instance;
            stats = Stats;
            type = "Boss";
            stats.set_maxHP(stats.health);
            stats.set_maxMP(stats.mana);

        }
        public override int get_exp()
        {
            return randed.Instance.rand.Next(3000, 8000);
        }
        public override void heal(int i, bool b)
        {
            //System.Windows.Forms.MessageBox.Show(""+this.stats.maxHealth);
            if (b)
            {
                this.stats.health = stats.maxHealth;

            }
            else
            {
                this.stats.health += i;
            }
        }
        override public bool recieve_hit(float dmg, int okolina,int type) //type : 1=melee , 2=range, 3=magic;   okolnia: 1 = tree, 2=stone;
        {
            if (randed.Instance.rand.Next(1,100) >90)
            {
                dmg = this.fight.recieve_hit(dmg, okolina, type,this.stats.armor);

                this.stats.health -= dmg;
                if (this.stats.health <= 0) return true;
            }
        return false;
        }
        override public float deal_dmg(int type)
        {            
            return this.fight.deal_damage(this.stats.dmgMin,this.stats.dmgMax,type);
        }
        override public void draw(Graphics g,Point p)
        {
           
            test = Image.FromFile(@"Resources\CrazyWhiteTiger.gif");
           bitmap = new Bitmap(test, 90, 90);
            g.DrawImage(bitmap,p);
           clean();
             
             if (fighting)
             {
                Brush brush = new SolidBrush(Color.Red);
                 Point Poin=new Point(10,70);
                 Poin.X += p.X;
                 Poin.Y += p.Y;
                 float temp= this.stats.health/this.stats.maxHealth;
                 temp*=70;
                 Size size=new Size((int)temp,15);
                g.FillRectangle(brush, new Rectangle(Poin,size));
                brush.Dispose();

             }
                
        }
       void clean()
        {
            test.Dispose();
            bitmap.Dispose();
        }
        public override void kill()
        {
            test.Dispose();
            bitmap.Dispose();
        }

    }
 
}
