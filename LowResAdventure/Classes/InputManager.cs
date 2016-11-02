using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public static class InputManager
    {
        public static bool isKeyW = false;
        public static bool isKeyA = false;
        public static bool isKeyS = false;
        public static bool isKeyD = false;
        public static bool isTilde = false;
        public static bool isLeftShift = false;

        static KeyboardState oldKeyboardState;

        public static void ProcessInput()
        {
            var keyboardState = Keyboard.GetState();
            isKeyW = keyboardState.IsKeyDown(Keys.W);
            isKeyS = keyboardState.IsKeyDown(Keys.S);
            isKeyA = keyboardState.IsKeyDown(Keys.A);
            isKeyD = keyboardState.IsKeyDown(Keys.D);

            isLeftShift = keyboardState.IsKeyDown(Keys.LeftShift);

            isTilde = oldKeyboardState.IsKeyUp(Keys.OemTilde) && keyboardState.IsKeyDown(Keys.OemTilde);
            oldKeyboardState = keyboardState;
        }
    }
}
