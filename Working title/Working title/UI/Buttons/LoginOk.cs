using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.MapGenerator;

namespace Working_title.UI.Buttons
{
    class LoginOk : UiButton
    {
        Rectangle rectangle;
        bool down;
        public bool LoginOkIsClicked;
        Color colour = new Color(255, 255, 255, 255);

        public LoginOk(Vector2 position) : 
            base(position)
        {
            TextureName = "BtnOk";
            TextureSize = new Size(Game1.ScreenSize.Width / 3, Game1.ScreenSize.Height / 12);
        }

        protected override void OnMouseEnter()
        {
            base.OnMouseEnter();
            if (colour.A == 255){ down = false; }
            if (colour.A == 0){ down = true; }
            if (down){ colour.A += 3; }
            else { colour.A -= 3; }
            if (Mouse.LeftButton == ButtonState.Pressed)
            {
                LoginOkIsClicked = true;
            }
        }

        protected override void OnMouseExit()
        {
            base.OnMouseExit();
            if (colour.A < 255)
            {
                colour.A += 3;
                LoginOkIsClicked = false;
            }
        }
    }
}
