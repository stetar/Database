using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Working_title.Setup
{
    public class GeneralSetup : WorldSetup
    {
        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            LoadSpriteFont("StandardFont", "Fonts/StandardFont");
        }
    }
}