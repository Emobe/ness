using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;


namespace Ness.TileEngine
{
    public class InputHandler
    {
        static KeyboardState keyState;
        static KeyboardState lastKey;

        public void Update()
        {
            lastKey = keyState;
            keyState = Keyboard.GetState();
        }

        public static bool isDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }
    }
}
