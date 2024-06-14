using System.Drawing;

namespace new_ga_e.View
{
    public static class PaintTimer
    {
        public static void DrawTimer(Graphics g, int timeLose)
        {
            g.DrawString("До конца игры: " + (timeLose / 1000).ToString(), new Font("Epilepsy Sans", 14, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(200, 5));
        }
    }
}
