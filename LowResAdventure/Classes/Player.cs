using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public static class Player
    {
        public static Texture2D texture;

        public static int moveSpeed = 16;
        public static Vector2 position = Vector2.Zero;
        public static Vector2 moveVector = Vector2.Zero;
        static float lerpFactor = 0.05f;

        public static void Update(float deltaTime)
        {

            if (InputManager.isKeyW)
            {
                moveVector = Vector2.Lerp(moveVector, new Vector2(0, -moveSpeed * deltaTime), lerpFactor);
            }
            if (InputManager.isKeyS)
            {
                moveVector = Vector2.Lerp(moveVector, new Vector2(0, moveSpeed * deltaTime), lerpFactor);
            }
            if (InputManager.isKeyD)
            {
                moveVector = Vector2.Lerp(moveVector, new Vector2(moveSpeed * deltaTime, 0), lerpFactor);
            }
            if (InputManager.isKeyA)
            {
                moveVector = Vector2.Lerp(moveVector, new Vector2(-moveSpeed * deltaTime, 0), lerpFactor);
            }

            if (!InputManager.isKeyW && !InputManager.isKeyS && !InputManager.isKeyD && !InputManager.isKeyA)
            {
                moveVector = Vector2.Lerp(moveVector, Vector2.Zero, lerpFactor * 2);
            }

            position += moveVector;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            var pos = new Vector2(position.X * GameManager.tileSize * GameManager.scale, position.Y * GameManager.tileSize * GameManager.scale);
            spriteBatch.Draw(texture, pos, null, null, null, 0.0f, new Vector2(GameManager.scale, GameManager.scale), Color.White);
        }
    }
}
