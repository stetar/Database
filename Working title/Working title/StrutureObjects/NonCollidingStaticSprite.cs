using Microsoft.Xna.Framework;
using Working_title.MapGenerator;

namespace Working_title
{
    public class NonCollidingStaticSprite : NonCollidingSprite
    {
        public NonCollidingStaticSprite(Vector2 position, Size size, string textureName) :
            base(position)
        {
            TextureSize = size;
            TextureName = textureName;
        }

        public NonCollidingStaticSprite(Vector2 position, Size size, string textureName,float layerDepth) :
            base(position)
        {
            TextureSize = size;
            TextureName = textureName;
            LayerDepth = layerDepth;
        }
    }
}