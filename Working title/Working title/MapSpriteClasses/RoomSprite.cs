using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title
{
    public class RoomSprite : CollidingSprite
    {
        public RoomSprite(Vector2 position,Size size) :
            base(position)
        {
            TextureName = "Blue";
            TextureSize = size;
        }
    }
}