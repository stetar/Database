using LearningMonoGameGame;
using Microsoft.Xna.Framework;
using Working_title.Combat;
using Working_title.MapGenerator;
using Working_title.MoveableClasses;
using Working_title.MoveableClasses.XP;

namespace Working_title.UI
{
        public class XpBar : MovingBar
        {
            private Level Level;

            public XpBar(Size fullSize, Camera2D camera, Vector2 offset,Level level) :
                    base(fullSize, camera, offset)
            {
                Level = level;
                TextureName = "Purple";
            }

            public override void Update(GameTime gameTime)
            {
                SetWantedLoadingBarProcent(Level.MyCurrentXp / (float)Level.XpToLevelUp);
                base.Update(gameTime);
            }
        }
    
}