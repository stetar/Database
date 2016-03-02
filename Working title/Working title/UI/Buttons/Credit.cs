using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.MapGenerator;

namespace Working_title.UI.Buttons
{
    class Credit : UiButton
    {

        public Credit(Vector2 position) : 
            base(position)
        {
            TextureName = "CreditsButton";
            TextureSize = new Size(Game1.ScreenSize.Width / 3, Game1.ScreenSize.Height / 12);
        }

        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            Game1.CurrentGameState = GameState.Credits;
            ;
        }
    }
}
