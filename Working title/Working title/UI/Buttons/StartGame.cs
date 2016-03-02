using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Working_title.MapGenerator;

namespace Working_title.UI.Buttons
{
    public class StartGame : UiButton
    {
        public StartGame(Vector2 position) :
            base(position)
        {
            TextureName = "StartGame";
            TextureSize = new Size(Game1.ScreenSize.Width / 3, Game1.ScreenSize.Height / 12);
        }

        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            Game1.CurrentGameState = GameState.MapLoading;
        }
    }
}