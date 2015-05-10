using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rogue_Game;
using Rogue_Game.GameMode;

namespace Rogue_Game
{
    public partial class LevelUp : Form
    {
        public MainCharacter glavno = MainCharacter.Instance;
        public d3vector stats = new d3vector();
        public int unused = 0;
        public LevelUp()
        {
           

            InitializeComponent();
        }

        private void LevelUp_Load(object sender, EventArgs e)
        {
           
            textBox2.Text = String.Format("{0}",glavno.unused_Stats);
            textBox3.Text = String.Format("{0}", glavno.stats.x);
            textBox4.Text = String.Format("{0}", glavno.stats.y);
            textBox5.Text = String.Format("{0}", glavno.stats.z);
            unused = glavno.unused_Stats;
            this.stats.x = glavno.stats.x;
            this.stats.y = glavno.stats.y;
            this.stats.z = glavno.stats.z;
        }

        private void button1_Click(object sender, EventArgs e)
        {       
       }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.stats.x = glavno.stats.x;
            this.stats.y = glavno.stats.y;
            this.stats.z = glavno.stats.z;
            this.DialogResult = DialogResult.Cancel;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (unused > 0)
            {
                unused--;
                textBox2.Text = String.Format("{0}", unused);
                stats.x++;
                textBox3.Text = String.Format("{0}", stats.x);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (unused > 0)
            {
                unused--;
                textBox2.Text = String.Format("{0}", unused);
                stats.y++;
                textBox4.Text = String.Format("{0}", stats.y);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (unused > 0)
            {
                unused--;
                textBox2.Text = String.Format("{0}", unused);
                stats.z++;
                textBox5.Text = String.Format("{0}", stats.z);
            }
        }
    }
}
