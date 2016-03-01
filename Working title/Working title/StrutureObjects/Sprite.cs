using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Working_title.MapGenerator;

namespace Working_title
{
    public abstract class Sprite : GameObject
    {
        protected Color DrawColor = Color.White;
        protected float Rotation;
        protected float LayerDepth;
        protected Size TextureSize = new Size(0, 0);
        protected SpriteEffects SpriteEffects = SpriteEffects.None;
        protected string TextureName = "";
        protected Texture2D Texture;
        protected Vector2 Scale = new Vector2(1,1);
        protected Vector2 Origin = new Vector2(0, 0);

        protected Rectangle DestinationRectangle => new Rectangle(Position.ToPoint(),TextureSize.ToPoint());

        protected Sprite(Vector2 position) :
            base(position)
        {
            
        }

        protected Sprite(Vector2 position,float rotation) :
           base(position)
        {
            Rotation = rotation;
        }


        public virtual void LoadContent()
        {
            Texture = Game1.Textures[TextureName];
            if (TextureSize.IsEmpty())
            {
                TextureSize = new Size((int)(Texture.Width * Scale.X), (int)(Texture.Height * Scale.Y));
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, null, DestinationRectangle, null, Origin,Rotation,Scale,DrawColor,SpriteEffects,LayerDepth);
        }
    }
}