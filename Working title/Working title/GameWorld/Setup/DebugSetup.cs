using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Working_title.Setup
{
    public class DebugSetup : WorldSetup
    {

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            LoadTexture("Blue", "Images/Blue");
            LoadTexture("Green", "Images/Green");
            LoadTexture("Yellow", "Images/Yellow");
            LoadTexture("Black", "Images/Black");
        }
    }
}