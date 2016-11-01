using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public static class World
    {
        public static int WORLD_WIDTH = 64;
        public static int WORLD_HEIGHT = 64;
        public static int WORLD_DEPTH = 1;

        public static Dictionary<Vector3, Tile> tileMap = new Dictionary<Vector3, Tile>();
        public static Random rnd = new Random();
        static int[, ,] noise;


        public static void Generate()
        {
            noise = Noise.Generate(WORLD_WIDTH, WORLD_HEIGHT, WORLD_DEPTH);

            for (int x = 0; x < WORLD_WIDTH; x++)
            {
                for (int y = 0; y < WORLD_HEIGHT; y++)
                {
                    for (int z = 0; z < WORLD_DEPTH; z++)
                    {
                        var type = TileType.EMPTY;
                        switch (noise[x, y, z])
                        {
                            case 0:
                                type = TileType.EMPTY;
                                break;
                            case 1:
                                type = TileType.GRASS;
                                break;
                            case 2:
                                type = TileType.GRASS2;
                                break;
                            case 3:
                                type = TileType.GRASS3;
                                break;
                            case 4:
                                type = TileType.DIRT;
                                break;
                        }
                        tileMap.Add(new Vector3(x, y, z), new Tile(type));
                    }
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {


            foreach (KeyValuePair<Vector3, Tile> kvp in World.tileMap)
            {
                if (kvp.Key.Z == 0)
                {
                    var destinationRectangle = new Rectangle(
                            (int)(kvp.Key.X * TextureManager.TILE_SIZE * TextureManager.SCALE),
                            (int)(kvp.Key.Y * TextureManager.TILE_SIZE * TextureManager.SCALE),
                            (int)(TextureManager.TILE_SIZE * TextureManager.SCALE),
                            (int)(TextureManager.TILE_SIZE * TextureManager.SCALE));

                    var textureRectangle = kvp.Value.GetTextureRectangle();
                    spriteBatch.Draw(TextureManager.tileSheet, destinationRectangle, textureRectangle, Color.White);
                }
            }
        }
    }
}
