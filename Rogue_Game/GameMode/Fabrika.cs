using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Game.enviromentals;
using Rogue_Game.items.Weapons;
using Rogue_Game.items.Armors;
using Rogue_Game.Characters;
using Rogue_Game.items;

namespace Rogue_Game.GameMode
{
    
    public class Fabrika
    {
        private static Fabrika instance;
        MainCharacter glavno = MainCharacter.Instance;
   private Fabrika() {


   
   }

   public static Fabrika Instance
   {
      get 
      {
         if (instance == null)
         {
            instance = new Fabrika();
         }
         return instance;
      }

   }

        public Block create_Block()
   {
       Block block=new Block();
       block.npc = this.create_Character(); 
            if(block.npc!=null)
            {
            block.kovceg = this.create_chest(true);
            }
      
            else
            {
                block.kovceg = this.create_chest(false);
            }
       block.priroda = this.create_Environment();
       return block;
   }


        public List<Block> fill_List()
        {
            List<Block> bosses = new List<Block>();

            //tiger
            Block wtiger = new Block();
            wtiger.npc = new CrazyWhiteTiger();
            wtiger.priroda = new StoneEnvironment();
            Chest kovceg = new Chest();
            kovceg.item = create_TigerPants();
            wtiger.kovceg = kovceg;
            wtiger.changeable = false;
            //goat
            Block angryGoat = new Block();
            angryGoat.npc = new AngryGoat();
            kovceg = new Chest();
            kovceg.item = create_Warlock_Mask();
            angryGoat.priroda = create_Environment();
            angryGoat.kovceg = kovceg;
            angryGoat.changeable = false;
            //havel
            Block havel = new Block();
            havel.npc = new Havel();
            havel.priroda = create_Environment();
            kovceg = new Chest();
            kovceg.item = create_Havel();
            havel.kovceg = kovceg;
            havel.changeable = false;
            //OrcZerker
            Block orczerk = new Block();
            orczerk.npc = new BerserkerOrc();
            kovceg = new Chest();
            kovceg.item = create_Zerker();
            orczerk.priroda = create_Environment();
            orczerk.kovceg = kovceg;
            orczerk.changeable = false;
            //Ornstein
            Block ornstein = new Block();
            ornstein.npc = new Ornstein();
            kovceg = new Chest();
            kovceg.item = create_OrnsteinSpear();
            ornstein.priroda = create_Environment();
            ornstein.kovceg = kovceg;
            ornstein.changeable = false;
            //MainBoss
            Block theboss = new Block();
            theboss.npc = new MainBoss();
            theboss.priroda = new TreeEnvironment();
            theboss.changeable = false;
            bosses.Add(wtiger);
            bosses.Add(angryGoat);
            bosses.Add(havel);
            bosses.Add(orczerk);
            bosses.Add(ornstein);
            bosses.Add(theboss);

            return bosses;
        }

        public Berry create_Berries(int y)
        {
            Berry berry = new Berry();
            for (int i = 0; i < y; i++) berry.increment_B();
            return berry;
        }

       public Character create_Character()
   {
            
       Character npc;
      // Random rand = randed.Instance.rand;
       if (randed.Instance.rand.Next(1, 13) == 1)
       {
           npc = create_Goblin();
       }
       else if (randed.Instance.rand.Next(1, 90) == 1)
       {
           npc = create_Merchant();
       }
       else npc = null;
       return npc;
   }


        /*
         *EXOTIC EQUIPMENT 
         *DONT DROP MORE THAN ONCE PLZ
         */
        public OrnsteinSpear create_OrnsteinSpear()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
        {
            String name = "Dragonslayer";
            d3vector requirements = new d3vector(25, 20, 20);
            Osobini bonus = new Osobini(250, 280, 30, 100, 480, 0);
            return new OrnsteinSpear(name, requirements, bonus, 6000, 1000, @"Resources\OrnsteinSpear.gif");

        }

        public DragonSword create_DragonSword()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
        {
            String name = "DRAGON";
            d3vector requirements = new d3vector(25,20, 20);
            Osobini bonus = new Osobini(170, 170, 0, 60, 350, 1000);
            return new DragonSword(name, requirements, bonus, 6000, 1000, @"Resources\Dragon_Sword.jpg");

        }
        public AChest create_Havel()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
        {
            String name = "Havel's ";
            d3vector requirements = new d3vector(25, 20, 20);
            Osobini bonus = new Osobini(0, 0, 0, 400,0, 0);
            return new AChest(name, requirements, bonus, 6000, 1000, @"Resources\Havel_Chest.gif");

        }
        public Legs create_TigerPants()
        {
            String name = "WhiteTiger's";
            d3vector requirements = new d3vector(25, 20, 20);
            Osobini bonus=new Osobini(0,0,65,30,100,100);
            return new Legs(name, requirements, bonus, 6000, 1000, @"Resources\CrazyWhiteTigerPants.gif");
        }
        public Zerker create_Zerker()
        {
            String name = "Berserker";
            d3vector requirements = new d3vector(25, 20, 20);
            Osobini bonus = new Osobini(15, 15, 0, 0, 800, 0);
            return new Zerker(name, requirements, bonus, 100000, 1000, @"Resources\ZerkerMask.gif");
        }
        public Warlock_Mask create_Warlock_Mask()
        {
             String name = "Warlock";
            d3vector requirements = new d3vector(25, 20, 20);
            Osobini bonus = new Osobini(15, 15, 20, 30, 400, 0);
            
            return new Warlock_Mask(name, requirements, bonus, 100000, 1000, @"Resources\Warlock_Mask.gif");
        }

        /*
         * 
         *  ALL SWORD CONSTRUCTORS THAT DROP IN CHESTS
         *  SHOULD GET BALANCED
         * 
         * 
         * 
        */
        public Sword create_Sword_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 28, 21);
            Osobini bonuses = new Osobini(15, 25, 5, 5, 0, 0);
            return new Sword(name, requirements,bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 23, 21);
            Osobini bonuses = new Osobini(15, 25, 0, 5, 10, 0);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(20, 20, 0, 7, 30, 10);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(34, 41, 29);
            Osobini bonuses = new Osobini(45, 70, 5,10 ,5, 0);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 29, 33);
            Osobini bonuses = new Osobini(5, 115, 0, 5, 50, 5);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 26, 41);
            Osobini bonuses = new Osobini(50, 50, 0, 15, 60, 30);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(43, 62, 29);
            Osobini bonuses = new Osobini(105, 165, 15, 20, 50, 0);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 32, 45);
            Osobini bonuses = new Osobini(5, 380, 0, 5, 125, 50);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Sword.jpg");

        }
        public Sword create_Sword_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 32, 59);
            Osobini bonuses = new Osobini(120, 120, 0, 25,250, 250);
            return new Sword(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Sword.jpg");

        }
        /*
       * 
       *  ALL GreatSword CONSTRUCTORS THAT DROP IN CHESTS
       *  SHOULD GET BALANCED
       * 
       * 
       * 
      */

        public GreatSword create_GreatSword_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(27, 26, 21);
            Osobini bonuses = new Osobini(17, 35, 7, 7, 10, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(33, 20, 21);
            Osobini bonuses = new Osobini(5, 80, 0, 8, 25, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(25, 20, 29);
            Osobini bonuses = new Osobini(25, 25, 3, 10, 80, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_dex_mid()  
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(37, 44, 23);
            Osobini bonuses = new Osobini(75, 125, 10, 15, 30, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(48, 26, 30);
            Osobini bonuses = new Osobini(5, 220, 0, 15, 110, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(100, 100, 0, 25, 270, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(52, 56, 26);
            Osobini bonuses = new Osobini(165,215, 15, 20, 200, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(63, 26, 45);
            Osobini bonuses = new Osobini(5, 700, 0, 20, 480, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_GreatSword.jpg");

        }
        public GreatSword create_GreatSword_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(57, 20, 57);
            Osobini bonuses = new Osobini(175, 175, 0, 35, 800, 0);
            return new GreatSword(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_GreatSword.jpg");

        }
        /*
         * BOW CONSTRUCTORI ZA VO CHESTOVI
         * 
         * 
         * 
         * 
         
         */




        public Bow create_Bow_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 28, 21);
            Osobini bonuses = new Osobini(17, 35, 8, 8, 0, 0);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(27, 26, 21);
            Osobini bonuses = new Osobini(5, 75, 3, 8, 5, 0);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(25, 23, 26);
            Osobini bonuses = new Osobini(25, 25, 5, 10, 80, 0);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(31, 50, 23);
            Osobini bonuses = new Osobini(90, 140, 15, 15, 10, 5);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(38, 36, 30);
            Osobini bonuses = new Osobini(5, 170, 5, 15, 60, 10);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(32, 33, 39);
            Osobini bonuses = new Osobini(110, 110, 10, 25, 200, 25);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(31, 77, 26);
            Osobini bonuses = new Osobini(200, 280, 25, 20, 100, 20);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(42, 47, 45);
            Osobini bonuses = new Osobini(5, 600, 10, 20, 220, 50);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Bow.png");

        }
        public Bow create_Bow_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(32, 45, 57);
            Osobini bonuses = new Osobini(190, 190, 15, 35, 600, 100);
            return new Bow(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Bow.png");

        }
       /*
        *
        *  SHIELD CONSTRUCTORI ZA CHESTOVI
        *  
        * 
        * 
        */

         public Shield create_Shield_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(27, 20, 27);
            Osobini bonuses = new Osobini(5, 10, 0, 12, 10, 0);
            return new Shield(name, requirements,bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 20, 24);
            Osobini bonuses = new Osobini(5, 5, 0, 15, 15, 0);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(10, 10, 0, 12, 20, 10);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(37, 32, 35);
            Osobini bonuses = new Osobini(25, 30, 0,20 ,30, 5);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(5, 55, 0, 22, 75, 25);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 20, 47);
            Osobini bonuses = new Osobini(20, 20, 0, 28, 90, 60);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(43, 38, 53);
            Osobini bonuses = new Osobini(65, 90, 5, 50, 90, 50);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 20,57);
            Osobini bonuses = new Osobini(5, 200, 0, 55, 250, 150);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Shield.gif");

        }
        public Shield create_Shield_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 20, 71);
            Osobini bonuses = new Osobini(50, 50, 0,58,500, 500);
            return new Shield(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Shield.gif");
        }

        /*
         * 
         * ACHEST CHEST CONSTRUCTORS :D:D:D
         * 
         * 
         */

        public AChest create_AChest_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 26, 23);
            Osobini bonuses = new Osobini(0, 0, 5, 15, 50, 0);
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 20, 24);
            Osobini bonuses = new Osobini(10, 10, 0, 15, 50, 10);
        
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(0, 0, 0, 25, 50, 0);
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(30, 39, 35);
            Osobini bonuses = new Osobini(0, 0, 14, 30,75, 5);
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(15, 15, 0, 30, 90, 0);
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 20, 47); 
            Osobini bonuses = new Osobini(0, 0, 0, 45, 100, 150);
           
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(28, 53, 53);
            Osobini bonuses = new Osobini(0, 0, 20, 50, 150,50);
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 20, 57);
            Osobini bonuses = new Osobini(20, 20, 0, 30, 600, 0);
           
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_AChest.jpg");

        }
        public AChest create_AChest_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 20, 71);
            Osobini bonuses = new Osobini(0, 0, 0, 70, 280, 350);
            return new AChest(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_AChest.jpg");
        }


        /**
         * 
         * BOOTS ZA CHEST CONSTRUCTORS
         * 
         * 
         * 
         * */
        public Boots create_Boots_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 26, 23);
            Osobini bonuses = new Osobini(0, 0, 7, 10, 25, 0);
            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 20, 24);
            Osobini bonuses = new Osobini(10, 10, 0, 10, 25, 0);
            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(0, 0, 0, 20, 25, 0);
            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(30, 39, 35);
            Osobini bonuses = new Osobini(0, 0, 7, 25, 50, 5);
            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(15, 15, 0, 20, 50, 0);
            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 20, 47);
            Osobini bonuses = new Osobini(0, 0, 0, 35, 100, 150);

            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(28, 53, 53);
            Osobini bonuses = new Osobini(0, 0, 10, 40, 75, 50);
            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 20, 57);
            Osobini bonuses = new Osobini(10, 10, 0, 25, 300, 0);

            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Boots.gif");

        }
        public Boots create_Boots_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 20, 71);
            Osobini bonuses = new Osobini(0, 0, 0, 50, 180, 350);
            return new Boots(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Boots.gif");
        }
        /**
        * 
        * GLOVES ZA CHEST CONSTRUCTORS
        * 
        * 
        * 
        * */
        public Gloves create_Gloves_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 26, 23);
            Osobini bonuses = new Osobini(2, 2, 5, 5, 20, 0);
            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 20, 24);
            Osobini bonuses = new Osobini(8, 8, 0, 7, 20, 0);
            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(2, 2, 0, 12, 10, 0);
            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(30, 39, 35);
            Osobini bonuses = new Osobini(5, 5, 7, 5, 30, 5);
            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(15, 15, 0, 7, 20, 0);
            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 20, 47);
            Osobini bonuses = new Osobini(7, 7, 0, 19, 70, 150);

            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(28, 53, 53);
            Osobini bonuses = new Osobini(15, 15, 10,20, 30, 10);
            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 20, 57);
            Osobini bonuses = new Osobini(10, 10, 0, 10, 150, 0);

            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Gloves.jpg");

        }
        public Gloves create_Gloves_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 20, 71);
            Osobini bonuses = new Osobini(12, 12, 0, 25, 100, 150);
            return new Gloves(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Gloves.jpg");
        }  
        
        /**
        * 
        * HELMET ZA CHEST CONSTRUCTORS
        * 
        * 
        * 
        * */
        public Helmet create_Helmet_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 26, 23);
            Osobini bonuses = new Osobini(0, 0, 5, 7, 30, 0);
            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 20, 24);
            Osobini bonuses = new Osobini(0, 0, 0, 10, 30, 0);
            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(0, 0, 0,15, 20, 0);
            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(30, 39, 35);
            Osobini bonuses = new Osobini(0, 0, 7,15, 40, 5);
            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(2, 2, 0, 15, 30, 0);
            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 20, 47);
            Osobini bonuses = new Osobini(0, 0, 0, 27, 90, 100);

            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(28, 53, 53);
            Osobini bonuses = new Osobini(0, 0, 10,20, 60, 30);
            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 20, 57);
            Osobini bonuses = new Osobini(5, 5, 0, 20, 150, 0);

            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Helmet.jpg");

        }
        public Helmet create_Helmet_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 20, 71);
            Osobini bonuses = new Osobini(0, 0, 0, 43, 120, 150);
            return new Helmet(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Helmet.jpg");
        }
        /**
       * 
       * LEGS ZA CHEST CONSTRUCTORS
       * 
       * 
       * 
       * */
        public Legs create_Legs_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 26, 23);
            Osobini bonuses = new Osobini(0, 0, 5, 10, 15, 0);
            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 20, 24);
            Osobini bonuses = new Osobini(0, 0, 5, 7, 10, 0);
            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(0, 0, 5, 15, 10, 0);
            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(30, 39, 35);
            Osobini bonuses = new Osobini(0, 0, 12, 16, 20, 5);
            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(0, 5, 5, 10, 30, 0);
            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 20, 47);
            Osobini bonuses = new Osobini(0, 0, 5, 25, 40, 80);

            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(28, 53, 53);
            Osobini bonuses = new Osobini(0, 0, 20, 25, 30, 30);
            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 20, 57);
            Osobini bonuses = new Osobini(0, 25, 8, 10, 130, 0);

            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Legs.jpg");

        }
        public Legs create_Legs_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 20, 71);
            Osobini bonuses = new Osobini(0, 0, 10, 33, 70, 100);
            return new Legs(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Legs.jpg");
        }   /**
       * 
       * SHOULDERS ZA CHEST CONSTRUCTORS
       * 
       * 
       * 
       * */
        public Shoulders create_Shoulders_dex_low()
        {
            String name = "Basic Dexterity";
            d3vector requirements = new d3vector(25, 26, 23);
            Osobini bonuses = new Osobini(0, 0, 7, 12, 0, 0);
            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_str_low()
        {
            String name = "Basic Strength";
            d3vector requirements = new d3vector(30, 20, 24);
            Osobini bonuses = new Osobini(0, 0, 2, 7, 10, 0);
            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_int_low()
        {
            String name = "Basic Intelligence";
            d3vector requirements = new d3vector(28, 20, 26);
            Osobini bonuses = new Osobini(0, 0, 0, 10, 10, 0);
            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(5, 10), randed.Instance.rand.Next(1, 3), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_dex_mid()
        {
            String name = "Steel Dexterity";
            d3vector requirements = new d3vector(30, 39, 35);
            Osobini bonuses = new Osobini(0, 0, 10, 15, 10, 5);
            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_str_mid()
        {
            String name = "Steel Strength";
            d3vector requirements = new d3vector(42, 20, 42);
            Osobini bonuses = new Osobini(0, 10, 5, 10, 10, 0);
            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_int_mid()
        {
            String name = "Steel Intelligence";
            d3vector requirements = new d3vector(37, 20, 47);
            Osobini bonuses = new Osobini(0, 0, 5, 20, 20, 10);

            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(150, 250), randed.Instance.rand.Next(40, 50), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_dex_High()
        {
            String name = "Platinum Dexterity";
            d3vector requirements = new d3vector(28, 53, 53);
            Osobini bonuses = new Osobini(0, 0, 15, 30, 15, 0);
            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_str_High()
        {
            String name = "Platinum Strength";
            d3vector requirements = new d3vector(57, 20, 57);
            Osobini bonuses = new Osobini(0, 0, 10, 25, 50, 0);

            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Shoulders.jpg");

        }
        public Shoulders create_Shoulders_int_High()
        {
            String name = "Platinum Intelligence";//30 poeni za raspredelba
            d3vector requirements = new d3vector(43, 20, 71);
            Osobini bonuses = new Osobini(0, 0, 15, 30, 70, 0);
            return new Shoulders(name, requirements, bonuses, randed.Instance.rand.Next(800, 1000), randed.Instance.rand.Next(150, 300), @"Resources\Steel_Shoulders.jpg");
        }

        /*
         * 
         *
         * GENERATORS !!!!!!!!!!!!!
         * 
         * 
         * 
         */
   public Sword create_Sword()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
    {
        int sreka = randed.Instance.rand.Next(1, 4);
        Sword sword = create_Sword_int_low();
       if(glavno.level<10)
       {
           if (sreka == 1)
           {
               sword = create_Sword_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Sword_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Sword_str_low();
                   }
                   else create_Sword_str_low();
       }
       else if(glavno.level<20)
       {
           if (sreka == 1)
           {
               sword = create_Sword_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Sword_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Sword_str_mid();
                   }
                   else create_Sword_int_low();
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_Sword_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Sword_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Sword_str_High();
                   }
                   else create_Sword_dex_low();
       }
      
       return sword;

    }
   public GreatSword create_GreatSword()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
   {
       int sreka = randed.Instance.rand.Next(1, 4);
       GreatSword sword = create_GreatSword_dex_low();
       if (glavno.level < 10)
       {
           if (sreka == 1)
           {
               sword = create_GreatSword_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_GreatSword_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_GreatSword_str_low();
                   }
       }
       else if (glavno.level < 20)
       {
           if (sreka == 1)
           {
               sword = create_GreatSword_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_GreatSword_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_GreatSword_str_mid();
                   }
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_GreatSword_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_GreatSword_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_GreatSword_str_High();
                   }
       }

       return sword;

   }
   public Bow create_Bow()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
   {
       int sreka = randed.Instance.rand.Next(1, 4);
       Bow sword = create_Bow_dex_low();
       if (glavno.level < 10)
       {
           if (sreka == 1)
           {
               sword = create_Bow_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Bow_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Bow_str_low();
                   }
       }
       else if (glavno.level < 20)
       {
           if (sreka == 1)
           {
               sword = create_Bow_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Bow_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Bow_str_mid();
                   }
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_Bow_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Bow_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Bow_str_High();
                   }
       }

       return sword;

   }
   public Shield create_Shield()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
   {
       int sreka = randed.Instance.rand.Next(1, 4);
       Shield sword = create_Shield_int_low();
       if (glavno.level < 10)
       {
           if (sreka == 1)
           {
               sword = create_Shield_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Shield_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Shield_str_low();
                   }
       }
       else if (glavno.level < 20)
       {
           if (sreka == 1)
           {
               sword = create_Shield_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Shield_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Shield_str_mid();
                   }
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_Shield_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Shield_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Shield_str_High();
                   }
       }

       return sword;

   }

   public AChest create_AChest()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
   {
       int sreka = randed.Instance.rand.Next(1, 4);
       AChest sword = create_AChest_dex_low();
       if (glavno.level < 10)
       {
           if (sreka == 1)
           {
               sword = create_AChest_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_AChest_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_AChest_str_low();
                   }
       }
       else if (glavno.level < 20)
       {
           if (sreka == 1)
           {
               sword = create_AChest_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_AChest_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_AChest_str_mid();
                   }
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_AChest_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_AChest_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_AChest_str_High();
                   }
       }

       return sword;

   }
   public Boots create_Boots()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
   {
       int sreka = randed.Instance.rand.Next(1, 4);
       Boots sword = create_Boots_dex_low();
       if (glavno.level < 10)
       {
           if (sreka == 1)
           {
               sword = create_Boots_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Boots_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Boots_str_low();
                   }
       }
       else if (glavno.level < 20)
       {
           if (sreka == 1)
           {
               sword = create_Boots_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Boots_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Boots_str_mid();
                   }
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_Boots_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Boots_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Boots_str_High();
                   }
       }

       return sword;
   }
   public Gloves create_Gloves()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
   {
      int sreka = randed.Instance.rand.Next(1, 4);
       Gloves sword = create_Gloves_dex_low();
       if (glavno.level < 10)
       {
           if (sreka == 1)
           {
               sword = create_Gloves_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Gloves_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Gloves_str_low();
                   }
       }
       else if (glavno.level < 20)
       {
           if (sreka == 1)
           {
               sword = create_Gloves_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Gloves_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Gloves_str_mid();
                   }
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_Gloves_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Gloves_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Gloves_str_High();
                   }
       }

       return sword;
   }
  
    public Helmet create_Helmet(){
      
      int sreka = randed.Instance.rand.Next(1, 4);
      Helmet sword = create_Helmet_dex_low();
       if (glavno.level < 10)
       {
           if (sreka == 1)
           {
               sword = create_Helmet_dex_low();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Helmet_int_low();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Helmet_str_low();
                   }
       }
       else if (glavno.level < 20)
       {
           if (sreka == 1)
           {
               sword = create_Helmet_dex_mid();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Helmet_int_mid();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Helmet_str_mid();
                   }
       }
       else
       {
           if (sreka == 1)
           {
               sword = create_Helmet_dex_High();
           }
           else
               if (sreka == 2)
               {
                   sword = create_Helmet_int_High();
               }
               else
                   if (sreka == 3)
                   {
                       sword = create_Helmet_str_High();
                   }
       }

       return sword;
   }
        public Legs create_Legs()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
        {

            int sreka = randed.Instance.rand.Next(1, 4);
            Legs sword = create_Legs_dex_low();
            if (glavno.level < 10)
            {
                if (sreka == 1)
                {
                    sword = create_Legs_dex_low();
                }
                else
                    if (sreka == 2)
                    {
                        sword = create_Legs_int_low();
                    }
                    else
                        if (sreka == 3)
                        {
                            sword = create_Legs_str_low();
                        }
            }
            else if (glavno.level < 20)
            {
                if (sreka == 1)
                {
                    sword = create_Legs_dex_mid();
                }
                else
                    if (sreka == 2)
                    {
                        sword = create_Legs_int_mid();
                    }
                    else
                        if (sreka == 3)
                        {
                            sword = create_Legs_str_mid();
                        }
            }
            else
            {
                if (sreka == 1)
                {
                    sword = create_Legs_dex_High();
                }
                else
                    if (sreka == 2)
                    {
                        sword = create_Legs_int_High();
                    }
                    else
                        if (sreka == 3)
                        {
                            sword = create_Legs_str_High();
                        }
            }

            return sword;

        }
        public Shoulders create_Shoulders()  // Sword(String Name, d3vector Requirements, d3vector Bonus)
        {
            int sreka = randed.Instance.rand.Next(1, 4);
            Shoulders sword = create_Shoulders_dex_low();
            if (glavno.level < 10)
            {
                if (sreka == 1)
                {
                    sword = create_Shoulders_dex_low();
                }
                else
                    if (sreka == 2)
                    {
                        sword = create_Shoulders_int_low();
                    }
                    else
                        if (sreka == 3)
                        {
                            sword = create_Shoulders_str_low();
                        }
            }
            else if (glavno.level < 20)
            {
                if (sreka == 1)
                {
                    sword = create_Shoulders_dex_mid();
                }
                else
                    if (sreka == 2)
                    {
                        sword = create_Shoulders_int_mid();
                    }
                    else
                        if (sreka == 3)
                        {
                            sword = create_Shoulders_str_mid();
                        }
            }
            else
            {
                if (sreka == 1)
                {
                    sword = create_Shoulders_dex_High();
                }
                else
                    if (sreka == 2)
                    {
                        sword = create_Shoulders_int_High();
                    }
                    else
                        if (sreka == 3)
                        {
                            sword = create_Shoulders_str_High();
                        }
            }

            return sword;

        }
        public Chest create_chest(int b)
        {
            // Random rand = randed.Instance.rand;
            int pom;
            Chest kovceg=null;
            pom = randed.Instance.rand.Next(1, 11);

            if (pom == 1)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Sword();
            }
            else if (pom == 2)
            {
                kovceg = new Chest();
                kovceg.item = this.create_AChest();
            }
            else if (pom == 3)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Helmet();
            }
            else if (pom == 4)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Gloves();
            }
            else 
                /*if (pom == 5)
            {
                kovceg = new Chest();
                kovceg.item = this.create_DragonSword();
            }
            else*/
                if (pom == 6)
            {
                kovceg = new Chest();
                kovceg.item = this.create_GreatSword();
            }
            else if (pom == 7)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Shoulders();
            }
            else if (pom == 8)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Boots();
            }
            else if (pom == 9)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Legs();
            }
            else if (pom == 10)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Shield();
            }
            else if (pom == 5)
            {
                kovceg = new Chest();
                kovceg.item = this.create_Bow();
            }
            else kovceg = null;

            return kovceg;
        }

   

        public Chest create_chest(bool b)
   {
      // Random rand = randed.Instance.rand;
       int pom;
       Chest kovceg;
            if(b)
            {
                pom = randed.Instance.rand.Next(1, 50);
            }
            else
            {
                pom = randed.Instance.rand.Next(1, 280);
            }
       
       if (pom == 1)
       {
           kovceg = new Chest();
           kovceg.item = this.create_Sword();
       }
           else if(pom ==2)
       {
               kovceg=new Chest();
               kovceg.item=this.create_AChest();
       }
             else if(pom ==3)
       {
           kovceg = new Chest();
               kovceg.item=this.create_Helmet();
       }
       else if (pom == 4)
       {
           kovceg = new Chest();
           kovceg.item = this.create_Gloves();
       }
       else
           /*if (pom == 5)
       {
           kovceg = new Chest();
           kovceg.item = this.create_DragonSword();
       }
       else */
           if (pom == 6)
       {
           kovceg = new Chest();
           kovceg.item = this.create_GreatSword();
       }
       else if (pom == 7)
       {
           kovceg = new Chest();
           kovceg.item = this.create_Shoulders();
       }
       else if (pom == 8)
       {
           kovceg = new Chest();
           kovceg.item = this.create_Boots();
       }
       else if (pom == 9)
       {
           kovceg = new Chest();
           kovceg.item = this.create_Legs();
       }
       else if (pom == 10)
       {
           kovceg = new Chest();
           kovceg.item = this.create_Shield();
       }
       else if (pom == 5)
       {
           kovceg = new Chest();
           kovceg.item = this.create_Bow();
       }
       else kovceg = null;

       return kovceg;
   }

        // 
        //
        //GI pravi site creepci igniriraj go imeto 
        //
        //
   public Character create_Goblin()  //public Goblin(float DamageMin,float DamageMax,float Dodge,int Armor,float Health,float Mana,bool Magic,bool Melee, bool Range)
        {

       if(glavno.level<10)
       {
           int pom = randed.Instance.rand.Next(1, 30);
           if (pom < 6) return new Smasher();
           else
               if (pom <= 9) return new heavyWarrior();
               else if (pom <= 11) return new BoneWarrior();
               else
                   if (pom == 12) return new UndeadWarrior();
                   //        else
                   //          if (pom == 10) return new Dragon();
                   else return new Goblin();
                  

       }
       if(glavno.level<20)
       {
           int pom = randed.Instance.rand.Next(1, 30);
           if (pom < 3) return new Smasher();
           else
               if (pom < 7) return new UndeadWarrior();
               else if (pom < 9) return new heavyWarrior();
               else
                   if (pom == 10) return new Dragon();
                   else return new BoneWarrior(); 

       }
       else
       {
           if (glavno.level < 25)
           {
                  int pom = randed.Instance.rand.Next(1, 30);
                  if (pom < 2) return new Smasher();
                  else
                      if (pom <= 8) return new UndeadWarrior();
                      else if (pom < 11) new Dragon();
                      // else
                      //  if (pom == 10) return new Dragon();
                      else new BoneWarrior();
           }
           else
           {
               if (glavno.level < 30)
               {
                   int pom = randed.Instance.rand.Next(1, 30);
                   if (pom < 5) return new UndeadWarrior();
                   else
                       if (pom < 10) return new Dragon();
                       // else if (pom <= 10) return new heavyWarrior();
                       //else
                       //  if (pom == 11) return new heavyWarrior();
                       else
                           new BoneWarrior();
               } 
               else 
           if(glavno.level>=30)
           {
               
               int pom = randed.Instance.rand.Next(1, 30);
             /*  if (pom < 5) return new UndeadWarrior();
               else
                   if (pom <= 8) return new BoneWarrior();
                   else
                   {
                      // System.Windows.Forms.MessageBox.Show("MOM I DID IT");
                      return new Dragon();
                   }*/
               if (pom < 10) return new Dragon();
               else return new UndeadWarrior();
           }
           }
          
       }
     //  return new Goblin();
       return new Goblin();
            
        }
   public Merchant create_Merchant()  //public Goblin(float DamageMin,float DamageMax,float Dodge,int Armor,float Health,float Mana,bool Magic,bool Melee, bool Range)
   {
       // Random rand = randed.Instance.rand;

       return new Merchant();

   }
        public Item create_MercItem()
   {
       Item temp=null;
       Chest pom = null;
            while(temp==null)
            {
                pom=create_chest(true);
               if(pom!=null) temp = pom.item;
            }
            return temp;
   }
    
    public environment create_Environment()
   {
       environment okolina;
      // Random rand = randed.Instance.rand;
       int pom = randed.Instance.rand.Next(1, 20);
        if(pom<3)
        {
            okolina = new FoodEnvironment();
        }
        else
        {
            if(pom<5)
            {
                okolina = new TreeEnvironment();
            }
            else
            {
                if (pom < 7)
                {
                    okolina = new StoneEnvironment();
                }
                else okolina = null;
            }
        }
        return okolina;
   }




    }
}
