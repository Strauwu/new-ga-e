using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_ga_e
{
    public partial class StartVideo : Form
    {
        string mp4Path;
        StartMenu gameWindow = new StartMenu();
        EndGame end = new EndGame();


        bool IsSkipped = false;
        public StartVideo()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8 && !IsSkipped)
            {
                this.axWindowsMediaPlayer1.close(); 
                this.Controls.Remove(axWindowsMediaPlayer1);
                gameWindow.Show();
                this.Hide();
                
            }
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            IsSkipped = true;
            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.settings.mute = true;
            this.Hide();

            gameWindow.Show();
            //end.Show();





        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            mp4Path = (Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\vidd.mp4"));

            axWindowsMediaPlayer1.URL = mp4Path;
            
            axWindowsMediaPlayer1.enableContextMenu = false;
        }

        private void StartVideo_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.uiMode = "none";
            

        }

    }
}
