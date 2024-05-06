using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_ga_e.View
{
   
    public class PaintPlayerAnimation
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool IsMoving;
        public bool IsHealing;

        public int currentAnimation;
        public int currentLimit;
        public int currentFrame;

        public int flip;

        public int countFrames;

        public static int rightFrame = 12;



        public int size;

        public Image gero;

        public PaintPlayerAnimation(int posX, int posY, int rightFrame, Image gero)
        {
            this.posX = posX;
            this.posY = posY;

            gero = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\gero.png"));

            this.countFrames = rightFrame;
            this.gero= gero;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = rightFrame;
            size = 30;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else
                currentFrame = 0;
            g.DrawImage(gero, new Rectangle(new Point(posX, posY), new Size(size, size)), 32 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);
        }
    }
}
