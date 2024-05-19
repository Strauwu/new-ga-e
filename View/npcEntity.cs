using new_ga_e.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace new_ga_e.View
{
    public class npcEntity
    {

        public int posX;
        public int posY;

    

        public bool IsMoving;
        public bool IsHealed;






        public int sizex;
        public int sizey;
   

        public Image kind;
        public Image notkind;


        public npcEntity(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            kind = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\kind.png"));
            notkind = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\evill.png"));
            IsHealed = false;
            sizex = 30;
            sizey = 45;
        }

        public void PaintKind(Graphics g)
        {
            g.DrawImage(kind, new Rectangle(new Point(posX,posY), new Size(sizex, sizey)), 0, 0, sizex,sizey, GraphicsUnit.Pixel);
        }
        public void PaintNotKind(Graphics g)
        {
            g.DrawImage(notkind, new Rectangle(new Point(posX, posY), new Size(sizex, sizey)), 0, 0, sizex, sizey, GraphicsUnit.Pixel);

        }
    }
}
