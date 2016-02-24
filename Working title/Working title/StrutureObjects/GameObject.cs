using Microsoft.Xna.Framework;

namespace Working_title
{
    public abstract class GameObject
    {
        public Vector2 Position;

        protected GameObject(Vector2 position)
        {
            Position = position;
        }

        public virtual void Update(float deltaTime)
        {
            
        }

        public virtual void Die()
        {
            
        }
    }
}