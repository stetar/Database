using System.Collections.Generic;
using Working_title.Enemies;
using Working_title.MoveableClasses.XP;

namespace Working_title.MoveableClasses
{
    public class PlayerItems
    {
        private Dictionary<EnemyDropType,PlayerStat> MyItems = new Dictionary<EnemyDropType, PlayerStat>();
        private UpdatePlayerStats UpdatePlayerStats;

        public Dictionary<EnemyDropType, PlayerStat> Items => MyItems;

        public PlayerItems(UpdatePlayerStats updatePlayerStats)
        {
            UpdatePlayerStats = updatePlayerStats;
        }

        public void AddItemIfNotExist(EnemyDropType enemyDropType,PlayerStat playerStat)
        {
            if (!MyItems.ContainsKey(enemyDropType))
            {
                MyItems.Add(enemyDropType, playerStat);
                UpdatePlayerStats.AddPlayerStats(playerStat);
            }
            
        }


    }
}