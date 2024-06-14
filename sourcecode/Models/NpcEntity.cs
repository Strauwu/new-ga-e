
namespace new_ga_e.View
{
    public class NpcEntity
    {
        public int posX;
        public int posY;
        public int minHeal;
        public int maxHeal;
        public bool IsHealed;
        public int sizex;
        public int sizey;

        public NpcEntity(int posX, int posY, int minHeal, int maxHeal)
        {
            this.posX = posX;
            this.posY = posY;
            this.minHeal = minHeal;
            this.maxHeal = maxHeal;
            IsHealed = false;
            sizex = 12;
            sizey = 32;
        }
    }
}
