using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public static class TextureManager
    {
        public static float SCALE = 0.25f;
        public static int TILE_SIZE = 64;

        public static Texture2D tileSheet;
        public static Dictionary<TileType, Rectangle> textureDictionary = new Dictionary<TileType, Rectangle>();

        public static void Init()
        {
            var currentRow = 0;
            var currentColumn = 0;
            var tilesPerRow = tileSheet.Width / TILE_SIZE;
            var tilesPerColumn = tileSheet.Height / TILE_SIZE;

            foreach(TileType type in Enum.GetValues(typeof(TileType)))
            {
                var rect = new Rectangle(currentColumn * TILE_SIZE, currentRow * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                textureDictionary.Add(type, rect);
                currentColumn++;
                if (currentColumn == tilesPerRow)
                {
                    currentRow++;
                    currentColumn = 0;
                }
                
            }
           
        }
    }
}
