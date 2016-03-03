using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.Cells.Factory
{
    public class EnemyCreator : Creator
    {
        public int Tier;
        public Size Size;

        public EnemyCreator(MapGenerator.Factory factory, Vector2 startPosition,int tier,Size size) :
            base(factory, startPosition)
        {
            Tier = tier;
            Size = size;
        }
    }
}