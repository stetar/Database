using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.Cells
{
    public class RightRightCell : NonCollidingSprite
    {
        public RightRightCell(Vector2 position, Size size) :
            base(position)
        {
            TextureName = "RightRight";
            TextureSize = size;
        }

    }
}