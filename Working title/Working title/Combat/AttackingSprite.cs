using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.Combat
{
    public class AttackingSprite : KillableSprite
    {
        public int Damage;

        public AttackingSprite(Vector2 position) :
            base(position)
        {

        }

        protected override void OnCollision(List<CollidingSprite> collidingSprites)
        {
            base.OnCollision(collidingSprites);
            AttackingSprite AttackingSprite = (AttackingSprite)collidingSprites.Find(collidingSprite => collidingSprite is AttackingSprite);
            if (AttackingSprite != null)
            {
                DoDamage(AttackingSprite);
            }
        }

        protected virtual void DoDamage(AttackingSprite attackingSprite)
        {
            attackingSprite.Health -= Damage;
        }
    }
}