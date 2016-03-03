using Microsoft.Xna.Framework;
using Working_title.Combat;
using Working_title.MapGenerator;
using Working_title.MoveableClasses;

namespace Working_title.UI
{
    public class HealthBar : MovingBar
    {
        private KillableSprite KillableSprite;

        public HealthBar(Size fullSize,KillableSprite killableSprite,Vector2 offset) :
                base(fullSize, killableSprite, offset)
        {
            KillableSprite = killableSprite;
        }

        public override void Update(GameTime gameTime)
        {
            SetWantedLoadingBarProcent(KillableSprite.Health / (float)KillableSprite.MaxHealth);
            base.Update(gameTime);
        }        
    }
}