using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public enum TileType { EMPTY, GRASS, DIRT };

    public class Tile
    {
        private TileType _type;
        private Texture2D _texture;

        public Tile(TileType type)
        {
            _type = type;
            _SetTexture();
        }

        private void _SetTexture()
        {
            int grassType = World.rnd.Next(1, 4);
            switch (_type)
            {
                case TileType.EMPTY:
                    _texture = GameManager.textures[0];
                    break;
                case TileType.GRASS:
                    _texture = GameManager.textures[grassType];
                    break;
                case TileType.DIRT:
                    _texture = GameManager.textures[4];
                    break;
            }
        }

        public Texture2D GetTexture()
        {
            return _texture;
        }
    }
}
