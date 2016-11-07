using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public static class UIManager
    {
        public static SpriteFont debugFont;

        static bool isDebugMode = true;
        static Vector2 debugConsoleArea;

        public static void Init()
        {

        }

        public static void Update()
        {
            if (InputManager.isF3)
                isDebugMode = !isDebugMode;
            
            if(isDebugMode)
                debugConsoleArea = -Camera2D.Position - new Vector2(GameManager.gameManager.GraphicsDevice.Viewport.Width / 2, GameManager.gameManager.GraphicsDevice.Viewport.Height / 2);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            var fontColor = Color.Black;
            if (isDebugMode)
            {
                spriteBatch.DrawString(debugFont, "Move Vector: " + Player.moveVector, debugConsoleArea, fontColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
                debugConsoleArea += Vector2.UnitY * debugFont.LineSpacing;
                spriteBatch.DrawString(debugFont, "Camera Position: " + Camera2D.Position, debugConsoleArea, fontColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
                debugConsoleArea += Vector2.UnitY * debugFont.LineSpacing;
                spriteBatch.DrawString(debugFont, "Draw Count: " + World.drawCount, debugConsoleArea, fontColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
                World.drawCount = 0;
            }
                
        }
    }
}
