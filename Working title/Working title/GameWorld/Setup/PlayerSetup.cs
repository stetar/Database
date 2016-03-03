using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Working_title.Setup
{
    public class PlayerSetup : WorldSetup
    {
        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            LoadTexture("Player", "Images/Player/Warrior");
        }
    }
}