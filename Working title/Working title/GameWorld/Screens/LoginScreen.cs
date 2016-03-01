using Microsoft.Xna.Framework;
using Working_title.MapGenerator;
using Working_title.UI.Buttons;

namespace Working_title.Screens
{
    public class LoginScreen : Screen
    {

        public override void Init()
        {
            AddObjectToLoadingList(new StartGame(new Vector2(300, 75)));
            AddObjectToLoadingList(new Register(new Vector2(300, 175)));
            AddObjectToLoadingList(new LoginOk(new Vector2(300, 275)));
            AddObjectToLoadingList(new NonCollidingStaticSprite(new Vector2(0, 0), Game1.ScreenSize, "loginBg"));
        }
    }
}