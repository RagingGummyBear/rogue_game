using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Game.GameMode;

namespace Rogue_Game.Characters
{
    public class Merchant:Character
    {

        Fabrika fact = Fabrika.Instance;

        public Merchant()
            : base()
        {
            float dmgMin = randed.Instance.rand.Next(5, 11);
            float dmgMax = randed.Instance.rand.Next(15, 26);
            float dodge = randed.Instance.rand.Next(0, 7);
            int armor = randed.Instance.rand.Next(15, 36);
            float health = randed.Instance.rand.Next(80, 101);
            float mana = 0;
           
            magic = false;
            melee = false;
            range = false; // true just for testing;
            stats = new Osobini(dmgMin, dmgMax, dodge, armor, health, mana);
            if (lista == null) lista = new List<Item>();
            else
                lista.Clear();
            for (int i = 0; i < 19;i++ )
            {
                this.lista.Add(fact.create_MercItem());
            }
            this.lista.Add(fact.create_Berries(10));
            type = "Merchant";
            stats.set_maxHP(stats.health);
            stats.set_maxMP(stats.mana);

        }
        public override int get_exp()
        {
            return 0;
            //throw new NotImplementedException();
        }
        public override void heal(int i, bool b)
        {
            System.Windows.Forms.MessageBox.Show(""+this.stats.maxHealth);
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
            /*Random rand=new Random();
            if (rand.NextDouble() * 100 > ((float)this.stats.dodge * 1.5) / (100 + this.stats.dodge * 1.5))
            {
                dmg = this.fight.recieve_hit(dmg, okolina, type,this.stats.armor);

                this.stats.health -= dmg;
                if (this.stats.health <= 0) return true;
            }*/
        return false;
        }

        override public float deal_dmg(int type)
        {            
          //  return this.fight.deal_damage(this.stats.dmgMin,this.stats.dmgMax,type);
            return 0;
        }
        override public void draw(Graphics g,Point p)
        {
            test = Image.FromFile(@"Resources\Merchant.gif");
           bitmap = new Bitmap(test, 90, 90);
            g.DrawImage(bitmap,p);
            clean();
        }
        public void show_Items()
        {

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
