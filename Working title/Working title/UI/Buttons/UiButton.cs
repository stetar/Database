using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Working_title.MapGenerator;

namespace Working_title.UI.Buttons
{
    public class UiButton : NonCollidingSprite
    {
        protected MouseState Mouse;

        private UIButtonState State;

        public UiButton(Vector2 position) :
            base(position)
        {
            TextureSize = new Size(300,300);

        }

        public virtual void Update(MouseState mouse)
        {
            Mouse = mouse;
            CheckCollisionWithMouse();
        }

        private void CheckCollisionWithMouse()
        {
            Rectangle Rectangle = new Rectangle((int)Position.X, (int)Position.Y, TextureSize.Width, TextureSize.Height);

            Rectangle MouseRectangle = new Rectangle(Mouse.X, Mouse.Y, 1, 1);

            if (MouseRectangle.Intersects(Rectangle))
            {
                EnteredMouseCollision();
            }
            else
            {
                ExitedMouseCollision();
            }
        }

        private void EnteredMouseCollision()
        {
            switch (State)
            {
                case UIButtonState.Exit:
                    OnMouseEnter();
                    State = UIButtonState.Stay;
                    break;
                case UIButtonState.Stay:
                    OnMouseStay();
                    if (Mouse.LeftButton == ButtonState.Pressed)
                    {
                        OnMouseDown();
                    }
                    break;
            }
        }

        private void ExitedMouseCollision()
        {
            if (State == UIButtonState.Stay || State == UIButtonState.Enter)
            {
                OnMouseExit();
                State = UIButtonState.Exit;
            }
        }

        protected virtual void OnMouseEnter()
        {

        }

        protected virtual void OnMouseStay()
        {

        }

        protected virtual void OnMouseExit()
        {

        }

        protected virtual void OnMouseDown()
        {
            
        }
    }
}