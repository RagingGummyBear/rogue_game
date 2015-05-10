using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Game.GameMode;
using System.Drawing;
using System.Windows.Forms;

namespace Rogue_Game
{
   public class BlockGrid
    {
       public static int vert = 90;
       public static int hori = 90;

       private static BlockGrid instance;

       private BlockGrid()
       {
       this.seter();
   }

       public static BlockGrid Instance
   {
      get 
      {
         if (instance == null)
         {
             instance = new BlockGrid();
         }
         return instance;
      }
   }

       //upper is unsafe
       Combat fight = Combat.Instance;
       Fabrika fact = Fabrika.Instance;
       MainCharacter glavno = MainCharacter.Instance;
       public bool should_Invalidate_All = false;
      public MapaMatrix wow =MapaMatrix.Instance;
       public Point spawner;
       public Point centar;
       bool flag = true;
        public Block[,] mapa=new Block[vert,hori];
       //elite itemi i bossovi
        List<Block> bosses=new List<Block>();
         
       
       BlockGrid(Block[,] Mapa)
       {
           mapa = Mapa;
       }
       //inicializacija
        
     public  void more_bosses()
       {
           int pom = 0;
           bosses = fact.fill_List();
           while (bosses.Count > pom)
           {
               int a = randed.Instance.rand.Next(1, hori), b = randed.Instance.rand.Next(1, vert);
               if (mapa[a, b] != null)
               {
                   if (mapa[a, b].npc == null)
                   {
                       // MessageBox.Show("I DID IT");
                       mapa[a, b] = bosses[pom];
                       pom++;

                   }
               }

               else
               {
                   mapa[a, b] = bosses[pom];
                   pom++;

               }
           }
           pom = 0;
       }

        void seter()
        { 
            int pom = 0;
            bosses = fact.fill_List();
            while (bosses.Count > pom)
            {
                int a = randed.Instance.rand.Next(1, hori), b = randed.Instance.rand.Next(1, vert);
                if (mapa[a, b] != null)
                {
                    if (mapa[a, b].npc == null)
                    {
                        // MessageBox.Show("I DID IT");
                        mapa[a, b] = bosses[pom];
                        pom++;

                    }
                }

                else
                {
                    mapa[a, b] = bosses[pom];
                    pom++;

                }
            }
            pom=0;

            pom = 0;
            for(int i=0;i<hori;i++)
            {
                for(int y=0;y<vert;y++)
                {

                    if (i != glavno.location.X / 90 || y != glavno.location.Y / 90)
                    {
                        if (mapa[i, y] == null) mapa[i, y] = fact.create_Block();
                    }
                    else
                    {
                        mapa[i, y] = fact.create_Block();
                    }
                   
                }
            }
        }
       public void reseter()
        {
            this.mapa = new Block[hori,vert];
            wow .clean();

            seter();

        }

       public void draw(Graphics g)
       {
           Block [,]temp=new Block [9,9];
           int xx = 0, yy = 0;
           if (flag)
           {
               centar = glavno.location;               // DONT TOUCH MAGIC
               spawner = glavno.location;
               flag = false;
           }
           for (int i = (spawner.Y / 90) - 4; i < (spawner.Y / 90) + 5; i++)
           {
               for (int y = (spawner.X / 90) - 4; y < (spawner.X / 90) + 5; y++)
               {
                   if (i<vert && y<hori)
                   {
                       temp[xx, yy] = mapa[i, y];
                       xx++;
                      
                   }
               }
               yy++;
               xx = 0;
           }
           wow.fill(temp);
           wow.draw(g,centar);
           glavno.draw(g);
           xx = 0;
           yy = 0;
       }


       public void open_Chest(int x,int z)
       {
           for(int i=0;i<hori;i++)for(int y=0;y<vert;y++)
           {
               if(wow.mapa[x,z]==mapa[i,y])
               {
                   mapa[i, y].kovceg.open();
               }
           }
       }


       public void attack(int temp1, int temp2)
       {
           if (glavno.fighting)
           {
               if (fight.enems == wow.mapa[temp1 - 1, temp2])
               {
                   if (fight.exchange_Hits(glavno))
                   {
                       for (int i = 0; i < vert; i++)
                           for (int y = 0; y < hori; y++)
                           {
                               if (this.mapa[i, y] == wow.mapa[temp1 - 1, temp2]) mapa[i, y].kill_npc();
                           }
                       wow.mapa[temp1 - 1, temp2].kill_npc();
                   }
               }

           }
           else
           {
               if (System.Windows.Forms.MessageBox.Show(" Do you want to start a fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
               {
                   fight.start_fight(wow.mapa[temp1 - 1, temp2], wow.mapa[temp1, temp2], glavno);
               }
           }
       }


       void set_newItems()
       {

           for(int i=0;i<vert;i++)
               for(int y=0;y<hori;y++)
               {
                   if (mapa[i, y].kovceg != null && mapa[i,y].changeable) mapa[i, y].kovceg = fact.create_chest(1);
                   if(mapa[i,y].npc!=null)if(mapa[i,y].npc.type=="Merchant")
                   {
                       mapa[i, y].npc = fact.create_Merchant();
                   }
               }
       }

       //DVIZENJE 
       public void move_Up( bool gore)
       {
           System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Sounds\boink.wav");
           player.Play();
           if (glavno.dead) return;
           if(glavno.upgrade_items)
           {
              // this.reseter();
               set_newItems();
               glavno.upgrade_items = false;
           }
           int temp1=glavno.location.X/90;
           int temp2 =glavno.location.Y/90;

           if(gore)    // TESTING IS HAPPENING HERE NOW !!!!!!!!!!!!!!!!!!!!!!!!!!!
           {
             
              if(glavno.fighting)if(fight.enems!=wow.mapa[temp1,temp2-1])
                  {

                      if (System.Windows.Forms.MessageBox.Show("Are you sure you want to leave the fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                      {
                          for (int q = 0; q < 9; q++)
                              for (int w = 0; w < 9; w++) if (fight.enems == wow.mapa[q, w]) wow.mapa[q, w].npc.heal(0, true);
                          {

                          }

                          fight.end_fight("None", glavno);
                      }
                      else return;
                  }

               if(wow.mapa[temp1,temp2-1].npc!=null)
               {
                   if(glavno.fighting)
                   {
                       if(fight.enems==wow.mapa[temp1,temp2-1])
                       {
                           if (fight.exchange_Hits(glavno))
                           {
                               for (int i = 0; i < vert; i++)
                                   for (int y = 0; y < hori; y++)
                                   {
                                       if (this.mapa[i, y] == wow.mapa[temp1, temp2-1]) mapa[i, y].kill_npc();
                                   }
                               wow.mapa[temp1 , temp2-1].kill_npc();
                           }
                       }


                   }

                   else if(wow.mapa[temp1,temp2-1].npc.type=="Merchant")
                   {
                       Shop shop = new Shop();
                       shop.set_Merc(wow.mapa[temp1, temp2 - 1].npc.lista);
                       if(shop.ShowDialog()==DialogResult.OK)
                       {
                           glavno.gold = shop.gold;
                           glavno.inventory = shop.glavnoInv;
                           wow.mapa[temp1 , temp2-1].npc.lista = shop.merc;
                           should_Invalidate_All = true;
                       }
                   }
                       else 
                   if (System.Windows.Forms.MessageBox.Show("There is minion on that block. Can't move there. DO you want to fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                  {
                      fight.start_fight(wow.mapa[temp1, temp2 - 1], wow.mapa[temp1, temp2], glavno);
                  }
               }
               else if (spawner.Y == 360)
               {
                   glavno.move_Up(true);
                   return;
               }
               else
               {
                   if (spawner.Y == (hori * 90) - (5 * 90))
                   {
                       if (glavno.location.Y >= 450)
                       {
                           glavno.move_Up(true);
                           return;
                       }
                       else
                       {
                           spawner.Y -= 90;
                           glavno.move_Up(false);
                           return;
                       }
                   }
                   else
                   {
                       spawner.Y -= 90;
                   }
               }
           }
           else
           {

               if (glavno.fighting) if (fight.enems != wow.mapa[temp1, temp2 + 1])
                   {

                       if (System.Windows.Forms.MessageBox.Show("Are you sure you want to leave the fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                       {
                           for (int q = 0; q < 9; q++)
                               for (int w = 0; w < 9; w++) if (fight.enems == wow.mapa[q, w]) wow.mapa[q, w].npc.heal(0, true);
                           {

                           }
                           fight.end_fight("None", glavno);
                       }
                       else return;
                   }

               if(temp2+1<vert && temp2<8)if (wow.mapa[temp1, temp2 + 1].npc != null)
               {

                   if (glavno.fighting)
                   {
                       if (fight.enems == wow.mapa[temp1, temp2 + 1])
                       {
                           if (fight.exchange_Hits(glavno))
                           {
                               for (int i = 0; i < vert; i++)
                                   for (int y = 0; y < hori; y++)
                                   {
                                       if (this.mapa[i, y] == wow.mapa[temp1, temp2+1]) mapa[i, y].kill_npc();
                                   }
                               wow.mapa[temp1 , temp2+1].kill_npc();
                           }
                       }


                   }

                   else if (wow.mapa[temp1, temp2 + 1].npc.type == "Merchant")
                   {
                       Shop shop = new Shop();
                       shop.set_Merc(wow.mapa[temp1, temp2 + 1].npc.lista);
                       if (shop.ShowDialog() == DialogResult.OK)
                       {
                           glavno.gold = shop.gold;
                           glavno.inventory = shop.glavnoInv;
                           wow.mapa[temp1 , temp2+1].npc.lista = shop.merc;
                           should_Invalidate_All = true;
                       }
                   }
                   else if (System.Windows.Forms.MessageBox.Show("There is minion on that block. Can't move there. DO you want to fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                   {
                       fight.start_fight(wow.mapa[temp1, temp2 + 1], wow.mapa[temp1, temp2], glavno);
                   }
               }

               else if (spawner.Y == (hori * 90) - (5 * 90))
               {
                   glavno.move_Down(true);
                   return;
               }
               else
               {
                   if (spawner.Y == 360)
                   {
                       if (glavno.location.Y < 360)
                       {
                           glavno.move_Down(true);
                           return;
                       }
                       else
                       {
                           spawner.Y += 90;
                           return;
                       }
                   }
                   else spawner.Y += 90;
               }
           }
       }
       
     
       public void move_Left(bool levo)
       {
           if (glavno.dead) return;
           System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Sounds\boink.wav");
           player.Play();
           if (glavno.upgrade_items)
           {
              // this.reseter();
               set_newItems();
               glavno.upgrade_items = false;
           }
           int temp1 = glavno.location.X / 90;
           int temp2 = glavno.location.Y / 90;
          if(levo)
          {

              if (glavno.fighting) if (fight.enems != wow.mapa[temp1-1, temp2 ])
                  {

                      if (System.Windows.Forms.MessageBox.Show("Are you sure you want to leave the fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                      {
                          for (int q = 0; q < 9; q++)
                              for (int w = 0; w < 9; w++) if (fight.enems == wow.mapa[q, w]) wow.mapa[q, w].npc.heal(0, true);
                          {

                          }
                          fight.end_fight("None", glavno);
                      }
                      else return;
                  }

            if (wow.mapa[temp1-1, temp2].npc != null)
              {

                  if (glavno.fighting)
                  {
                      if (fight.enems == wow.mapa[temp1-1, temp2 ])
                      {
                          if (fight.exchange_Hits(glavno))
                          {
                              for (int i = 0; i < vert; i++)
                                  for (int y = 0; y < hori; y++)
                                  {
                                      if (this.mapa[i, y] == wow.mapa[temp1 - 1, temp2]) mapa[i, y].kill_npc();
                                  }
                              wow.mapa[temp1 - 1, temp2].kill_npc();
                          }
                      }
                   


                  }

                  else if (wow.mapa[temp1-1, temp2].npc.type == "Merchant")
                  {
                      Shop shop = new Shop();
                      shop.set_Merc(wow.mapa[temp1-1, temp2].npc.lista);
                      if (shop.ShowDialog() == DialogResult.OK)
                      {
                         glavno.gold = shop.gold;
                          glavno.inventory = shop.glavnoInv;
                          wow.mapa[temp1 - 1, temp2].npc.lista = shop.merc;
                          should_Invalidate_All=true;
                      }
                  }
                  else if (System.Windows.Forms.MessageBox.Show("There is minion on that block. Can't move there. DO you want to fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                  {
                      fight.start_fight(wow.mapa[temp1-1, temp2], wow.mapa[temp1, temp2], glavno);
                  }
              }
              else  if (spawner.X == 360)
              {
                  glavno.move_Left(true);
                  return;
              }
              else
              {
                  if (spawner.X == (hori * 90) - (5 * 90))
                  {
                      if (glavno.location.X >= 450)
                      {
                         glavno.move_Left(true);
                          return;
                      }
                      else
                      {
                          spawner.X -= 90;
                          glavno.move_Left(false);
                          return;
                      }
                  }
                  else
                  {
                      spawner.X -= 90;
                  }
              }
          }
          else
          {

              if (glavno.fighting) if (fight.enems != wow.mapa[temp1+1, temp2])
                  {

                      if (System.Windows.Forms.MessageBox.Show("Are you sure you want to leave the fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                      {
                          for (int q = 0; q < 9; q++)
                              for (int w = 0; w < 9; w++) if (fight.enems == wow.mapa[q, w]) wow.mapa[q, w].npc.heal(0, true);
                          {

                          }
                          fight.end_fight("None", glavno);
                      }
                      else return;
                  }

              if(temp1+1<hori && temp1<8)if (wow.mapa[temp1 + 1, temp2].npc != null)
              {

                  if (glavno.fighting)
                  {
                      if (fight.enems == wow.mapa[temp1+1, temp2 ])
                      {
                         if( fight.exchange_Hits(glavno))
                         {
                             for (int i = 0; i < vert; i++)
                                 for (int y = 0; y < hori; y++)
                                 {
                                     if (this.mapa[i, y] == wow.mapa[temp1 + 1, temp2]) mapa[i, y].kill_npc();
                                 }
                                 wow.mapa[temp1 + 1, temp2].kill_npc();
                         }
                      }


                  }

                  else if (wow.mapa[temp1+1, temp2].npc.type == "Merchant")
                  {
                      Shop shop = new Shop();
                      shop.set_Merc(wow.mapa[temp1+1, temp2].npc.lista);
                      if (shop.ShowDialog() == DialogResult.OK)
                      {
                          glavno.gold = shop.gold;
                          glavno.inventory = shop.glavnoInv;
                          wow.mapa[temp1 + 1, temp2].npc.lista = shop.merc;
                          should_Invalidate_All = true;
                      }
                  }
                  else if (System.Windows.Forms.MessageBox.Show("There is minion on that block. Can't move there. DO you want to fight?", "FIght or not", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                  {
                      fight.start_fight(wow.mapa[temp1+1    , temp2 ], wow.mapa[temp1, temp2], glavno);
                  }
              }


              else  if (spawner.X == (hori * 90) - (5 * 90))
              {
                  glavno.move_Right(true);
                  return;
              }
              else
              {
                  if (spawner.X == 360)
                  {
                      if (glavno.location.X < 360)
                      {
                          glavno.move_Right(true);
                          return;
                      }
                      else
                      {
                          spawner.X += 90;
                          return;
                      }
                  }
                  else  spawner.X += 90;
              }
          }
       }
      

    }
}
