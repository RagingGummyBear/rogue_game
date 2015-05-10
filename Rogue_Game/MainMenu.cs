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
    public partial class MainMenu : Form
    {
        public Form1 glavna;
        public MainMenu()
        {
            InitializeComponent();
          /*  IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("mySaves.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            List<string> saveGames = new List<string>();
            formatter.Serialize(stream, saveGames);
            stream.Close();
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Sounds\New game.wav");
            player.Play();
            glavna=new Form1();
            glavna.allSet(1, 0, new Point(360, 360), new d3vector(25, 20, 20), new Item[4, 5], new Equipment(), 0, 0,100);
            this.Hide();
            glavna.ShowDialog();
            this.Show();    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            glavna = new Form1();
            this.Hide();
            if(glavna.load())
                glavna.ShowDialog();
            this.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
