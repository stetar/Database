using System;
using Working_title.Managers;

namespace Working_title.Enemies
{
    public class EnemyTier
    {
        public const int MaxTier = 5;
        public const int TierLevelAdder = 2;

        private Random Random;

        public EnemyTier()
        {
            Random = new Random();
        }
        public int GetRandomTier()
        {
            int WantedMaxTier = GameManager.Level + TierLevelAdder;
            if (WantedMaxTier > MaxTier)
            {
                WantedMaxTier = MaxTier;
            }

            return Random.Next(1, WantedMaxTier);
        }
    }
}