using System.Drawing;
using System.IO;

namespace new_ga_e.Entities
{
    public partial class PlayerPaint
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
        public int countFrames;
        public int size;
        public Image spriteSheet;

        public PlayerPaint(int posX, int posY)
        {
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\gero.png"));
            this.posX = posX;
            this.posY = posY;
            countFrames = 12;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = 12;
            size = 30;
        }

        public void Move()
        {
            posX += dirX;
            posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else
                currentFrame = 0;
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(size, size)), 32 * currentFrame, 32 * currentAnimation, size, size, GraphicsUnit.Pixel);
        }

        public virtual void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;
        }
    }
}
