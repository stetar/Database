using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Working_title.MapGenerator;

namespace Working_title
{
    public class DoorSprite : NonCollidingSprite
    {
        public DoorSprite(Vector2 position, Size size) :
            base(position)
        {
            TextureName = "Yellow";
            TextureSize = size;
            LayerDepth = 1;
        }

        
    }
}