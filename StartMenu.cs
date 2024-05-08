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
        Form Form1;
        public StartMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Form1 videoWindow = new Form1();
            videoWindow.Show();
            this.Hide();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {

        }

        private void StartMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
