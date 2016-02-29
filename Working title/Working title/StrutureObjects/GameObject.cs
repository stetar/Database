using Microsoft.Xna.Framework;

namespace Working_title
{
    public abstract class GameObject
    {
        public Vector2 Position;
        protected float DeltaTime;
        protected float TotalGameTime;

        protected GameObject(Vector2 position)
        {
            Position = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            DeltaTime = (float) gameTime.ElapsedGameTime.TotalMilliseconds;
            TotalGameTime = (float) gameTime.TotalGameTime.TotalMilliseconds;
        }

        public virtual void Die()
        {
            
        }
    }
}