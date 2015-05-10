using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rogue_Game.GameMode;
using System.Reflection;
using Rogue_Game.items;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Rogue_Game
{
    public partial class Form1 : Form
    {
        String equip;
        d3vector selected_item=new d3vector();

        Fabrika fact = Fabrika.Instance;
        public BlockGrid mapa = BlockGrid.Instance;
      public MainCharacter glavno = MainCharacter.Instance;
      Point last_clicked;
      float brojac = 0;
        
        public Form1()
        {
            
            MainCharacter.extra_exp = false;
            Combat.combat_log = false;
            //Item[,] testerio = new Item[4, 9];
            this.DoubleBuffered = true;
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null,this.panel2, new object[] { true });
           // pictureBox1.Image = Image.FromFile(@"Resources\ground.jpg");
            panel2.BackgroundImage = Image.FromFile(@"Resources\ground.jpg");
            pictureBox1.Image = Image.FromFile(@"Resources\FaceShot.jpg");
            glavno.dead = false;
         //   timer1.
            brojac = 0;
         /*   new System.Threading.Thread(() =>
            {
              
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Sounds\gameSong.wav");
                player.PlayLooping();
               // player.PlaySync();
            }).Start();*/
            
            
        }

        public void allSet(int level, int level_progress, Point Location, d3vector Stats, Item[,] Inventory, Equipment Equip, int unused, int Gold,int health)
        {
            glavno.allSet(level, level_progress, Location, Stats, Inventory, Equip, unused,  Gold,health);
            mapa.reseter();

         }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           // temp.location = e.Location;
           // Invalidate(true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           // temp.draw(e.Graphics);
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          //  temp.location = e.Location;
           // Invalidate(true);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            Point temp = glavno.location;
            if (e.Location.Y < temp.Y && e.Location.Y > temp.Y - 90 && e.Location.X > temp.X && e.Location.X < temp.X + 90)
            {
                if (temp.Y - 90 >= 0)
                {
                    mapa.move_Up(true);
                }
            }
            if (e.Location.Y < temp.Y+180 && e.Location.Y > temp.Y + 90 && e.Location.X > temp.X && e.Location.X < temp.X + 90)
            {
                if (temp.Y + 90 <= BlockGrid.vert*90)
                {
                    mapa.move_Up(false);
                }
            }
            if (e.Location.Y < temp.Y + 90 && e.Location.Y > temp.Y && e.Location.X > temp.X+90 && e.Location.X < temp.X +180)
            {
                if (temp.X + 90 <= BlockGrid.hori*90)
                {

                    mapa.move_Left(false);
                }
            }
            if (e.Location.Y < temp.Y + 90 && e.Location.Y > temp.Y  && e.Location.X > temp.X-90 && e.Location.X < temp.X )
            {
                if (temp.X - 90 >= 0)
                {

                    mapa.move_Left(true);
                }
            }
            if (e.Location.Y > temp.Y && e.Location.Y < temp.Y + 90 && e.Location.X > temp.X && e.Location.X < temp.X + 90)
            {
                if (mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].kovceg != null) if (mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].kovceg.oppened) // ZASTO OPPENED SUM GO KRSTIL?! 
                        if (mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].priroda != null)
                        {
                            if (mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].priroda.value() == 3)
                            {
                                if (!mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].priroda.used)
                                {
                                    BushBerry bb = new BushBerry();
                                    DialogResult dr = bb.ShowDialog();
                                    if (dr == DialogResult.OK)
                                    {
                                        mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].priroda.used = true;
                                        glavno.add_Item(new Berry());
                                    }
                                    else if (dr == DialogResult.Yes)
                                    {
                                        mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].priroda.used = true;
                                        glavno.heal(30, true);
                                    }

                                }
                            }
                        }
                        else
                        {

                        }
                    else
                    {

                    }
                    else
                    {
                        if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda != null)
                        {
                            if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.value() == 3)
                            {
                                if (!mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used)
                                {
                                    BushBerry bb = new BushBerry();
                                    DialogResult dr = bb.ShowDialog();
                                    if (dr == DialogResult.OK)
                                    {
                                        mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used = true;
                                        glavno.add_Item(new Berry());
                                    }
                                    else if (dr == DialogResult.Yes)
                                    {
                                        mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used = true;
                                        glavno.heal(30, true);
                                    }

                                }
                            }
                        }
                    }

                if (mapa.wow.mapa[e.Location.X/90, e.Location.Y/90].kovceg != null)
                {
                    if (glavno.add_Item(mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].kovceg.open()))
                    {
                        mapa.wow.mapa[e.Location.X / 90, e.Location.Y / 90].kovceg.reset();
                    }
                    else
                        mapa.open_Chest(e.Location.X / 90, e.Location.Y / 90);
                }
                

            }       
           if(glavno.should_Invalidate_All || mapa.should_Invalidate_All)
            Invalidate(true);
           else
           {
               panel5.Invalidate();
               panel2.Invalidate();
           }
           if(glavno.dead)timer1.Start();

           glavno.should_Invalidate_All = false;
           mapa.should_Invalidate_All = false;
           

        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
          //  temp.location = e.Location;
          //  Invalidate(true);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            mapa.draw(e.Graphics);
        }

        private void panel2_MouseMove_1(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            last_clicked = e.Location;
            
            if (e.Button == MouseButtons.Right)
            {
                int x = e.X / 90;
            int y = e.Y / 90;

           Point temp = glavno.location;
           if (e.Location.Y < temp.Y && e.Location.Y > temp.Y - 90 && e.Location.X > temp.X && e.Location.X < temp.X + 90)
           {
               if (temp.Y - 90 >= 0)
               {
                   if (mapa.wow.mapa[x, y].npc != null)
                   {

                       contextMenuStripA.Show(e.Location);
                   }
                   else
                       if (mapa.wow.mapa[x, y].kovceg != null) contextMenuStripC.Show(e.Location);
                       else contextMenuStripp.Show(e.Location);
               }
           }
           else if (e.Location.Y < temp.Y + 180 && e.Location.Y > temp.Y + 90 && e.Location.X > temp.X && e.Location.X < temp.X + 90)
           {
               if (temp.Y + 90 <= 720)
               {
                   if (mapa.wow.mapa[x, y].npc != null)
                   {

                       contextMenuStripA.Show(e.Location);
                   }
                   else
                       if (mapa.wow.mapa[x, y].kovceg != null) contextMenuStripC.Show(e.Location);
                       else contextMenuStripp.Show(e.Location);

               }
           }
           else if (e.Location.Y < temp.Y + 90 && e.Location.Y > temp.Y && e.Location.X > temp.X + 90 && e.Location.X < temp.X + 180)
           {
               if (temp.X + 90 <= 720)
               {

                   if (mapa.wow.mapa[x, y].npc != null)
                   {
                       contextMenuStripA.Show(e.Location);
                   }
                   else
                       if (mapa.wow.mapa[x, y].kovceg != null) contextMenuStripC.Show(e.Location);
                       else contextMenuStripp.Show(e.Location);

               }
           }
           else if (e.Location.Y < temp.Y + 90 && e.Location.Y > temp.Y && e.Location.X > temp.X - 90 && e.Location.X < temp.X)
           {
               if (temp.X - 90 >= 0)
               {

                   if (mapa.wow.mapa[x, y].npc != null)
                   {
                       contextMenuStripA.Show(e.Location);
                   }
                   else
                       if (mapa.wow.mapa[x, y].kovceg != null) contextMenuStripC.Show(e.Location);
                       else contextMenuStripp.Show(e.Location);

               }
           }
           else if (e.Location.Y > temp.Y && e.Location.Y < temp.Y + 90 && e.Location.X > temp.X && e.Location.X < temp.X + 90)
           {
               if (mapa.wow.mapa[x, y].npc != null)
               {
                   contextMenuStripA.Show(e.Location);
               }                                                            
               else
                   if (mapa.wow.mapa[x, y].kovceg != null) contextMenuStripC.Show(e.Location);
                   else contextMenuStripp.Show(e.Location);

           }
           else contextMenuStripp.Show(e.Location);

            //Invalidate(true);
           
              //  contextMenuStripp.Show(e.Location);
               
                //int x = e.X / 90;
                //int y = e.Y / 90;
               // mapa.wow.mapa[x, y].show_Content();
            }
        }

        private void showContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showContentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapa.wow.mapa[(last_clicked.X / 90), (last_clicked.Y / 90)].show_Content();
        }

        private void contextMenuStrip4_Opening(object sender, CancelEventArgs e)
        {
           // mapa.wow.mapa[(last_clicked.X / 90), (last_clicked.Y / 90)].show_Content();
        }

        private void openChestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(glavno.add_Item(mapa.wow.mapa[(last_clicked.X / 90), (last_clicked.Y / 90)].kovceg.open()))
            {
                mapa.wow.mapa[(last_clicked.X / 90), (last_clicked.Y / 90)].kovceg.reset();
            }
            else mapa.open_Chest((last_clicked.X / 90), (last_clicked.Y / 90));
            Invalidate(true);
        }

        private void showContentToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            mapa.wow.mapa[(last_clicked.X / 90), (last_clicked.Y / 90)].show_Content();
        }

        private void attackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           mapa.attack(last_clicked.X / 90, last_clicked.Y / 90);
           }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_Right_hand(e.Graphics);
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[0, 0]!=null) glavno.inventory[0, 0].draw(e.Graphics);
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[0, 1]!=null) glavno.inventory[0, 1].draw(e.Graphics);
        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[0, 2] != null) glavno.inventory[0, 2].draw(e.Graphics);
        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[0, 3] != null) glavno.inventory[0, 3].draw(e.Graphics);
        }

        private void flowLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[0, 4] != null) glavno.inventory[0, 4].draw(e.Graphics);
        }

        private void flowLayoutPanel12_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[1, 0] != null) glavno.inventory[1, 0].draw(e.Graphics);
        }

        private void flowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[1, 1] != null) glavno.inventory[1, 1].draw(e.Graphics);
        }

        private void flowLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[1, 2] != null) glavno.inventory[1, 2].draw(e.Graphics);
        }

        private void flowLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[1, 3] != null) glavno.inventory[1, 3].draw(e.Graphics);
        }

        private void flowLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[1, 4] != null) glavno.inventory[1, 4].draw(e.Graphics);
        }

        private void flowLayoutPanel18_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[2, 0] != null) glavno.inventory[2, 0].draw(e.Graphics);
        }

        private void flowLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[2, 1] != null) glavno.inventory[2, 1].draw(e.Graphics);
        }

        private void flowLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[2, 2] != null) glavno.inventory[2, 2].draw(e.Graphics);
        }

        private void flowLayoutPanel15_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[2, 3] != null) glavno.inventory[2, 3].draw(e.Graphics);
        }

        private void flowLayoutPanel16_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[2, 4] != null) glavno.inventory[2, 4].draw(e.Graphics);
        }

        private void flowLayoutPanel17_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[3, 0] != null) glavno.inventory[3, 0].draw(e.Graphics);
        }

        private void flowLayoutPanel19_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[3, 1] != null) glavno.inventory[3, 1].draw(e.Graphics);
        }

        private void flowLayoutPanel20_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[3, 2] != null) glavno.inventory[3, 2].draw(e.Graphics);
        }

        private void flowLayoutPanel21_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[3, 3] != null) glavno.inventory[3, 3].draw(e.Graphics);
        }

        private void flowLayoutPanel22_Paint(object sender, PaintEventArgs e)
        {
            if (glavno.inventory[3, 4] != null) glavno.inventory[3, 4].draw(e.Graphics);
        }

        private void flowLayoutPanel4_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {

                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 0;
                selected_item.y = 0;
               
                selected_item.z = 1;
                if(glavno.inventory[(int)selected_item.x,(int)selected_item.y]!=null)contextMenuStrip2.Show(temp);
               /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    glavno.inventory[0, 0].kill();
                    glavno.inventory[0, 0] = null;
                }*/
            }
        }

        private void flowLayoutPanel3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 0;
                selected_item.y = 1;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
              /*  if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    last_clicked = e.Location;
                    glavno.inventory[0, 1].kill();
                    glavno.inventory[0, 1] = null;
                }*/
            }
        }

        private void flowLayoutPanel5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 0;
                selected_item.y = 2;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.BlueViolet);
            glavno.calculate_bonus();
            
            e.Graphics.DrawString(String.Format("{0}{1}Level:{2}",glavno.stats,glavno.bonuses,glavno.level),font,brush,new Point(0,0));
            font.Dispose();
            brush.Dispose();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void destroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
          int temp1= (int)selected_item.x;
           int temp2=(int)selected_item.y;
            if(selected_item.z==1)
            {
                glavno.inventory[temp1, temp2].kill();
                glavno.inventory[temp1, temp2] = null;

            }
            Invalidate(true);
            selected_item.x = 0;
            selected_item.y = 0;
            selected_item.z = 0;
        }

        private void flowLayoutPanel6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 0;
                selected_item.y = 3;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 0;
                selected_item.y = 4;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel12_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 1;
                selected_item.y = 0;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 1;
                selected_item.y = 1;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 1;
                selected_item.y = 2;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 1;
                selected_item.y = 3;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel11_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 1;
                selected_item.y = 4;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel18_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 2;
                selected_item.y = 0;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel13_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 2;
                selected_item.y = 1;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel14_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 2;
                selected_item.y = 2;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel15_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 2;
                selected_item.y = 3;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel16_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 2;
                selected_item.y = 4;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel17_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 3;
                selected_item.y = 0;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel19_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 3;
                selected_item.y = 1;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel20_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 3;
                selected_item.y = 2;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel21_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 3;
                selected_item.y = 3;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void flowLayoutPanel22_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point temp = new Point(884, 693);
                temp.X += e.X;
                temp.Y += e.Y;
                selected_item.x = 3;
                selected_item.y = 4;
                selected_item.z = 1;
                if (glavno.inventory[(int)selected_item.x, (int)selected_item.y] != null) contextMenuStrip2.Show(temp);
                /* if (System.Windows.Forms.MessageBox.Show("Do you want to delete this item?", "Destroying item", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                 {
                     glavno.inventory[0, 0].kill();
                     glavno.inventory[0, 0] = null;
                 }*/
            }
        }

        private void equipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int temp1 = (int)selected_item.x;
            int temp2 = (int)selected_item.y;
            if (selected_item.z == 1)
            {
                Item pomosen = glavno.inventory[temp1, temp2];
                glavno.inventory[temp1, temp2].kill();
               glavno.inventory[temp1, temp2] = null;
                if(glavno.equip(pomosen)) glavno.add_Item(pomosen);
                

            }
            Invalidate(true);
            selected_item.x = 0;
            selected_item.y = 0;
            selected_item.z = 0;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_Left_hand(e.Graphics);
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_shoulders(e.Graphics);
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_gloves(e.Graphics);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_helmet(e.Graphics);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_chest(e.Graphics);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_legs(e.Graphics);
            
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            glavno.equipment.draw_boots(e.Graphics);
        }

        private void unequipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item pomosen;
            if(equip=="shoulders")
            {
               pomosen = glavno.equipment.shoulders;
                if(pomosen != null)
                {
                    if(!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.shoulders = null;
                    }
                }
            }
            if (equip == "left_hand")
            {
                pomosen = glavno.equipment.left_hand;
                if (pomosen != null)
                {
                    if (!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.left_hand = null;
                    }
                }
            }
            if(equip=="right_hand")
            {
                pomosen = glavno.equipment.right_hand;
                if (pomosen != null)
                {
                    if (!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.right_hand = null;
                    }
                }
            }
            if(equip=="helmet")
            {
                pomosen = glavno.equipment.helmet;
                if (pomosen != null)
                {
                    if (!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.helmet = null;
                    }
                }
            }
            if(equip=="chest")
            {
                pomosen = glavno.equipment.chest;
                if (pomosen != null)
                {
                    if (!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.chest = null;
                    }
                }
            }
            if(equip=="legs")
            {
                pomosen = glavno.equipment.legs;
                if (pomosen != null)
                {
                    if (!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.legs = null;
                    }
                }
            }
            if(equip=="boots")
            {
                pomosen = glavno.equipment.boots;
                if (pomosen != null)
                {
                    if (!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.boots = null;
                    }
                }
            }
            if(equip=="gloves")
            {
                pomosen = glavno.equipment.gloves;
                if (pomosen != null)
                {
                    if (!glavno.add_Item(pomosen))
                    {
                        glavno.equipment.gloves = null;
                    }
                }
            }
            equip = " ";
            Invalidate(true);
       /*     glavno.inventory[temp1, temp2].kill();
            glavno.inventory[temp1, temp2] = null;
            if (glavno.equip(pomosen)) glavno.add_Item(pomosen);*/
        }

        private void destroyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Item pomosen;
            if (equip == "shoulders")
            {
                pomosen = glavno.equipment.shoulders;
                if (pomosen != null)
                {
                   
                        glavno.equipment.shoulders = null;
                    }
                
            }
            if (equip == "left_hand")
            {
                pomosen = glavno.equipment.left_hand;
                if (pomosen != null)
                {
                  
                        glavno.equipment.left_hand = null;
                    
                }
            }
            if (equip == "right_hand")
            {
                pomosen = glavno.equipment.right_hand;
                if (pomosen != null)
                {
                   
                        glavno.equipment.right_hand = null;
                    
                }
            }
            if (equip == "helmet")
            {
                pomosen = glavno.equipment.helmet;
                if (pomosen != null)
                {
                    
                        glavno.equipment.helmet = null;
                    
                }
            }
            if (equip == "chest")
            {
                pomosen = glavno.equipment.chest;
                if (pomosen != null)
                {
                    
                        glavno.equipment.chest = null;
                    
                }
            }
            if (equip == "legs")
            {
                pomosen = glavno.equipment.legs;
                if (pomosen != null)
                {
                    
                        glavno.equipment.legs = null;
                    
                }
            }
            if (equip == "boots")
            {
                pomosen = glavno.equipment.boots;
                if (pomosen != null)
                {
                    
                        glavno.equipment.boots = null;
                    
                }
            }
            if (equip == "gloves")
            {
                pomosen = glavno.equipment.gloves;
                if (pomosen != null)
                {

                        glavno.equipment.gloves = null;
                    
                }
            }
            Invalidate(true);
        }
        //859; 335

        private void panel12_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                equip = "shoulders";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void panel11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                equip = "helmet";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void panel13_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                equip = "gloves";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void panel10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                equip = "chest";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void panel9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                equip = "legs";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                equip = "boots";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                equip = "right_hand";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                equip = "left_hand";
                Point temp = new Point(884, 335);
                temp.X += e.X;
                temp.Y += e.Y;
                contextMenuStrip3.Show(temp);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Point temp = glavno.location;
            if(e.KeyCode==Keys.NumPad0)
            {
                if(glavno.has_berry) 
                {
                    glavno.use_Berry();   
                }
                Invalidate(true);
            }
            if (e.KeyCode == Keys.S)
            {
                LevelUp up = new LevelUp();
                if (up.ShowDialog() == DialogResult.OK)
                {
                    glavno.stats = up.stats;
                    glavno.unused_Stats = up.unused;
                    glavno.should_Invalidate_All = true;
                }
            }
            if(e.KeyCode==Keys.Up)
            {
                if (temp.Y - 90 >= 0)
                {
                    mapa.move_Up(true);
                }
                if (glavno.should_Invalidate_All || mapa.should_Invalidate_All) Invalidate(true);
                else
                {
                    panel2.Invalidate();
                    panel5.Invalidate();

                }
                glavno.should_Invalidate_All = false;
                mapa.should_Invalidate_All = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (temp.Y + 90 <= BlockGrid.vert * 90)
                {
                    mapa.move_Up(false);
                }
                if (glavno.should_Invalidate_All || mapa.should_Invalidate_All) Invalidate(true);
                else
                {
                    panel2.Invalidate();
                    panel5.Invalidate();

                }
                glavno.should_Invalidate_All = false;
                mapa.should_Invalidate_All = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (temp.X - 90 >= 0)
                {

                    mapa.move_Left(true);
                }
                if (glavno.should_Invalidate_All || mapa.should_Invalidate_All) Invalidate(true);
                else
                {
                    panel2.Invalidate();
                    panel5.Invalidate();
                }
                glavno.should_Invalidate_All = false;
                mapa.should_Invalidate_All = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (temp.X + 90 <= BlockGrid.hori * 90)
                {
                    
                    mapa.move_Left(false);
                }
                if (glavno.should_Invalidate_All || mapa.should_Invalidate_All) Invalidate(true);
                else
                {
                    panel2.Invalidate();
                    panel5.Invalidate();

                }
                glavno.should_Invalidate_All = false;
                mapa.should_Invalidate_All = false;
            }
            if(e.KeyCode==Keys.Space)
            {
                if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].kovceg != null) if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].kovceg.oppened) // ZASTO OPPENED SUM GO KRSTIL?! 
                        if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda != null)
                        {
                            if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.value() == 3)
                            {
                                if (!mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used)
                                {
                                    BushBerry bb = new BushBerry();
                                    DialogResult dr = bb.ShowDialog();
                                    if (dr== DialogResult.OK)
                                    {
                                        mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used = true;
                                        glavno.add_Item(new Berry());
                                    }
                                    else if (dr == DialogResult.Yes)
                                    {
                                        mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used = true;
                                        glavno.heal(30, true);
                                    }

                                }
                            }
                        }
                        else
                        {

                        }
                else
                    {

                    }
                else
                    {
                        if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda != null)
                        {
                            if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.value() == 3)
                            {
                                if (!mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used)
                                {
                                    BushBerry bb = new BushBerry();
                                    DialogResult dr = bb.ShowDialog();
                                    if (dr == DialogResult.OK)
                                    {
                                        mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used = true;
                                        glavno.add_Item(new Berry());
                                    }
                                    else if (dr == DialogResult.Yes)
                                    {
                                        mapa.wow.mapa[temp.X / 90, temp.Y / 90].priroda.used = true;
                                        glavno.heal(30, true);
                                    }

                                }
                            }
                        }
                    }

                if (mapa.wow.mapa[temp.X / 90, temp.Y / 90].kovceg != null)
                {
                    if (glavno.add_Item(mapa.wow.mapa[temp.X / 90, temp.Y / 90].kovceg.open()))
                    {
                        mapa.wow.mapa[temp.X / 90, temp.Y / 90].kovceg.reset();
                    }
                    else
                        mapa.open_Chest(temp.X / 90, temp.Y / 90); 

                }
                if (glavno.should_Invalidate_All || mapa.should_Invalidate_All) Invalidate(true);
                else panel2.Invalidate();
            }
            if (glavno.dead) timer1.Start();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
            
                Brush brush = new SolidBrush(Color.Red);
                Brush brush2 = new SolidBrush(Color.DarkRed);
                Brush brush3 = new SolidBrush(Color.Teal);
                Brush brush4 = new SolidBrush(Color.Blue);
                Point Poin = new Point(15, 165);
                Point Poin2 = new Point(15, 185);
                if (glavno == null) glavno = MainCharacter.Instance;
                glavno.calculate_bonus();
                float temp = glavno.bonuses.health / glavno.bonuses.maxHealth;
                float temp2 = (panel5.Size.Width - 35);
                float temp3;
                temp3 = (float)glavno.level_Progress / (float)glavno.level_up_exp;
               // MessageBox.Show(glavno.level_up_exp.ToString());
                      temp *= (panel5.Size.Width-35);
                      temp3 *= (panel5.Size.Width - 35);
                Size size = new Size((int)temp, 15);
                Size size2 = new Size((int)temp2, 15);
                Size size3 = new Size((int)temp3,15);
                e.Graphics.FillRectangle(brush3, new Rectangle(Poin2, size2));
                e.Graphics.FillRectangle(brush2, new Rectangle(Poin, size2));
                e.Graphics.FillRectangle(brush, new Rectangle(Poin, size));
                e.Graphics.FillRectangle(brush4, new Rectangle(Poin2, size3));
                brush.Dispose();
                brush2.Dispose();
                brush3.Dispose();
                brush4.Dispose();
            
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int temp1 = (int)selected_item.x;
            int temp2 = (int)selected_item.y;
            if (selected_item.z == 1)
            {
                MessageBox.Show(glavno.inventory[temp1, temp2].ToString());
                //glavno.inventory[temp1, temp2].kill();
                //glavno.inventory[temp1, temp2] = null;

            }
            Invalidate(true);
            selected_item.x = 0;
            selected_item.y = 0;
            selected_item.z = 0;
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog temp=new SaveDialog();
            if (DialogResult.OK == temp.ShowDialog())
            {
                int pomosno = (int)(glavno.bonuses.health / glavno.bonuses.maxHealth*100);
                //(int Level, int Level_progress, Point Location, d3vector Stats, Item[,] Inventory, Equipment Equip, int Unused, int Gold)
                SaveCharacter coveceto = new SaveCharacter(glavno.level, glavno.level_Progress, glavno.location, glavno.stats, glavno.inventory, glavno.equipment, glavno.unused_Stats, glavno.gold,pomosno);
                String name=temp.name;
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SaveGames\");
                sb.Append(name);
                sb.Append(".bin");
               IFormatter formatter = new BinaryFormatter();
                /*Stream stream1 =null;
               List<String> games = new List<String>();
               try
               {
                   stream1 = new FileStream(@"SaveGames\mySaves.bin", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                   games = (List<String>)formatter.Deserialize(stream1);
                   games.Add(name);
                   formatter.Serialize(stream1, games);
                   stream1.Close();

               }
               catch (IOException z)
               {
                   //  stream1.Close();
                   stream1 = new FileStream(@"SaveGames\mySaves.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                   games.Add(name);
                   formatter.Serialize(stream1, games);
                   stream1.Close();

               }*/
                Stream stream = new FileStream(sb.ToString(), FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, coveceto);
                stream.Close();

                /*
                Stream stream3 = new FileStream("mySavess.bin", FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
                List<String>tests= (List<String>)formatter.Deserialize(stream3);
               // SaveCharacter tests= (SaveCharacter)formatter.Deserialize(stream3);
                  MessageBox.Show(tests[0]);
                  stream3.Close();*/
            }
        }
        public bool load()
        {
            StringBuilder sb = new StringBuilder();
            LoadDialog ld = new LoadDialog();
            //sb.Append(@"SaveGames\");
            if (ld.ShowDialog() == DialogResult.OK)
            {
                sb.Append(ld.picked);
              //  sb.Append(".bin");
            }
            else return false;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(sb.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
            SaveCharacter coveceto = (SaveCharacter)formatter.Deserialize(stream);
            stream.Close();
           glavno= MainCharacter.Instance;
            glavno.allSet(coveceto.level, coveceto.level_progress, new Point(360, 360), coveceto.stats, coveceto.inventory, coveceto.equip, coveceto.unused, coveceto.gold,coveceto.health);
            mapa.reseter();
            Invalidate(true);
            return true;
        }
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.load();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the game?", "Exiting the game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.DialogResult = DialogResult.OK;
        }

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.reseter();
            Invalidate(true);
        }

        private void combatLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Combat.combat_log)
            {
                Combat.combat_log = false;
            }
            else
                Combat.combat_log = true;
        }

        private void extraExpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MainCharacter.extra_exp)
            {
                MainCharacter.extra_exp = false;
            }
            else
            {
                MainCharacter.extra_exp = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            brojac++;
            if(glavno.switchimg)
            {
                glavno.switchimg = false;
            }
            else
            {
                glavno.switchimg = true;
            }
            panel2.Invalidate();
            if(brojac>=15)
            {
                timer1.Stop();
              
                DialogResult = DialogResult.OK;
                
            }
            
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void spawnMoreBossesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.more_bosses();
        }

        private void getExpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavno.add_Exp(10000);
        }

        private void getGoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavno.gold += 10000;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
