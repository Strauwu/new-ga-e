namespace new_ga_e.Models
{
    public class HealSibiling
    {

        public static bool IsHealSuccses(int needForHeal, int maxForHeal)
        {
            if (AudioGame.Audio.powerOfNoise >= needForHeal && AudioGame.Audio.powerOfNoise <= maxForHeal)
                return true;
            return false;
        }
    }
}
