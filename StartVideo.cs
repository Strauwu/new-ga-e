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
        public StartVideo()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            StartMenu gameWindow = new StartMenu();

            if (e.newState == 8)
            {
                this.axWindowsMediaPlayer1.close(); // закрываем сам плеер, чтобы все ресурсы освободились
                this.Controls.Remove(axWindowsMediaPlayer1);
                gameWindow.Show();
                this.Hide();
            }
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            StartMenu gameWindow = new StartMenu();
            gameWindow.Show();

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            mp4Path = (Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\vid.mp4"));

            axWindowsMediaPlayer1.URL = mp4Path;
        }

        private void StartVideo_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.autoStart = true;


        }
    }
}
