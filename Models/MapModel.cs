using System.Drawing;

namespace new_ga_e.Entities
{
    public partial class MapModel
    {
        public PointF position;
        public Size size;

        public MapModel(PointF pos, Size size) 
        { 
            this.position = pos;
            this.size = size;
        }
    }
}
