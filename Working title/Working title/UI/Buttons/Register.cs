using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Working_title.MapGenerator;

namespace Working_title.UI.Buttons
{
    class Register : UiButton
    {

        public Register(Vector2 position) : 
            base(position)
        {
            TextureName = "BtnRegister";
            TextureSize = new Size(Game1.ScreenSize.Width / 3, Game1.ScreenSize.Height / 12);
        }




    }
}