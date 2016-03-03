using System;
using Working_title.MoveableClasses.XP;

namespace Working_title.MoveableClasses
{
    public class UpdatePlayerStats
    {
        public Level Level;

        private Player Player;
        private PlayerStat PlayerStat = new PlayerStat();
        private LevelUpStat LevelUpStat = new LevelUpStat();

        public UpdatePlayerStats(Player player)
        {
            Level = new Level();
            Game1.AddObjectInNextCycle(Level);
            Level.OnLevelUp += OnLevelUp;
            Player = player;
        }

        public void AddPlayerStats(PlayerStat playerStat)
        {
            PlayerStat += playerStat;
            Update();
        }

        private void Update()
        {
            Player.Damage = PlayerStat.Damage;
            Player.MaxHealth = PlayerStat.MaxHealth;
            Player.HealthLimit.SetMaxLimit(Player.MaxHealth);
            Player.Health = PlayerStat.Health;
        }

        public void AddXp(int xp)
        {
            Level.AddXp(xp);
        }

        private void OnLevelUp(object sender, EventArgs eventArgs)
        {
            AddPlayerStats(LevelUpStat.CalculateLevelUpStats(Level.CurrentLevel));
        }
    }
}