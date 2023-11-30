using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine
{
    internal static class Helper
    {
        public static float distance(Vector2 a , Vector2 b)
        {
            return (float)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static string stripPRTHS(string input)
        {
            string output = input;
            output = output.Remove(input.Length - 1);
            output = output.Remove(0,1);
            return output;
        }
    }
}
