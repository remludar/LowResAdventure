using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public static class Camera2D
    {
        public static float Zoom { get; set; }
        public static Vector2 Position { get; set; }
        public static float Rotation { get; set; }
        public static Vector2 Origin { get; set; }
        
        static Vector2 moveVector = Vector2.Zero;
        static float lerpFactor;
        public static BoundingFrustum boundingFrustrum;

        public static void Init()
        {
            
            lerpFactor = 0.4f;
            Zoom = 1f;
            Rotation = 0;
            Origin = new Vector2(GameManager.gameManager.Window.ClientBounds.Width / 2.0f, GameManager.gameManager.Window.ClientBounds.Height / 2.0f);
            Position = Player.position * -TextureManager.TILE_SIZE;

        }

        public static void Update(float deltaTime)
        {

            #region noRoundingNoLerp
            //var targetPosition = new Vector2(
            //        -Player.position.X * TextureManager.TILE_SIZE,
            //        -Player.position.Y * TextureManager.TILE_SIZE);
            //Position = targetPosition;
            #endregion

            #region noLERP
            //var targetPosition = new Vector2(
            //        (float)Math.Round(-Player.position.X * TextureManager.TILE_SIZE * Zoom) / Zoom,
            //        (float)Math.Round(-Player.position.Y * TextureManager.TILE_SIZE * Zoom) / Zoom);
            //Position = targetPosition;
            #endregion

            #region LERP
            //var targetPosition = -Player.position * TextureManager.TILE_SIZE;
            //Position = Vector2.Lerp(
            //                Position, new Vector2(
            //                (float)Math.Round(targetPosition.X * Zoom) / Zoom, 
            //                (float)Math.Round(targetPosition.Y * Zoom) / Zoom), lerpFactor);
            #endregion

            #region noRoundingLERP
            var targetPosition = -Player.position * TextureManager.TILE_SIZE;
            Position = Vector2.Lerp(Position, targetPosition, lerpFactor);
            #endregion


        }

        public static Matrix GetViewMatrix()
        {
            var translationMatrix = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0));
            var rotationMatrix = Matrix.CreateRotationZ(Rotation);
            var scaleMatrix = Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            var originMatrix = Matrix.CreateTranslation(new Vector3(Origin.X, Origin.Y, 1));
            var returnMatrix = 
                    translationMatrix *
                    rotationMatrix *
                    scaleMatrix *
                    originMatrix;
            boundingFrustrum = new BoundingFrustum(returnMatrix);
            return returnMatrix;
        }

    }
}
