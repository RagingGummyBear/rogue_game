﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Game.GameMode;
using Rogue_Game;
using System.Drawing;

namespace Rogue_Game.Characters
{
    class BerserkerOrc:Character
    {



        public BerserkerOrc()
            : base()
        {
            float dmgMin = randed.Instance.rand.Next(5, 11);
            float dmgMax = randed.Instance.rand.Next(40,65);
            float dodge = randed.Instance.rand.Next(10, 35);
            int armor = randed.Instance.rand.Next(15, 36);
            float health = randed.Instance.rand.Next(350, 460);
            float mana = 0;
            magic = false;
            melee = true;
            range = false;
            Osobini Stats = new Osobini(dmgMin, dmgMax, dodge, armor, health, mana);
            fight = Combat.Instance;
            stats = Stats;
            type = "BerserkerOrc";
            stats.set_maxHP(stats.health);
            stats.set_maxMP(stats.mana);


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
            Random rand=new Random();
            if (rand.NextDouble() * 100 > ((float)this.stats.dodge * 1.5) / (100 + this.stats.dodge * 1.5))
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

            test = Image.FromFile(@"Resources\BerserkerOrc.gif");
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
        public override int get_exp()
        {
            return randed.Instance.rand.Next(250, 500);
            //throw new NotImplementedException();
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
