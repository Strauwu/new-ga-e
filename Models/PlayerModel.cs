using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_ga_e.Models
{
    public partial class PlayerModel
    {
        public int posX;
        public int posY;

        public PlayerModel(int posX, int posY) {
            this.posX = posX;
            this.posY = posY;
        }
    }
}
