using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowResAdventure
{
    public static class Helpers
    {
        public static bool AlmostEquals(this Vector2 v1, Vector2 v2, float precision)
        {
            var xIsZero = Math.Abs(v1.X - v2.X) <= precision;
            var yIsZero = Math.Abs(v1.Y - v2.Y) <= precision;
            return xIsZero && yIsZero;
        }
    }
}
