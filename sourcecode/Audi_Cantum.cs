using new_ga_e.AudioGame;
using new_ga_e.Controlles;
using new_ga_e.Entities;
using new_ga_e.Models;
using new_ga_e.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace new_ga_e
{
    public partial class Audi_Cantum : Form
    {
        public PlayerPaint player;
        public EndGame endgame;
        public static NpcEntity[] npcList;
        public static List<NpcEntity> healednpc;
        public static int timeLose;
        public NpcEntity npcEntity1;
        public NpcEntity npcEntity2;
        public NpcEntity npcEntity3;
        public NpcEntity npcEntity4;
        public NpcEntity npcEntity5;
        public NpcEntity npcEntity6;
        public NpcEntity npcEntity7;
        public NpcEntity npcEntity8;
        public NpcEntity npcEntity9;
        public NpcEntity npcEntity10;
        public NpcEntity npcEntity11;

        public NpcPaint npcPaint;

        public Audi_Cantum()
        {
            InitializeComponent();
            timer1.Interval = 30;
            timeLose = 290000;
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
            player = new PlayerPaint(120, 110);
            endgame = new EndGame();
            healednpc = new List<NpcEntity>();
            npcPaint = new NpcPaint();
            npcList = new NpcEntity[]{
                npcEntity1 = new NpcEntity(140, 140,90,100),
                npcEntity2 = new NpcEntity(390, 160,250,400),
                npcEntity3 = new NpcEntity(440, 460, 300, 340),
                npcEntity4 = new NpcEntity(390, 380, 490, 540),
                npcEntity5 = new NpcEntity(600, 550, 220, 270),
                npcEntity6 = new NpcEntity(560, 50, 430, 460),
                npcEntity7 = new NpcEntity(30, 550, 300, 400),
                npcEntity8 = new NpcEntity(340, 80, 100, 120),
                npcEntity9 = new NpcEntity(200, 440, 200, 250),
                npcEntity10 = new NpcEntity(580, 340, 100, 120),
                npcEntity11 = new NpcEntity(20, 240, 160, 190)
            };
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapPaint.DrawMap(g);
            player.PlayAnimation(g);
            if (player.IsHealing)
            {
                PaintAudioGame.Init();
                foreach(NpcEntity npc in npcList)
                    if (npcNhero.IsNearby(player.posX, npc.posX, player.posY, npc.posY))
                    {
                        PaintAudioGame.PlayAnimationForHeal(g, npc.minHeal, npc.maxHeal);
                        PaintAudioGame.PlayAnimation(g);
                        if (HealSibiling.IsHealSuccses(npc.minHeal, npc.maxHeal))
                        {
                            npc.IsHealed = true;
                            if (!healednpc.Contains(npc)) healednpc.Add(npc);
                        }
                    }
            }
            foreach (NpcEntity npc in npcList)
                npcPaint.PaintNPC(g, npc.IsHealed, npc);

            if (healednpc.Count == 11 || timeLose <= 0)
            {
                Hide(); endgame.Show();
            }
            PaintTimer.DrawTimer(g, timeLose);
        }

        public void Update(object sender, EventArgs e)
        {
            if (!PhysicsController.IsCollideMap(player, new Point(player.dirX, player.dirY)) 
                && !PhysicsController.IsCollideNPC(player, new Point(player.dirX, player.dirY)))
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
                case Keys.A:
                    player.dirX = -2;
                    player.SetAnimationConfiguration(4);
                    break;
                case Keys.D:
                    player.dirX = 2;
                    player.SetAnimationConfiguration(5);
                    break;
                case Keys.W:
                    player.dirY = -2;
                    player.SetAnimationConfiguration(2);
                    break;
                case Keys.S:
                    player.dirY = 2;
                    player.SetAnimationConfiguration(3);
                    break;
               
            }
        }
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.F:
                    player.IsHealing = false;
                    Audio.Stopp();
                    break;
            }

            if (player.dirX == 0 && player.dirY == 0)
            {
                player.IsMoving = false;
                if (player.IsHealing == false)
                    player.SetAnimationConfiguration(0);
                player.SetAnimationConfiguration(0);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                player.IsMoving = false;
                player.IsHealing = true;
                player.dirX = 0;
                player.dirY = 0;
                player.SetAnimationConfiguration(1);
                Audio.Recording();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLose -= 12;
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
