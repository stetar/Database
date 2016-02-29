using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Working_title.Setup
{
    public abstract class WorldSetup
    {
        protected ContentManager ContentManager;

        public virtual void Init()
        {
            
        }

        public virtual void Init(Game1 game1)
        {

        }

        public virtual void LoadContent(ContentManager contentManager)
        {
            ContentManager = contentManager;
        }

        protected void LoadTexture(string textureName,string texturePath)
        {
            Game1.Textures.Add(textureName,ContentManager.Load<Texture2D>(texturePath));
        }

        protected void LoadSpriteFont(string spriteFontName, string spriteFontPath)
        {
            Game1.SpriteFonts.Add(spriteFontName, ContentManager.Load<SpriteFont>(spriteFontPath));
        }
    }
}