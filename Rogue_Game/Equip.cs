using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rogue_Game
{
    public partial class Equip : Form
    {
        public Item item;
        public Equip()
        {

            InitializeComponent();
           
        }

        private void Equip_Load(object sender, EventArgs e)
        {
 textBox2.Text = item.name+" "+item.type();    //OVA KE TREBA DA SE IZMENI MALKU POIKE
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
