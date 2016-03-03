using Microsoft.Xna.Framework.Content;

namespace Working_title.Setup
{
    public class EnemySetup : WorldSetup
    {
        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            LoadTexture("Imp","Images/Enemies/Imp");
            LoadTexture("Demon", "Images/Enemies/Demon");
            LoadTexture("Succubus", "Images/Enemies/Succubus");
            LoadTexture("Fiend", "Images/Enemies/Fiend");
            LoadTexture("Pit Lord", "Images/Enemies/Pit Lord");
            LoadTexture("Warlock", "Images/Enemies/Warlock");
            LoadTexture("Arch Demon", "Images/Enemies/Arch Demon");
        }
    }
}