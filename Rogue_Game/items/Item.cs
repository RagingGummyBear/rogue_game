using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Game
{
        [Serializable]
    public abstract class Item
    {
       //public static Image test;
       //public Bitmap bitmap;
            public bool selected = false;
          public  String name;
        public int mValue;
        public int value;
        public d3vector requirements; // str dex int
        public Osobini bonus; // atk dodge mana hp armor
        public String img_Path;
        //constructor
        public Item(String Name, d3vector Requirements, Osobini Bonus,int mValue,int value,String img)
        {
            this.img_Path = img;
            this.value = value;
            this.mValue = mValue;
            this.equiped = false;
            name = Name;
            requirements = Requirements;
            bonus = Bonus;

        }
        public Item()
        {
            equiped = false;
            name = "";
            requirements = null;
            bonus = null;
        }
        public abstract bool decrement_B();
        public abstract void increment_B();
        public abstract void kill();
        public bool equiped { set; get; }
        public abstract void draw(Graphics g);
        public abstract void draw(Graphics g,Point p);
        public abstract String type();
        public abstract void effect();
        public abstract void i_draw(Graphics g);
        //public abstract d3vector requirements();
       // public abstract d3vector bonus();
    }
}
