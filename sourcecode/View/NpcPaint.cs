using new_ga_e.View;
using System.Drawing;
using System.IO;

namespace new_ga_e.Models
{
    public class NpcPaint
    {
        private Image sprite;
        private string nameSprite;
        private NpcEntity npc;

        public void PaintNPC(Graphics g, bool IsHealed, NpcEntity NPC)
        {
            npc = NPC;
            if (IsHealed) nameSprite = "sprites\\kind.png";
            else nameSprite = "sprites\\evill.png";

            sprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), nameSprite));

            g.DrawImage(sprite, new Rectangle(new Point(npc.posX, npc.posY), new Size(npc.sizex, npc.sizey)), 0, 0, npc.sizex, npc.sizey, GraphicsUnit.Pixel);
        }
    }
}
