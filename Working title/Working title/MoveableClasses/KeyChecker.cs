using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Working_title.MoveableClasses
{
    public class KeyChecker
    {
        private List<KeyMoveInput> KeyMoveInputs = new List<KeyMoveInput>();

        public KeyChecker(Keys key, Vector2 direction)
        {
            AddKeyMoveInput(key, direction);
        }

        public KeyChecker(List<Keys> keys, Vector2 direction)
        {
            foreach (var Key in keys)
            {
                AddKeyMoveInput(Key, direction);
            }
        }

        private void AddKeyMoveInput(Keys key, Vector2 direction)
        {
            KeyMoveInputs.Add(new KeyMoveInput(key, direction));
        }

        public List<KeyMoveInput> KeysPressedDown()
        {
            List<KeyMoveInput> KeysPressedDown = new List<KeyMoveInput>();
            KeyboardState KeyboardState = Keyboard.GetState();

            foreach (var KeyMoveInput in KeyMoveInputs)
            {
                if (KeyMoveInput.IsKeyPressedDown(KeyboardState))
                {
                    KeysPressedDown.Add(KeyMoveInput);
                }
            }

            return KeysPressedDown;
        }
    }
}