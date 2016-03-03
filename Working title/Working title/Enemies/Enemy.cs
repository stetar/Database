using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Working_title.Combat;
using Working_title.DataBase;
using Working_title.Managers;
using Working_title.MapGenerator;
using Working_title.MoveableClasses;
using Working_title.MoveableClasses.XP;
using Working_title.UI;

namespace Working_title.Enemies
{
    public class Enemy : AttackingSprite
    {
        public int Tier;

        public int Xp =>
            2 * Tier * GameManager.Level;

        private Player Player;

        public Enemy(Vector2 position,int enemyTier,Size size) : 
            base(position)
        {
            Tier = enemyTier;
            LoadStats(enemyTier);
            TextureSize = size;
            AddHealthBar();
        }

        protected virtual void AddHealthBar()
        {
            Game1.AddObjectInNextCycle(new HealthBar(new Size(TextureSize.Width, 10), this, new Vector2(0, -(float)TextureSize.Width / 2)));
        }


        protected void LoadStats(int enemyTier)
        {
            DataBaseConnector DataBaseConnector = new DataBaseConnector();
            DatabaseReader DatabaseReader = new DatabaseReader(DataBaseConnector.Connect("Enemies.db"), 
                "Select * from Enemies where tier = '" + enemyTier + "'");
            int NumberOfEnemies = DatabaseReader.GetColumnValues("ID").Count;
            int RandomNumber = new Random().Next(0, NumberOfEnemies);
            MaxHealth = Convert.ToInt32(DatabaseReader.GetColumnValues("HP")[RandomNumber]);
            Health = Convert.ToInt32(DatabaseReader.GetColumnValues("HP")[RandomNumber]);
            Damage = Convert.ToInt32(DatabaseReader.GetColumnValues("damage")[RandomNumber]);
            TextureName = (string)DatabaseReader.GetColumnValues("navn")[RandomNumber];
        }



        protected override void DoDamage(AttackingSprite attackingSprite)
        {
            if (attackingSprite is Player)
            {
                Player = (Player)attackingSprite;
                base.DoDamage(attackingSprite);
            }
        }

        public override void Die()
        {
            base.Die();
            Player.UpdatePlayerStats?.AddXp(Xp);
        }
    }
}