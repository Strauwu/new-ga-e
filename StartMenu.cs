using new_ga_e.AudioGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_ga_e
{
    public partial class StartMenu : Form
    {
        private bool isf = true;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public StartMenu()
        {
            player.SoundLocation = "Backmusic.wav";

            InitializeComponent();
            //button2.Click += button2_Click;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Audi_Cantum videoWindow = new Audi_Cantum();
            videoWindow.Show();
            this.Hide();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {
           player.PlayLooping();
           
        }

        private void StartMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
           player.Stop();


        }
    }
}
