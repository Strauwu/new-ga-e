using new_ga_e.AudioGame;
using new_ga_e.Controlles;
using new_ga_e.Entities;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using new_ga_e.AudioGame;
using new_ga_e.Models;


namespace new_ga_e.View
{
    public class PaintAudioGame
    {
        public static Image playerSheet;
        public static Image audiobar;
        public static Image greybar;


        public static int powerOfNoise;
        public static int NeedForHealing;
        public static int MaxForHealing;
        public static Random z;
        public static Random k;
        public static int npcNumber;

        public static void Init()
        {
            MapPaint.Init();
            audiobar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\audio.jpg"));
            greybar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\grey.jpg"));
            powerOfNoise = Audio.powerOfNoise;

        }


        public static void PlayAnimation(Graphics g)
        {
                g.DrawImage(audiobar, new Rectangle(new Point(0, 0), new Size(powerOfNoise, 10)), 0,0,10,10, GraphicsUnit.Pixel);
        }

        public static void PlayAnimationForHeal(Graphics g,int x, int y)
        {
            NeedForHealing = x;
            MaxForHealing = y;
            g.DrawImage(greybar, new Rectangle(new Point(NeedForHealing, 0), new Size(MaxForHealing - NeedForHealing, 10)), 0, 0, 10, 10, GraphicsUnit.Pixel);
        }
    }

}
