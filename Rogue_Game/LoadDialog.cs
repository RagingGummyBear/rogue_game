using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rogue_Game
{
    public partial class LoadDialog : Form
    {
        public String picked;
        public LoadDialog()
        {
            InitializeComponent();
            
            //checkedListBox1.Items.Add("crying");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkedListBox1.SelectedItem != null)
            {
                
               picked = (String)this.checkedListBox1.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadDialog_Load(object sender, EventArgs e)
        {
           // FileStream fs = new FileStream(@"Resources\", FileMode.Open);
            string[] fileEntries = Directory.GetFiles(@"SaveGames\");
            foreach (string fileName in fileEntries)
                if(fileName.EndsWith(".bin"))checkedListBox1.Items.Add(fileName);
            /*
            IFormatter formatter = new BinaryFormatter();
            Stream stream1 = new FileStream(@"SaveGames\mySaves.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            List<String> games = (List<String>)formatter.Deserialize(stream1);
            MessageBox.Show(games.Count.ToString());
            for (int i = 0; i < games.Count; i++)
            {
                checkedListBox1.Items.Add(games[i]);
                //MessageBox.Show(games[i].ToString());
            }
            stream1.Close();*/
        }
    }
}
