using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Game.GameMode;

namespace Rogue_Game
{
public abstract class Character
    {

    public List<Item> lista = new List<Item>();
       public static Image test;
        public Bitmap bitmap;
    public Combat fight;
       public Point mesto;
       public String type { set; get; }
       public bool fighting = false;
     /*  public float damageMin { set; get; }
       public float damageMax { set; get; }
       public float dodge { set; get; }
       public float health { set; get; }
       public float mana { set; get; }
       public int armor { set; get; }*/
       public  Osobini stats;
       public bool magic { set; get; }
       public bool melee { set; get; }
       public bool range { set; get; }
   public Character()
       {
      // stats = new Osobini(DamageMin,DamageMax,Dodge,Armor,Health, Mana);

       }
    public void get_mesto(Point p)
   {
       mesto = p;
   }

    public abstract int get_exp();
    public abstract void heal(int i, bool b);
       public abstract bool recieve_hit(float dmg,int okolina, int type);
       public abstract float deal_dmg(int type);
       public abstract void draw(Graphics g, Point p);
       public abstract void kill();
    }
}
