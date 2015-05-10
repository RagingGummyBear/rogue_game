using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Game
{
    [Serializable]
    public class Equipment
    {
        public Item left_hand { set; get; }
        public Item right_hand { set; get; }
        public Item helmet { set; get; }
        public Item chest { set; get; }
        public Item boots { set; get; }
        public Item gloves { set; get; }
        public Item legs { set; get; }
        public Item shoulders { set; get; }
        public Equipment()
        {

        }
        public Osobini get_Stats()
        {
            Osobini pom=new Osobini();
            if(left_hand!=null)
            {
                pom.health += left_hand.bonus.health;
                pom.dodge += left_hand.bonus.dodge;
                pom.armor += left_hand.bonus.armor; 
                pom.dmgMax += left_hand.bonus.dmgMax;
                pom.dmgMin += left_hand.bonus.dmgMin;
                pom.mana += left_hand.bonus.mana;
            }
            if(right_hand!=null)
            {
                pom.health += right_hand.bonus.health;
                pom.dodge += right_hand.bonus.dodge;
                pom.armor += right_hand.bonus.armor;
                pom.dmgMax += right_hand.bonus.dmgMax;
                pom.dmgMin += right_hand.bonus.dmgMin;
                pom.mana += right_hand.bonus.mana;
            }
            if(helmet!=null)
            {
                pom.health += helmet.bonus.health;
                pom.dodge += helmet.bonus.dodge;
                pom.armor += helmet.bonus.armor;
                pom.dmgMax += helmet.bonus.dmgMax;
                pom.dmgMin += helmet.bonus.dmgMin;
                pom.mana += helmet.bonus.mana;
            }
            if(chest!=null)
            {
                pom.health += chest.bonus.health;
                pom.dodge += chest.bonus.dodge;
                pom.armor += chest.bonus.armor;
                pom.dmgMax += chest.bonus.dmgMax;
                pom.dmgMin += chest.bonus.dmgMin;
                pom.mana += chest.bonus.mana;
            }
            if(boots!=null)
            {
                pom.health += boots.bonus.health;
                pom.dodge += boots.bonus.dodge;
                pom.armor += boots.bonus.armor;
                pom.dmgMax += boots.bonus.dmgMax;
                pom.dmgMin += boots.bonus.dmgMin;
                pom.mana += boots.bonus.mana;
            }
            if(gloves !=null)
            {
                pom.health += gloves.bonus.health;
                pom.dodge += gloves.bonus.dodge;
                pom.armor += gloves.bonus.armor;
                pom.dmgMax += gloves.bonus.dmgMax;
                pom.dmgMin += gloves.bonus.dmgMin;
                pom.mana += gloves.bonus.mana;
            }
            if(legs !=null)
            {
                pom.health += legs.bonus.health;
                pom.dodge += legs.bonus.dodge;
                pom.armor += legs.bonus.armor;
                pom.dmgMax += legs.bonus.dmgMax;
                pom.dmgMin += legs.bonus.dmgMin;
                pom.mana += legs.bonus.mana;
            }
            if(shoulders != null)
            {
                pom.health += shoulders.bonus.health;
                pom.dodge += shoulders.bonus.dodge;
                pom.armor += shoulders.bonus.armor;
                pom.dmgMax += shoulders.bonus.dmgMax;
                pom.dmgMin += shoulders.bonus.dmgMin;
                pom.mana += shoulders.bonus.mana;
            }
            return pom;
        }
        //public void draw(Graphics g,Point p)
        public void draw_legs(Graphics g)
        {
            if (legs != null)
            {
                legs.i_draw(g);
            }
        }
        public void draw_Left_hand(Graphics g){
            if(left_hand!=null)
            {
                left_hand.i_draw(g);
            }
        }
        public void draw_shoulders(Graphics g){
            if (shoulders != null)
            {
                shoulders.i_draw(g);
            }
        }
        public void draw_gloves(Graphics g)
        {
            if (gloves != null)
            {
                gloves.i_draw(g);
            }
        }
        public void draw_boots(Graphics g)
        {
            if (boots != null)
            {
                boots.i_draw(g);
            }
        }
        public void draw_chest(Graphics g)
        {
            if (chest != null)
            {
                this.chest.i_draw(g);
            }
        }
        public void draw_helmet(Graphics g)
        {
            if (helmet != null)
            {
                helmet.i_draw(g);
            }
        }

        public void draw_Right_hand(Graphics g)
        {
            if (right_hand != null)
            {
                right_hand.i_draw(g);
            }
        }

    }
}
