using new_ga_e.AudioGame;
using new_ga_e.Controlles;
using System.Drawing;
using System.IO;


namespace new_ga_e.View
{
    public static class PaintAudioGame
    {
        private static Image audiobar;
        private static Image greybar;
        private static int powerOfNoise;

        public static void Init()
        {
            MapPaint.Init();
            audiobar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\audiobar.jpg"));
            greybar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\grey.jpg"));
            powerOfNoise = Audio.powerOfNoise;
        }

      
        public static void PlayAnimation(Graphics g)
        {
            g.DrawImage(audiobar, new Rectangle(new Point(0, 0), new Size(powerOfNoise, 10)), 0, 0, 1, 1, GraphicsUnit.Pixel);
        }

        public static void PlayAnimationForHeal(Graphics g, int minHeal, int maxHeal)
        {
            g.DrawImage(greybar, new Rectangle(new Point(minHeal, 0), new Size(maxHeal - minHeal, 10)), 0, 0, 10, 10, GraphicsUnit.Pixel);
        }
    }

}
