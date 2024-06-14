using System.Drawing;

namespace new_ga_e.Entities
{
    sealed public partial class MapObjectModel
    {
        public PointF position;
        public Size size;

        public MapObjectModel(PointF pos, Size size) 
        { 
            this.position = pos;
            this.size = size;
        }
    }
}
