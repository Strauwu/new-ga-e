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
using System.Security.Policy;
using new_ga_e.Models;
using AxWMPLib;
using System.Linq;
using System.Collections.Generic;

namespace new_ga_e
{
    public partial class Audi_Cantum : Form
    {
        public Image playerSheet;
        public PlayerPaint player;
        public PaintAudioGame paintAudioGame;
        public EndGame endgame;
        public npcEntity[] npcList;
        public List<npcEntity> healednpc;
        public Audio audi;
        public npcEntity npcEntity1;
        public npcEntity npcEntity2;
        public npcEntity npcEntity3;
        public npcEntity npcEntity4;
        public npcEntity npcEntity5;
        public npcEntity npcEntity6;
        public npcEntity npcEntity7;
        public npcEntity npcEntity8;
        public npcEntity npcEntity9;

       
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
            MapPaint.Init();
            Width = MapPaint.GetWidth();
            Height = MapPaint.GetHeight();
            playerSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\gero.png"));
            player = new PlayerPaint(120, 110, PlayerPaint.rightFrame, playerSheet);
            audi = new Audio();
            endgame = new EndGame();
            healednpc = new List<npcEntity>();
            
            npcList = new npcEntity[]{
                npcEntity1 = new npcEntity(140, 140),
                npcEntity2 = new npcEntity(390, 160),
                npcEntity3 = new npcEntity(440, 460),
                npcEntity4 = new npcEntity(390, 380),
                npcEntity5 = new npcEntity(600, 550),
                npcEntity6 = new npcEntity(560, 50),
                npcEntity7 = new npcEntity(30, 550),
                npcEntity8 = new npcEntity(340, 80),
                npcEntity9 = new npcEntity(200, 440)
            };
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapPaint.DrawMap(g);
            player.PlayAnimation(g);

            if (player.IsHealing)
            {
                
                PaintAudioGame.Init();
                PaintAudioGame.PlayAnimation(g);

                foreach(npcEntity entity in npcList)
                {
                    if (npcNhero.IsNearby(player.posX, entity.posX, player.posY, entity.posY))
                    {
                        PaintAudioGame.PlayAnimationForHeal(g, 100, 140);

                        if (HealSibiling.IsHealSuccses(100, 140))
                        {
                            entity.IsHealed = true;
                            if (!healednpc.Contains(entity)) healednpc.Add(entity);
                        }
                    }
                }                          
            }

            foreach (npcEntity entity in npcList)
            {
                if(entity.IsHealed) entity.PaintKind(g);
                else entity.PaintNotKind(g);
            }

            if (healednpc.Count==3)
            {
                Hide();
                endgame.Show();
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
            player.IsMoving = true;

            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -2;
                    player.SetAnimationConfiguration(2);
                    break;
                case Keys.S:
                    player.dirY = 2;
                    player.SetAnimationConfiguration(3);
                    break;
                case Keys.A:
                    player.dirX = -2;
                    player.SetAnimationConfiguration(4);
                    break;
                case Keys.D:
                    player.dirX = 2;
                    player.SetAnimationConfiguration(5);
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
                    player.IsHealing = false;
                    audi.Stopp();
                    break;
            }
          
            if (player.dirX == 0 && player.dirY == 0)
            {
                player.IsMoving = false;
                if (player.IsHealing==false)
                    player.SetAnimationConfiguration(0);
                player.SetAnimationConfiguration(0);
                  
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F)
            {
                player.IsMoving = false;
                player.IsHealing = true;
                player.dirX = 0;
                player.dirY = 0;
                player.SetAnimationConfiguration(1);
                audi.Recording();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Audi_Cantum_Click(object sender, EventArgs e)
        {
            
        }
    }
}
