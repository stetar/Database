using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Working_title.MoveableClasses
{
    public class KeyMoveInput
    {
        public Keys Key;
        public Vector2 Direction;

        public KeyMoveInput(Keys key, Vector2 direction)
        {
            Key = key;
            Direction = direction;
        }

        public bool IsKeyPressedDown(KeyboardState keyboardState)
        {
            return keyboardState.IsKeyDown(Key);
        }
    }
}