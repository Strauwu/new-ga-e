using new_ga_e.AudioGame;
using new_ga_e.Controlles;
using new_ga_e.Entities;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using new_ga_e.AudioGame;


namespace new_ga_e.View
{
    public class PaintAudioGame
    {
        public static Image playerSheet;
        public static Image audiobar;
        
        
        public static int powerOfNoise;

        public static void Init()
        {
            MapModel.Init();
            audiobar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\audiobar.jpg"));
            powerOfNoise = Audio.powerOfNoise;

        }


        public static void PlayAnimation(Graphics g)
        {
            g.DrawImage(audiobar, new Rectangle(new Point(0, 0), new Size(5*powerOfNoise, 5)), 0,0,10,10, GraphicsUnit.Pixel);
        }
    }

}
