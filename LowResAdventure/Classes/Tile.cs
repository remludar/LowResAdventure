using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public enum TileType { EMPTY, PLAYER, GRASS, GRASS2, GRASS3, DIRT };

    public class Tile
    {
        private TileType _type;
        private Rectangle textureRectangle;

        public Tile(TileType type)
        {
            _type = type;
            _SetTextureRectangle();
        }

        private void _SetTextureRectangle()
        {
            var success = false;
            switch (_type)
            {
                case TileType.EMPTY:
                    success = (!TextureManager.textureDictionary.TryGetValue(TileType.EMPTY, out textureRectangle));
                    break;
                case TileType.GRASS:
                    success = (!TextureManager.textureDictionary.TryGetValue(TileType.GRASS, out textureRectangle));
                    break;
                case TileType.GRASS2:
                    success = (!TextureManager.textureDictionary.TryGetValue(TileType.GRASS2, out textureRectangle));
                    break;
                case TileType.GRASS3:
                    success = (!TextureManager.textureDictionary.TryGetValue(TileType.GRASS3, out textureRectangle));
                    break;
                case TileType.DIRT:
                    success = (!TextureManager.textureDictionary.TryGetValue(TileType.DIRT, out textureRectangle));
                    break;
            }
        }

        public Rectangle GetTextureRectangle()
        {
            return textureRectangle;
        }
    }
}
