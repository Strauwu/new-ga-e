using System.Drawing;

namespace new_ga_e.Entities
{
    public partial class MapParamers
    {
        public PointF position;
        public Size size;

        public MapParamers(PointF pos, Size size) 
        { 
            this.position = pos;
            this.size = size;
        }
    }
}
