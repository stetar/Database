using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.Enemies
{
    public class StandardEnemy : Enemy
    {
        public StandardEnemy(Vector2 position, int enemyTier,Size size) : 
            base(position,enemyTier, size)
        {
            LayerDepth = 0.5f;
        }
    }
}