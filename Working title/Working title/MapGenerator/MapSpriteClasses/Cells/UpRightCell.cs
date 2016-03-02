using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.Cells
{
    public class UpRightCell : NonCollidingSprite
    {
        public UpRightCell(Vector2 position, Size size) :
            base(position)
        {
            TextureName = "UpRight";
            TextureSize = size;
        }

    }
}