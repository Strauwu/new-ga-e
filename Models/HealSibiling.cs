using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_ga_e.Models
{
    public static class HealSibiling
    {
        public static Random random;
        public static int NeedForHeal;
        public static int MaxForHeal;

        public static bool IsHealSuccses(int needForHeal, int maxForHeal)
        {
            NeedForHeal = needForHeal;
            MaxForHeal = maxForHeal;
            if(AudioGame.Audio.powerOfNoise >= needForHeal && AudioGame.Audio.powerOfNoise <=maxForHeal)
            {
                return true;
            }
            return false;
        }
    }
}
