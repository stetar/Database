using System;
using Microsoft.Xna.Framework;

namespace Working_title.MoveableClasses.XP
{
    public delegate void LevelUpHandler(object sender, EventArgs e);

    public class Level : GameObject
    {
        public int CurrentLevel = 1;
        public event LevelUpHandler OnLevelUp;

        public int MyCurrentXp;
        private int MyXpToLevelUp;
        private GrowthStat LevelUpGrowthStat = new GrowthStat(2, 10);

        public int CurrentXp => MyCurrentXp;
        public int XpToLevelUp => MyXpToLevelUp;

        public Level() :
            base(Vector2.Zero)
        {
            MyXpToLevelUp = LevelUpGrowthStat.GetGrowthValue(CurrentLevel);
        }

        public void AddXp(int xp)
        {
            MyCurrentXp += xp;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ShouldLevelUp();
        }

        private void ShouldLevelUp()
        {
            if (MyXpToLevelUp <= MyCurrentXp)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            OnLevelUp(this,new EventArgs());
            CurrentLevel++;
            MyCurrentXp -= MyXpToLevelUp;
            MyXpToLevelUp = LevelUpGrowthStat.GetGrowthValue(CurrentLevel);
            
        }
    }
}