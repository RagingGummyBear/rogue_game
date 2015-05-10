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
using System.Windows.Forms;
using System.Reflection;
namespace Rogue_Game
{
    public partial class Shop : Form
    {
        public Point prev_click;
        public MainCharacter glavno = MainCharacter.Instance;
        public List<Item> merc = new List<Item>();
        public Item[,] glavnoInv = new Item[4, 5];
        public List<Item> pomos = new List<Item>();
        public int gold;
        int prev_item=99;
        Point prev_Item = new Point(99, 99);
        public Shop()
        {
            InitializeComponent();
            gold = glavno.gold;
            textBox4.Text = gold.ToString();
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.panel2, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.panel1, new object[] { true });
        }
        public void set_Merc(List<Item> Merc)
        {
          //  this.glavnoInv = glavno.inventory;
            for (int y = 0; y < 4; y++)
            {
                for(int w=0;w<5;w++)
                {
                    glavnoInv[y, w] = glavno.inventory[y, w];
                   
                }
            }
            for (int i = 0; i < Merc.Count; i++)
            {
                merc.Add(Merc[i]);
                pomos.Add(Merc[i]);
            }
        }
        private void Shop_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Point p = new Point(0, 0);

            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (glavnoInv[i, y] != null) glavnoInv[i, y].draw(e.Graphics, p);//48, 45

                    p.X += 48;
                }
                p.Y += 45;
                p.X = 0;
            }
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int counta = 0;

            Point p = new Point(0, 0);
            for (int i = 0; i < this.merc.Count; i++)//48, 45
            {
                counta++;
                if (counta == 4)
                {
                    counta = 0;
                    if(merc[i]!=null)merc[i].draw(e.Graphics, p);
                    p.Y += 45;
                    p.X = 0;
                }
                else
                {
                    if(merc[i]!=null)merc[i].draw(e.Graphics, p);
                    p.X += 48;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.merc = pomos;
          //  glavnoInv = pomos;
            this.DialogResult = DialogResult.Cancel;
        }

        private void panel2_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (prev_item != 99 && merc[prev_item]!=null) merc[prev_item].selected = false;
            Point temp = e.Location;
            //277; 42
            temp.X += 277;
            temp.Y += 42;
            prev_click = e.Location;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(temp);
            }
            if(e.Button==MouseButtons.Left)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                x /= 48;
                y /= 45;
                if (glavnoInv[y, x] != null) glavnoInv[y, x].selected = true;
             
                if (glavnoInv[y, x]!=null) this.textBox6.Text = glavnoInv[y, x].value.ToString();
                if(prev_Item.X!=99)
                {
                    if (glavnoInv[prev_Item.X, prev_Item.Y]!=null) glavnoInv[prev_Item.X, prev_Item.Y].selected = false;
                }
                if(this.prev_item!=99)
                {
                    if (merc[prev_item]!=null) merc[prev_item].selected = false;
                   
                }
                prev_Item = new Point(y, x);
                panel2.Invalidate();
                panel1.Invalidate();

            }
        }

        private void showStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //public Item[,] glavnoInv=new Item[4,5];
            // bitmap = new Bitmap(test, 65, 45);
            int x = prev_click.X;
            int y = prev_click.Y;
            x /= 48;
            y /= 45;


            if (glavnoInv[y, x] != null) MessageBox.Show(glavnoInv[y, x].ToString());


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void sellItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = prev_click.X;
            int y = prev_click.Y;
            x /= 48;
            y /= 45;
            if (glavnoInv[y, x] != null)
            {
                gold += glavnoInv[y, x].value;
                glavnoInv[y, x] = null;
            }
            panel2.Invalidate();
            textBox4.Text = gold.ToString();

        }

        private void panel1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (prev_Item.X != 99 && glavnoInv[prev_Item.X / 48, prev_Item.Y / 45] != null) glavnoInv[prev_Item.X / 48, prev_Item.Y / 45].selected = false;
                // MessageBox.Show("MOM I DID IT");
                
                int x = e.Location.X;
                int y = e.Location.Y;
                x /= 48;
                y /= 45;
                x += (4 * y);
                if (prev_item == x) return;
                if (merc[x] != null)
                {
                    this.textBox6.Text = merc[x].mValue.ToString();
                    merc[x].selected = true;
                }

                if (this.prev_item != 99)
                {
                    if (merc[prev_item]!=null) merc[prev_item].selected = false;
                   
                } 
                prev_item = x;
                panel1.Invalidate();
                panel2.Invalidate();

            }
            if (e.Button == MouseButtons.Right)
            {
                //12; 42
                Point pom1 = e.Location;
                pom1.X += 12;
                pom1.Y += 42;
                prev_click = e.Location;
                contextMenuStrip2.Show(pom1);
            }
        }

        private void showStatsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int x = prev_click.X;
            int y = prev_click.Y;
            x /= 48;
            y /= 45;
            x += (4 * y);
           if(merc[x]!=null) MessageBox.Show(merc[x].ToString());
        }

        private void buyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = prev_click.X;
            int y = prev_click.Y;
            x /= 48;
            y /= 45;
            x += (4 * y);
            if(merc[x]!=null)if (gold >= merc[x].mValue)
            {

                if (MessageBox.Show(String.Format("Are you sure you want to buy:" + merc[x].name + " " + merc[x].type()), "Buying item", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    for (int i = 0; i < 4; i++)
                        for (int w = 0; w < 5; w++)
                        {
                            if (glavnoInv[i, w] == null)
                            {
                                if (merc[x] == null) MessageBox.Show("WTF");
                                else gold -= merc[x].mValue;
                                glavnoInv[i, w] = merc[x];
                                merc[x] = null;
                                Invalidate(true);
                                textBox4.Text = gold.ToString();
                                return;
                            }
                        }
                    if (!(merc[x] == null))
                    {
                        MessageBox.Show("Inventory Full");
                    }

                }
            }
            else MessageBox.Show("Not enough gold");
            
        }
         
    }
}
