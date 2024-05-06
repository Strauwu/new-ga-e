
using System;
using System.Drawing;
using System.Windows.Forms;
using new_ga_e.AudioGame;

namespace new_ga_e.Entities
{
    public class PlayerEntity
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

        public static int rightFrame = 12;

        public int size;

        public Image spriteSheet;

        public PlayerEntity(int posX, int posY, int rightFrame, Image spriteSheet)
        { 
            this.posX = posX;
            this.posY = posY;
            this.countFrames = rightFrame;
            this.spriteSheet = spriteSheet;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = rightFrame;
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
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX,posY), new Size(size, size)),32*currentFrame, 32*currentAnimation, size, size, GraphicsUnit.Pixel);
        }
      
        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = countFrames;
                    break;
                case 1 :
                    currentLimit = countFrames;
                    break;
                case 2:
                    currentLimit = countFrames;
                    break;
                case 3:
                    currentLimit = countFrames;
                    break;
                case 4:
                    currentLimit = countFrames;
                    break;
                case 5:
                    currentLimit = countFrames;
                    break;

            }
        }
    }
}
