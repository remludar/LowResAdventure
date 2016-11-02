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

        public static Vector2 position = new Vector2(32,32);
        public static Vector2 moveVector = Vector2.Zero;
        public static SpriteFont font;

        static Rectangle textureRectangle;
        static float lerpFactor = 0.09f;
        static float diagonalCorrection = 0.7071f;
        static float stopingLerpFactor = lerpFactor * 1.5f;
        static bool debug = false;
        static float walkSpeed = 6;
        static float runSpeed = walkSpeed * 1.6f;
        static float moveSpeed = walkSpeed;



        public static void Init()
        {
            var success = TextureManager.textureDictionary.TryGetValue(TileType.PLAYER, out textureRectangle);
        }

        public static void Update(float deltaTime)
        {
            if (InputManager.isLeftShift)
                moveSpeed = runSpeed;
            else
                moveSpeed = walkSpeed;

            #region no LERP
            //float horizontal = 0;
            //float vertical = 0;
            //if (InputManager.isKeyW)
            //{
            //    vertical = -moveSpeed * deltaTime;
            //}
            //if (InputManager.isKeyS)
            //{
            //    vertical = moveSpeed * deltaTime;
            //}
            //if (InputManager.isKeyD)
            //{
            //    horizontal = moveSpeed * deltaTime;
            //}
            //if (InputManager.isKeyA)
            //{
            //    horizontal = -moveSpeed * deltaTime;
            //}

            //if (!InputManager.isKeyW && !InputManager.isKeyS && !InputManager.isKeyD && !InputManager.isKeyA)
            //{
            //    moveVector = Vector2.Zero;
            //}

            //if (horizontal != 0 && vertical != 0)
            //{
            //    horizontal *= 0.7071f;
            //    vertical *= 0.7071f;
            //}
            //moveVector = new Vector2(horizontal, vertical);
            //position += moveVector;
            #endregion

            #region LERP
            if (InputManager.isKeyW)
            {
                if (InputManager.isKeyA)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(-moveSpeed * deltaTime, -moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else if (InputManager.isKeyD)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(moveSpeed * deltaTime, -moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else
                    moveVector = Vector2.Lerp(moveVector, new Vector2(0, -moveSpeed * deltaTime), lerpFactor);
            }
            else if (InputManager.isKeyS)
            {
                if (InputManager.isKeyA)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(-moveSpeed * deltaTime, moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else if (InputManager.isKeyD)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(moveSpeed * deltaTime, moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else
                    moveVector = Vector2.Lerp(moveVector, new Vector2(0, moveSpeed * deltaTime), lerpFactor);
            }
            else if (InputManager.isKeyD)
            {
                if(InputManager.isKeyW)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(moveSpeed * deltaTime, -moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else if(InputManager.isKeyS)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(moveSpeed * deltaTime, moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else
                    moveVector = Vector2.Lerp(moveVector, new Vector2(moveSpeed * deltaTime, 0), lerpFactor);
            }
            else if (InputManager.isKeyA)
            {
                if(InputManager.isKeyW)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(-moveSpeed * deltaTime, -moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else if(InputManager.isKeyS)
                    moveVector = Vector2.Lerp(moveVector, new Vector2(-moveSpeed * deltaTime, moveSpeed * deltaTime) * diagonalCorrection, lerpFactor);
                else
                    moveVector = Vector2.Lerp(moveVector, new Vector2(-moveSpeed * deltaTime, 0), lerpFactor);
            }

            if (!InputManager.isKeyW && !InputManager.isKeyS && !InputManager.isKeyD && !InputManager.isKeyA)
            {
                moveVector = Vector2.Lerp(moveVector, Vector2.Zero, stopingLerpFactor);
            }

            
            position += moveVector;
            #endregion

            if (InputManager.isTilde) debug = !debug;

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            var playerPosition = new Vector2(
                            position.X * TextureManager.TILE_SIZE,
                            position.Y * TextureManager.TILE_SIZE);

            spriteBatch.Draw(TextureManager.tileSheet, playerPosition, textureRectangle, Color.White);
            //spriteBatch.DrawString(font, "Move Vector: " + moveVector, playerPosition, Color.White);
            spriteBatch.DrawString(font, "Move Vector: " + moveVector, playerPosition, Color.White, 0, Vector2.Zero, 5.0f, SpriteEffects.None, 0);
        }
    }
}
