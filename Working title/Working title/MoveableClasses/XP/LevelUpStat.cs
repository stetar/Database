namespace Working_title.MoveableClasses.XP
{
    public class LevelUpStat
    {
        private GrowthStat MaxHealthGrowthStat = new GrowthStat(2, 2);
        private GrowthStat HealthGrowthStat = new GrowthStat(2, 2);
        private GrowthStat ManaGrowthStat = new GrowthStat(2, 10);
        private GrowthStat DamageGrowthStat = new GrowthStat(2, 2);

        private PlayerStat PlayerStat;

        public LevelUpStat()
        {
            PlayerStat = new PlayerStat();
        }

        public PlayerStat CalculateLevelUpStats(int level)
        {
            PlayerStat.Health = HealthGrowthStat.GetGrowthValue(level);
            PlayerStat.Mana = ManaGrowthStat.GetGrowthValue(level);
            PlayerStat.Damage = DamageGrowthStat.GetGrowthValue(level);
            PlayerStat.MaxHealth = MaxHealthGrowthStat.GetGrowthValue(level);
            return PlayerStat;
        }
    }
}