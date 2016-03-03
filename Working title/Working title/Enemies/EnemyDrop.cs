using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Working_title.MapGenerator;
using Working_title.MoveableClasses;
using Working_title.MoveableClasses.XP;

namespace Working_title.Enemies
{
    public class EnemyDrop : CollidingSprite
    {
        private PlayerStat PlayerStat;
        private EnemyDropType EnemyDropType;

        public EnemyDrop(Vector2 position, Size size, string textureName,PlayerStat playerStat, EnemyDropType enemyDropType ) :
            base(position)
        {
            TextureSize = size;
            TextureName = textureName;
            PlayerStat = playerStat;
            EnemyDropType = enemyDropType;
        }

        protected override void OnCollision(List<CollidingSprite> collidingSprites)
        {
            base.OnCollision(collidingSprites);
            
        }
    }
}