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

        public static void Move(Vector2 direction)
        {
            Position += direction;
        }

        public static void Init()
        {
            Zoom = 0.25f;
            Rotation = 0;
            Origin = new Vector2(GameManager.gameManager.Window.ClientBounds.Width / 2.0f, GameManager.gameManager.Window.ClientBounds.Height / 2.0f);
            Position = Player.position * -TextureManager.TILE_SIZE * TextureManager.SCALE;

        }

        public static void Update(float deltaTime)
        {
            #region noLERP
            //Position = Player.position * -TextureManager.TILE_SIZE ;
            //Position = new Vector2((float)Math.Round(Position.X * Zoom) / Zoom, (float)Math.Round(Position.Y * Zoom) / Zoom);
            #endregion
            Position = Vector2.Lerp(Position, Player.position * -TextureManager.TILE_SIZE, 0.025f);
            Position = Vector2.Lerp(Position,  new Vector2((float)Math.Round(Position.X * Zoom) / Zoom, (float)Math.Round(Position.Y * Zoom) / Zoom), 0.5f);
        }

        public static Matrix GetViewMatrix()
        {
            var translationMatrix = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0));
            var rotationMatrix = Matrix.CreateRotationZ(Rotation);
            var scaleMatrix = Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            var originMatrix = Matrix.CreateTranslation(new Vector3(Origin.X, Origin.Y, 1));
            return
                    translationMatrix *
                    rotationMatrix *
                    scaleMatrix *
                    originMatrix;

        }
    }
}
