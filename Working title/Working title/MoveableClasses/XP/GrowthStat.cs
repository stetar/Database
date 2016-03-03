using System;

namespace Working_title.MoveableClasses.XP
{
    public class GrowthStat
    {
        private float GrowthExponentialNumber = 2;
        private int BaseNumber = 5;

        public GrowthStat(float growthExponentialNumber,int baseNumber)
        {
            GrowthExponentialNumber = growthExponentialNumber;
            BaseNumber = baseNumber;
        }

        public int GetGrowthValue(int level)
        {
            return (int)Math.Round(BaseNumber +  Math.Pow(GrowthExponentialNumber, level));
        }
    }
}