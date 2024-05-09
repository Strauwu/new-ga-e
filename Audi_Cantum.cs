using new_ga_e.AudioGame;
using new_ga_e.Controlles;
using new_ga_e.Entities;

using new_ga_e;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using new_ga_e.View;

namespace new_ga_e
{
    public partial class Audi_Cantum : Form
    {
        public Image playerSheet;
        public PlayerEntity player;
        public Audio audi;
        bool repeat = true;

        public Audi_Cantum()
        {
            InitializeComponent();

            timer1.Interval = 30;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            timer1.Start();
            Init();
        }

        public void Init()
        {
            MapModel.Init();
            Width = MapModel.GetWidth();
            Height = MapModel.GetHeight();
            playerSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\gero.png"));
            player = new PlayerEntity(120, 110, PlayerEntity.rightFrame, playerSheet);
            audi = new Audio(10);
            timer1.Start();
            

        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
                MapModel.DrawMap(g);
            player.PlayAnimation(g);
            if (player.IsHealing )
            {
                PaintAudioGame.Init();
                PaintAudioGame.PlayAnimation(g);

            }
        }

        public void Update(object sender, EventArgs e)
        {

            if (!PhysicsController.IsCollide(player, new Point(player.dirX, player.dirY)))
            {
                if (player.IsMoving)
                    player.Move();
            }
           
            Invalidate();
        }

      

        public void OnPress(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -2;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(2);
                    break;
                case Keys.S:
                    player.dirY = 2;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(3);
                    break;
                case Keys.A:
                    player.dirX = -2;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(4);
                    break;
                case Keys.D:
                    player.dirX = 2;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(5);
                    break;
                case Keys.F:
                    
                    player.IsMoving = false;
                    player.IsHealing = true;
                    player.SetAnimationConfiguration(1);
                    if ((e.KeyCode == Keys.F) && repeat && player.IsHealing)
                    {
                        audi.Recording();
                    }
                    
                    break;
            }

        }
        public void OnKeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
                case Keys.F:
                    player.dirY = 0;
                    player.dirX = 0;
                    player.IsHealing = false;
                    
                    audi.Stopp();
                    break;
            }
          
            if (player.dirX == 0 && player.dirY == 0)
            {
                player.IsMoving = false;
                if (player.IsHealing==false)
                {
                    player.SetAnimationConfiguration(0);
                }
                player.SetAnimationConfiguration(0);
                  
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
       
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
