using System;
using System.IO;
using System.Windows.Forms;

namespace new_ga_e
{
    sealed public partial class StartVideo : Form
    {
        private readonly StartMenu startMenu;

        bool IsSkipped;
        public StartVideo()
        {
            startMenu = new StartMenu();
            IsSkipped = false;
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8 && !IsSkipped)
            {
                axWindowsMediaPlayer1.close();
                Controls.Remove(axWindowsMediaPlayer1);
                startMenu.Show();
                Hide();
            }
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            IsSkipped = true;
            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.settings.mute = true;
            Hide();
            startMenu.Show();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            var mp4Path = (Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\vidd.mp4"));
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
