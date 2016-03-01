using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.Cells
{
    public class UpUpCell : NonCollidingSprite
    {
        public UpUpCell(Vector2 position, Size size) :
            base(position)
        {
            TextureName = "UpUp";
            TextureSize = size;
        }

    }
}