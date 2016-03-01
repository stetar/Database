using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.MapGenerator;

namespace Working_title.UI.Buttons
{
    class Register : UiButton
    {
        private bool down;
        public bool RegisterIsClicked;
        private Color Colour = new Color(255, 255, 255, 255);

        public Register(Vector2 position) : 
            base(position)
        {
            TextureName = "BtnRegister";
            TextureSize = new Size(Game1.ScreenSize.Width / 3, Game1.ScreenSize.Height / 12);
        }


        protected override void OnMouseStay()
        {
            base.OnMouseEnter();
            if (Colour.A == 255) { down = false; }
            if (Colour.A == 0) { down = true; }
            if (down) { Colour.A += 3; }
            else { Colour.A -= 3; }
            if (Mouse.LeftButton == ButtonState.Pressed)
            {
                RegisterIsClicked = true;
            }
        }

        protected override void OnMouseExit()
        {
            base.OnMouseExit();
            if (Colour.A < 255)
            {
                Colour.A += 3;
                RegisterIsClicked = false;
            }
        }
    }
}