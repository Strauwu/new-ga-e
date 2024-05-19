using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_ga_e.Controlles
{
    public static class npcNhero
    {
        public static bool IsNearby(int x1, int x2, int y1, int y2)
        {
            var dist = (double)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            if (dist < 50) 
                return true;
            else
                return false;
        }

    }
}
