using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Working_title.MapGenerator;

namespace Working_title.Setup
{
    public class LoginSetup : WorldSetup
    {
        private const int ScreenWidth = 800;
        private const int ScreenHeight = 600;

        private GraphicsDeviceManager Graphics;

        public override void Init(Game1 game1)
        {
            base.Init(game1);
            Game1.ScreenSize = new Size(ScreenWidth,ScreenHeight);
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            LoadTexture("BtnOk", "BtnOk");
            LoadTexture("BtnRegister", "BtnRegister");
            LoadTexture("loginBg", "loginBg");
            LoadTexture("StartGame", "Images/StartGame");
        }
    }
}