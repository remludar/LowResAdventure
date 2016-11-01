using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public class Noise
    {
        public static int[, ,] Generate(int width, int height, int depth)
        {
            int[, ,] noise = new int[width, height, depth];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        noise[x, y, z] = World.rnd.Next(1, 5);
                    }
                }
            }
            return noise;
        }
    }
}
