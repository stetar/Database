using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title.Cells
{
    public class DownLeftCell : NonCollidingSprite
    {
        public DownLeftCell(Vector2 position, Size size) :
            base(position)
        {
            TextureName = "DownLeft";
            TextureSize = size;
        }

    }
}