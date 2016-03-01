using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.Cells
{
    public class DownRightCell : NonCollidingSprite
    {
        public DownRightCell(Vector2 position, Size size) :
            base(position)
        {
            TextureName = "DownRight";
            TextureSize = size;
        } 

    }
}