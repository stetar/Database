using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Working_title.Cells.Factory;
using Working_title.Enemies;
using Working_title.MapGenerator;

namespace Working_title.Cells
{
    public class SpawedCell : NonCollidingSprite
    {
        protected int ProcentChanceToSpawnEnemy = 10;

        private EnemyTier EnemyTier = new EnemyTier();
        private Random Random;

        protected Vector2 EnemySpawnPosition;
        protected Size EnemySpawnSize;

        public SpawedCell(Vector2 position,Size size,string textureName) :
            base(position)
        {
            TextureName = textureName;
            Random = new Random(GetHashCode());
            TextureSize = size;
            EnemySpawnPosition = Position;
            EnemySpawnSize = TextureSize;
            ShouldSpawnEnemy();
        }

        protected void ShouldSpawnEnemy()
        {
            int RandomPercent = Random.Next(0, 100);
            if (RandomPercent <= ProcentChanceToSpawnEnemy)
            {
                SpawnEnemy(EnemySpawnPosition);
            }
        }

        protected void SpawnEnemy(Vector2 position)
        {
            EnemyFactory EnemyFactory = new EnemyFactory();
            EnemyCreator EnemyCreator = new EnemyCreator(EnemyFactory, position, EnemyTier.GetRandomTier(), EnemySpawnSize);
            Game1.AddObjectInNextCycle(EnemyCreator.CreateObject());
        }

        
    }
}