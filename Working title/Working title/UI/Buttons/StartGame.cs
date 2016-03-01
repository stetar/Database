using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Working_title.UI.Buttons
{
    class StartGame
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        public bool StartIsClicked;
        Color colour = new Color(255, 255, 255, 255); // R, B, G, A
        public Vector2 size;

        public StartGame(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;
            size = new Vector2(graphics.Viewport.Width / 3, graphics.Viewport.Height / 12);
        }


        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                colour.A = 255;
                if (mouse.LeftButton == ButtonState.Pressed) StartIsClicked = true;
            }
            else
            {
                colour.A = 235;
                StartIsClicked = false;
            }
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
