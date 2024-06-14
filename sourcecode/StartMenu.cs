using System;
using System.IO;
using System.Windows.Forms;

namespace new_ga_e
{
    sealed public partial class StartMenu : Form
    {
        private readonly System.Media.SoundPlayer player;

        public StartMenu()
        {
            player = new System.Media.SoundPlayer(((Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\Backmusic.wav"))));
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Audi_Cantum gameWindow = new(); 

            gameWindow.Show();
            Hide();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
