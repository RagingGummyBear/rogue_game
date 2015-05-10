using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Rogue_Game.GameMode
{
    public class MainCharacter
    {
      private static MainCharacter instance;
      public static bool extra_exp = true;
        private MainCharacter() {
            for (int i = 0; i < 4; i++)
                for (int y = 0; y < 5;y++ )
                {
                    this.inventory[i, y] = null;
                }

                    this.location = new Point(360, 360);
            fighting = false;

        }

        public static MainCharacter Instance
   {
      get 
      {
         if (instance == null)
         {
             instance = new MainCharacter();
         }
         return instance;
      }
   }
        //new game
       /* public MainCharacter()
        {

        }*/
        //load game
        public void allSet(int level,int level_progress,Point Location,d3vector Stats,Item[,] Inventory,Equipment Equip,int unused,int Gold,int health)
        {

            this.level = level;
            this.level_Progress = level_progress;
            this.location = Location;
            this.stats = Stats;
            this.inventory = Inventory;
            this.equipment = Equip;
            this.unused_Stats = unused;
            this.gold=Gold;
            this.level_up_exp = 100 * stepen(level);
            this.calculate_bonus();
            this.heal(100, true);
            this.bonuses.health = 0;
            this.heal(health, true);
        }

        /// <summary>
        /// OSOBINI ?!
        /// </summary>
        //
        public bool has_berry = false;
        public bool should_Invalidate_All = false;
        public bool upgrade_items=false;
        public bool fighting { set; get; }
        //mom pozicija
        public Point location;  //HARDCODING JUST FOR TESTING MEASSURES ;

        //Site itemi
       public   Item[,] inventory = new Item[4,5];
       public Equipment equipment = new Equipment();
       //Bonus stats (se dobivaat od itemi i d3vector Stats)
      public  Osobini bonuses;
        //actual stats i level
      public int gold;
       public d3vector stats { set; get; }//1.strength 2.dexterity 3.intelligence
      public int level { set; get; }
      public int level_Progress { get; set; }
      public int level_up_exp { get; set; }
      public int unused_Stats;
        //Za crtanje
      static Image test;
      Bitmap bitmap;
      public bool dead=false;
      public bool switchimg=true;



       //Fight

       Combat fight = Combat.Instance;

       //funkcii
        public bool equip(Item i)
       {
           if ((i.requirements.x > stats.x || i.requirements.y > stats.y || i.requirements.z > stats.z))
           {
               MessageBox.Show("Check stat requirements");
               return true;
           }
             if(i.type()=="Berry")
             {
                 this.heal(40, false);
                 if(i.decrement_B())
                 {
                     this.has_berry = false;
                     return false;
                 }
                 else
                 {
                     this.add_Item(i);
                     return false;
                 }
             }
          
            else if(i.type()=="sword")
            {
                if (equipment.right_hand != null)
                {
                    if(equipment.left_hand!=null)
                    {
                        Equip forma = new Equip();
                        forma.item = i;
                        DialogResult dr = forma.ShowDialog();
                       // System.Windows.Forms.DialogResult pom=System.Windows.Forms.MessageBox.Show("Do you want to equip the weapon to your right hand?","Equip weapon dilema",System.Windows.Forms.MessageBoxButtons.YesNoCancel);
                       if(dr==System.Windows.Forms.DialogResult.Yes)
                       {
                           Item temp = equipment.right_hand;
                           equipment.right_hand = i;
                           add_Item(temp);
                       }
                       else if (dr == System.Windows.Forms.DialogResult.No && equipment.right_hand.type() != "greatsword")
                       {
                           Item temp = equipment.left_hand;
                           equipment.left_hand = i;
                           add_Item(temp);
                       }
                       else
                       {
                           return true;
                       }

                    }
                    //Item temp = equipment.left_hand;
                    if (equipment.right_hand.type() != "greatsword") equipment.left_hand = i;
                    else return true;
                   // add_Item(temp);
                }
                else
                {
                    equipment.right_hand = i;
                }
            }
            if (i.type() == "chest")
            {
                if (equipment.chest != null)
                {
                    Item temp = equipment.chest;
                    equipment.chest = i;
                    add_Item(temp);
                }
                else
                {
                    equipment.chest = i;
                }
            }
            if (i.type() == "helmet")
            {
                if (equipment.helmet != null)
                {
                    Item temp = equipment.helmet;
                    equipment.helmet = i;
                    add_Item(temp);
                }
                else
                {
                    equipment.helmet = i;
                }
            }
            if (i.type() == "shoulders")
            {
                if (equipment.shoulders != null)
                {
                    Item temp = equipment.shoulders;
                    equipment.shoulders = i;
                    add_Item(temp);
                }
                else
                {
                    equipment.shoulders = i;
                }
            }
            if (i.type() == "gloves")
            {
                if (equipment.gloves != null)
                {
                    Item temp = equipment.gloves;
                    equipment.gloves = i;
                    add_Item(temp);
                }
                else
                {
                    equipment.gloves = i;
                }
            }
            if (i.type() == "legs")
            {
                if (equipment.legs != null)
                {
                    Item temp = equipment.legs;
                    equipment.legs = i;
                    add_Item(temp);
                }
                else
                {
                    equipment.legs = i;
                }
            }
            if (i.type() == "boots")
            {
                if (equipment.boots != null)
                {
                    Item temp = equipment.boots;
                    equipment.boots = i;
                    add_Item(temp);
                }
                else
                {
                    equipment.boots = i;
                }
            }
          
            if (i.type() == "bow")
            {
                if (equipment.right_hand != null)
                {
                      Item temp = equipment.right_hand;
                      equipment.right_hand = i;
                      add_Item(temp);
                }
                else
                {
                    equipment.right_hand = i;
                }
            }
            if (i.type() == "shield")
            {
                if (equipment.left_hand != null && equipment.right_hand.type()!="greatsword")
                {
                    Item temp = equipment.left_hand;
                    equipment.left_hand = i;
                    add_Item(temp);
                }
                else
                {
                    if (equipment.right_hand != null) if (equipment.right_hand.type() != "greatsword") equipment.left_hand = i;
                        else return true;
                    else
                    {
                        equipment.left_hand = i;
                    }
                }
            }
            if (i.type() == "greatsword")
            {
                if (equipment.right_hand != null)
                {

                    int counta = 0;
                    for(int w=0;w<4;w++)
                        for(int y=0;y<5;y++)
                        {
                            if(this.inventory[w,y]==null)
                            {
                                counta++;
                            }
                        }
                    if (equipment.left_hand != null) if (counta < 2) return true;
                    Item temp = equipment.right_hand;
                    add_Item(temp);
                    if (equipment.left_hand != null)
                    {
                        this.add_Item(equipment.left_hand);
                        equipment.left_hand = null;
                    }
                    equipment.right_hand = i;
                   
                }
                else
                {
                    if (equipment.left_hand != null)
                    {
                        if (this.add_Item(equipment.left_hand)) return true ;
                        equipment.left_hand = null;
                    }
                    equipment.right_hand = i;
                }
                
            }
            this.calculate_bonus();
            return false;
            
       }
        public void use_Berry()
        {
            for(int i=0;i<4;i++)
            {
                for(int y=0;y<5;y++)
                {
                    if (inventory[i, y] != null && inventory[i, y].type() == "Berry")
                    {
                        Item z = inventory[i, y];
                        inventory[i, y] = null;
                        equip(z);
                    }
                }
            }
        }

        public bool add_Item(Item z)
       {
           this.should_Invalidate_All = true;
           if (z == null) return false;
            if (z.type() == "Berry") if (this.has_berry)
                for (int i = 0; i < 4; i++)
                    for (int y = 0; y < 5; y++)
                    {
                        if (this.inventory[i, y]!=null)if (this.inventory[i, y].type() == "Berry")
                        {
                            this.inventory[i, y].increment_B();
                            //MessageBox.Show(inventory[i, y].ToString());
                            return false;
                        }
                    }
                
            if (z.type() == "Berry") this.has_berry = true;
           for (int i = 0; i < 4; i++)
               for (int y = 0; y < 5;y++ )
               {
                   if (this.inventory[i, y] == null)
                   {
                       this.inventory[i, y] = z;
                       return false;
                   }
               }
           if (z.type() == "Berry") this.has_berry = false;
             System.Windows.Forms.MessageBox.Show("Inventory Full");
             return true;
       }

       

        public void kill()
       {
           System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Sounds\dundundun.wav");
          //player.Play();
           player.Play();
            System.Windows.Forms.MessageBox.Show("You died");
           dead = true;
       }


        public void move_Up(bool t)
       {
           if (t) location.Y -= 90;
       }
        public void move_Down(bool t)
        {
            if (t) location.Y += 90;
        }
        public void move_Left(bool t)
        {
            if (t) location.X -= 90;
        }
        public void move_Right(bool t)
        {
            if (t) location.X += 90;
        }
       public bool recieve_hit(float dmg, int okolina, int type) //type : 1=melee , 2=range, 3=magic;   okolnia: 1 = tree, 2=stone;
       {
           Random rand = new Random();
           if (rand.NextDouble() * 100 > ((float)this.bonuses.dodge * 1.5) / (100 + this.bonuses.dodge * 1.5))
           {
               dmg = this.fight.recieve_hit(dmg, okolina, type, this.bonuses.armor);

               this.bonuses.health -= dmg;
               if(Combat.combat_log)System.Windows.Forms.MessageBox.Show(bonuses.health + " your health after hit");
               if (this.bonuses.health <= 0) return true;
           }
           return false;
       }
       public float deal_dmg(int type)
       {
           return this.fight.deal_damage(this.bonuses.dmgMin, this.bonuses.dmgMax, type);
       }
        int stepen(int a)
       {
           double temp=1;
           for (int i = 0; i < a; i++)
           {
               temp *= 1.2;
           }
            return (int)temp;
       }
        public bool add_Exp(int pom)
       {
           int temp = 0;
          if(extra_exp) pom *= 10; // za testiranje
            if(level== 50)return false;

            level_Progress += pom;
            //MessageBox.Show("First");
            if (level_Progress >= level_up_exp)
            {
              //  MessageBox.Show("Second");
                //MessageBox.Show(level_Progress.ToString());
                while (level_Progress >= level_up_exp)
                {
                    temp++;
                    level_Progress -= level_up_exp;
                    level_up_exp = stepen(level + temp) * 100;
                }
                level += temp;

            }
            else {
             //   MessageBox.Show("Third");
                return false;
                }
            if (temp > 0) {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Sounds\level up.wav");
                //player.Play();
                player.Play();
                if(level>20)
                {
                    this.upgrade_items = true;
                }
                else 
                    if(level>11)
                    {
                        //MessageBox.Show("GUESS WHAT?");
                        this.upgrade_items = true;
                    }

               this.level_up_exp = 100 * stepen(level);
                this.heal(100, true);
                this.unused_Stats += temp*3;
                LevelUp up = new LevelUp();
                if(up.ShowDialog()==DialogResult.OK)
                {
                    this.stats = up.stats;
                    this.unused_Stats = up.unused;
                    should_Invalidate_All = true;
                }
               // System.Windows.Forms.MessageBox.Show("You leveled up, your level_progress: " + level_Progress);
                return true;
            }
            return false;
       }

        public void heal(int i,bool b)
        {
            if(b)
            {
                this.bonuses.health += (this.bonuses.maxHealth* (float)i / 100);
                if (bonuses.health > bonuses.maxHealth) bonuses.health = bonuses.maxHealth;
               
            }
            else
            {
                this.bonuses.health += i;
                if (bonuses.health > bonuses.maxHealth) bonuses.health = bonuses.maxHealth;
            } 
        }

        public void calculate_bonus() // IMA GOLEMA POTREBA OD BALANSIRANJE !!!!!
       {
           level_up_exp = 100 * stepen(level);
            float str= this.stats.x;
            float dex =this.stats.y;
            float intel= this.stats.z;
            Osobini pom = this.equipment.get_Stats();

            //Osobini pom = new Osobini();
            //Str bonusi 1 str= 0.6 max dmg, 0.2 min/max dmg,1.2 armor,3 health
            pom.health += str * 3;
            pom.dmgMax += (int)(str / 5) * 3;
            if(!(str%5==0))
            {
                if (str % 5 > 2) pom.dmgMax += 2;
                else pom.dmgMax++;
            }
            pom.dmgMax += (int)(str / 5);
            pom.dmgMin += (int)(str / 5);
            pom.armor += ((int)str + (int)(str / 5));

           //Dex bonusi   1 dex = 0.5 dodge , 0.5 armor , 1 min/max dmg,1.5 hp
            pom.dmgMax += (int)(dex);
            pom.dmgMin += (int)(dex);
            pom.health += ((int)dex + ((int)dex / 2));
            pom.armor += (int)(dex / 2);
            pom.dodge += (int)(dex / 2);

           //Int Bonusi  1 int = 5 mana,2.75 hp,0.5 min/max dmg,0.5 armor;
            pom.mana += (int)(5 * intel);
            pom.health += ((int)(2 * intel) + (int)(intel / 4));
            pom.dmgMax += (int)(intel / 2);
            pom.dmgMin += (int)(intel / 2);
            pom.armor += (int)(intel / 2);
            //nesto?
            pom.set_maxHP(pom.health);
            pom.set_maxMP(pom.mana);
            //moment of truth;
           if(bonuses==null) bonuses = pom;
           else
           {
             //  System.Windows.Forms.MessageBox.Show(bonuses.health + " your health pre check");// ima tuka greshka
               bonuses.health = bonuses.health * (pom.maxHealth / this.bonuses.maxHealth);      
               bonuses.set_maxHP(pom.maxHealth);
               bonuses.mana =bonuses.mana * (pom.maxMana / this.bonuses.maxMana);
               bonuses.set_maxMP(pom.maxMana);
               bonuses.armor=pom.armor;
               bonuses.dmgMax=pom.dmgMax;
               bonuses.dmgMin=pom.dmgMin;
               bonuses.dodge = pom.dodge;
           }

        //   System.Windows.Forms.MessageBox.Show(bonuses.health + " your health");
       }


        //DRAWLER
        public void draw(Graphics g)
        {
            if (dead)
            {
                if (switchimg)
                {
                    test = Image.FromFile(@"Resources\fire.gif");
                    bitmap = new Bitmap(test, 90, 90);
                    // System.Windows.Forms.MessageBox.Show("My message here");
                    g.DrawImage(bitmap, location);
                    test.Dispose();
                    bitmap.Dispose();
                }
                else
                {
                    test = Image.FromFile(@"Resources\fire.gif");
                    bitmap = new Bitmap(test, 90, 70);
                    Point p = new Point(location.X,location.Y+20);
                    // System.Windows.Forms.MessageBox.Show("My message here");
                    g.DrawImage(bitmap, p);
                    test.Dispose();
                    bitmap.Dispose();
                }

            }

            else
            {
                test = Image.FromFile(@"Resources\Main.gif");
                bitmap = new Bitmap(test, 90, 90);
                // System.Windows.Forms.MessageBox.Show("My message here");
                g.DrawImage(bitmap, location);
                test.Dispose();
                bitmap.Dispose();
                if (fighting)
                {
                    Brush brush = new SolidBrush(Color.Red);
                    Point Poin = new Point(10, 70);
                    Poin.X += this.location.X;
                    Poin.Y += this.location.Y;
                    float temp = this.bonuses.health / this.bonuses.maxHealth;
                    temp *= 70;
                    Size size = new Size((int)temp, 15);
                    g.FillRectangle(brush, new Rectangle(Poin, size));
                    brush.Dispose();
                }
            }

        }


    }

}
