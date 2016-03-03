using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Working_title.MoveableClasses;

namespace Working_title.Combat
{
    public class KillableSprite : CollidingSprite
    {
        public int MaxHealth = 3;
        public Limit HealthLimit;

        public int Health
        {
            get { return MyHealth; }
            set { MyHealth = (int)HealthLimit.GetWithinLimit(value); }
        }

        private int MyHealth;

        public KillableSprite(Vector2 position) :
            base(position)
        {
            HealthLimit = new Limit(MaxHealth);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ShouldDie();
        }

        protected virtual void ShouldDie()
        {
            if (Health <= HealthLimit.MinLimit)
            {
                Die();
            }
        }
    }
}