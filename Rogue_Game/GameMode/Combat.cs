using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Game.GameMode
{
    public class Combat
    {
        Character enemy;
        public static bool combat_log = true;
       public Block enems;
        Block glavs;
      //  MainCharacter glavno = MainCharacter.Instance;
        private static Combat instance;

   private Combat() {}

   public static Combat Instance
   {
      get 
      {
         if (instance == null)
         {
            instance = new Combat();
         }
         return instance;
      }
   }
   public void start_fight(Block pom1,Block pom2,MainCharacter glavno)
   {
       System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Sounds\duelstart.wav");
       player.Play();
       enemy = pom1.npc;
       enemy.fighting = true;
       enems = pom1;
       glavs = pom2;
       glavno.fighting = true;

   }
    public bool exchange_Hits(MainCharacter glavno)
   {
       int pom1, pom2;
       System.Media.SoundPlayer player=new System.Media.SoundPlayer(@"Sounds\hit exchange.wav");
       player.Play();
        
       float m, e;
        glavno.calculate_bonus();
        if(glavno.equipment.right_hand!=null)if (glavno.equipment.right_hand.type() == "Bow")
        {
            pom1 = 2;
            m = glavno.deal_dmg(2);
        }
        else if (glavno.equipment.right_hand.type() == "Staff")
        {
            pom1 = 3;
            m = glavno.deal_dmg(3);
        }
        else
        {
            pom1 = 1;
            m = glavno.deal_dmg(1);
        }
        else
        {
            pom1 = 1;
            m = glavno.deal_dmg(1);
        }

        if (enemy.range)
        {
            pom2 = 2;
            e = enemy.deal_dmg(2);
        }
        else if (enemy.magic)
        {
            pom2 = 3;
            e = enemy.deal_dmg(3);
        }
        else
        {
            pom2 = 1;
            e = enemy.deal_dmg(1);
        }
        int mE=0, eE=0;
        if (enems.priroda != null) eE = enems.priroda.value();
        if (glavs.priroda != null) mE = glavs.priroda.value();
       if(combat_log) System.Windows.Forms.MessageBox.Show(String.Format("You dealt {0} dmg, your enemy dealt {1}", m, e));
        if (glavno.recieve_hit(e, eE, pom1))
        {
            end_fight(enemy.type, glavno);
            return false;
        }
        if (glavno.equipment.right_hand!=null && glavno.equipment.right_hand.name == "Dragonslayer")
        {
            enemy.stats.armor -= 50;
            if (enemy.stats.armor < 0) enemy.stats.armor = 0;
        }
        if(enemy.recieve_hit(m,eE,pom2))
        {
            end_fight("Glavno",glavno);
            return true;
        }
        if (glavno.equipment.right_hand != null && glavno.equipment.right_hand.name == "Dragonslayer")
        {
            enemy.stats.armor += 50;

        }
        return false;

   }
  public bool end_fight(String pobednik,MainCharacter glavno)
   {   
      enemy.fighting = false;
      glavno.fighting = false;
      if (pobednik == "none")
      {

          enemy.heal(0, true);
      }
      if (pobednik == "Glavno")
      {
          if (glavno.equipment.helmet != null && glavno.equipment.helmet.name == "Berserker") glavno.heal(15, true);
          if(combat_log)System.Windows.Forms.MessageBox.Show(enemy.type + " slayed... ");
        //  if (enemy.type == "Goblin")
          //{
              glavno.add_Exp(enemy.get_exp());
            
      //    }
          enemy = null;
          return true;
      }
      else
      {
          if (pobednik == enemy.type) glavno.kill();
          enemy = null;
          return false;
      }
   }
   public float recieve_hit(float dmg, int okolina, int type,int armor) //type : 1=melee , 2=range, 3=magic;   okolnia: 1 = tree, 2=stone;
   {
       if (okolina == 2)
       {
           if (type == 3)
           {
               dmg *= (float)0.75;
           }
           else
               if (type == 2)
               {
                   dmg *= (float)0.85;
               }
               else
               {
                   dmg *= (float)0.95;
               }
       }
       else
           if (okolina == 1)
           {
               if (type == 2)
               {
                   dmg *= (float)0.60;
               }
               else
                   if (type == 3) 
                   {
                       dmg *= (float)0.80;
                   }
                   else
                   {
                       dmg *= (float)0.85;
                   }
           }
       dmg *= (float)1 - (float)(((float)armor * 0.5) / (150 + (float)armor * 0.5));
       return dmg;
   }
   public float deal_damage(float min,float max,int type)//type: 1 melee 2 range 3 magic;
   {
      // Random rand = randed.Instance.rand;
       float dmg = randed.Instance.rand.Next((int)(min), (int)(max + 1));
       if(type==1)
       {
           if (randed.Instance.rand.Next(1, 3) == 1)
           {
               dmg *= (float)0.90;
           }
        }
       else 
           if(type ==2 )
           {
               if (randed.Instance.rand.Next(1, 3) == 1)
               {
                   if (randed.Instance.rand.Next(1, 6) == 1)
                   {
                       dmg *= (float) 2.0;
                   }
                   else
                   {
                       dmg *= (float)0.80;
                   }
               }
               else
               {
                   if (randed.Instance.rand.Next(1, 3) == 1)
                   {
                       dmg *= (float)0.90;
                   }
                   else
                   {
                       dmg *= (float)0.95;
                   }

               }
           }
           else 
          if(type==3)
        {
            int pom = randed.Instance.rand.Next(1, 6);
              if(pom==3)
              {
                  dmg *= (float)0.80;
              }
              else
              if(pom==1){

                  dmg *= (float)0.85;
              }
              
        }
    
       return dmg;
   }

    }
    

}
