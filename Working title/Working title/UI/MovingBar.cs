using Microsoft.Xna.Framework;
using Working_title.Combat;
using Working_title.MapGenerator;

namespace Working_title.UI
{
    public abstract class MovingBar : Bar
    {
        private GameObject MovingObject;
        private Vector2 Offset;

        public MovingBar(Size fullSize, GameObject movingObject, Vector2 offset) :
                base(movingObject.Position, fullSize)
        {
            MovingObject = movingObject;
            Offset = offset;
        }

        public override void Update(GameTime gameTime)
        {
            ShouldDie();
            Position = MovingObject.Position + Offset;
            base.Update(gameTime);
        }

        private void ShouldDie()
        {
            if (MovingObject.IsDead)
            {
                Die();
            }
        }
    }
}