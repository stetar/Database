using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title
{
    public class WallSprite : CollidingSprite
    {
        public WallSprite(Vector2 position, Size size) :
            base(position)
        {
            TextureName = "Black";
            TextureSize = size;
        }

    }
}