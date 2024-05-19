using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_ga_e
{
    public partial class EndGame : Form
    {
        string mp4Path;
        StartMenu startmenu = new StartMenu();
        public EndGame()
        {
            InitializeComponent();
        }
       
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.uiMode = "none";

            mp4Path = (Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\END.mp4"));

            axWindowsMediaPlayer1.URL = mp4Path;

            axWindowsMediaPlayer1.enableContextMenu = false;
        }
       
        private void EndGame_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_PlayStateChange_1(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                this.axWindowsMediaPlayer1.close();
                this.Controls.Remove(axWindowsMediaPlayer1);
                startmenu.Show();
                this.Hide();
            }
        }

        private void EndGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
