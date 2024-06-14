using new_ga_e.Controlles;
using System;
using System.IO;
using System.Windows.Forms;

namespace new_ga_e
{
    public partial class EndGame : Form
    {
        readonly StartMenu startmenu;
        string pathImg;
        public EndGame()
        {
            startmenu = new StartMenu();
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            if (MapPaint.timeleft <= 0)
                pathImg = "sprites\\badend.mp4";
            else
                pathImg = "sprites\\END.mp4";

            var mp4Path = (Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), pathImg));
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.uiMode = "none";
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
                axWindowsMediaPlayer1.close();
                Controls.Remove(axWindowsMediaPlayer1);
                startmenu.Show();
                Hide();
            }
        }

        private void EndGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
