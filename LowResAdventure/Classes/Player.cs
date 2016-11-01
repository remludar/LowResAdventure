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

        public static int moveSpeed = 16;
        public static Vector2 position = Vector2.Zero;
        public static Vector2 moveVector = Vector2.Zero;

        static Rectangle textureRectangle;
        static float lerpFactor = 0.05f;

        public static void Init()
        {
            var success = TextureManager.textureDictionary.TryGetValue(TileType.PLAYER, out textureRectangle);
        }

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
            var destinationRectangle = new Rectangle(
                    (int)(position.X * TextureManager.TILE_SIZE * TextureManager.SCALE),
                    (int)(position.Y * TextureManager.TILE_SIZE * TextureManager.SCALE),
                    (int)(TextureManager.TILE_SIZE * TextureManager.SCALE),
                    (int)(TextureManager.TILE_SIZE * TextureManager.SCALE));

            spriteBatch.Draw(TextureManager.tileSheet, destinationRectangle, textureRectangle, Color.White);
        }
    }
}
