using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Working_title.MapGenerator;

namespace Working_title.Cells
{
    public class UpLeftCell : NonCollidingSprite
    {
        public UpLeftCell(Vector2 position,Size size) :
            base(position)
        {
            TextureName = "UpLeft";
            TextureSize = size;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
             base.Draw(spriteBatch);
        }
    }
}