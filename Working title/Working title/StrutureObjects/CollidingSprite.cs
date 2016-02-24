using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title
{
    public abstract class CollidingSprite : Sprite
    {

        public Rectangle CollisionBox
        {
            get
            {
                if (Texture != null && TextureSize.IsEmpty())
                {
                    return new Rectangle(Position.ToPoint(),
                        new Point((int)(Texture.Width * Scale.X), (int)(Texture.Height * Scale.Y)));
                }
                else if (!TextureSize.IsEmpty())
                {
                    return new Rectangle(Position.ToPoint(),TextureSize.ToPoint());
                }

                return new Rectangle();
            }
        }

        protected CollidingSprite(Vector2 position) :
            base(position)
        {

        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            CheckCollision();
        }

        protected virtual void OnCollision(List<CollidingSprite> collidingSprites)
        {
            
        }

        private void CheckCollision()
        {
            List<CollidingSprite> CollidingSprites = Game1.CollidingSprites.FindAll(
                sprite => sprite.CollidingWith(CollisionBox));

            OnCollision(CollidingSprites);
        }

        public bool CollidingWith(Rectangle otherSprite)
        {
            return otherSprite.Intersects(CollisionBox);
        }
    }
}