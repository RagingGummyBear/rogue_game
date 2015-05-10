using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Game
{
    [Serializable]
    public class Osobini
    {
        public float health { set; get; }
        public float mana { set; get; }
        public float dmgMin { set; get; }
        public float dmgMax { set; get; }
        public float dodge { set; get; }
        public int armor { set; get; }
        public float maxHealth { get; set; }
        public float maxMana { set; get; }
       public Osobini()
        {
            //nothing?
            health = 0;
            mana = 0;
            dmgMin = 0;
            dmgMax = 0;
            dodge = 0;
            armor = 0;

        }
       public Osobini (float DamageMin,float DamageMax,float Dodge,int Armor,float Health,float Mana)
        {

            health = Health;
            mana = Mana;
            armor = Armor;
            dodge = Dodge;
            dmgMax = DamageMax;
            dmgMin = DamageMin;

        }
        public void set_maxHP(float pom)
       {

           maxHealth = pom;
           
       }
        public void set_maxMP(float pom)
        {

            maxMana = pom;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Health: {0}\tMana: {1}\n",this.maxHealth,this.maxMana));
            sb.Append(String.Format("Armor: {0}\tDodge: {1}\n", this.armor, this.dodge));
            sb.Append(String.Format("Attack: {0} - {1}\t", this.dmgMin, dmgMax));
            return sb.ToString();
        }
    }
}
