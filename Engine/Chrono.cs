using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal static class Chrono
    {
        public static double timeLastFrame;
        public static double deltaTime;  // time passed for last frame in seconds
        public static GameTime timeRef;

        public static void Update(GameTime gameTime)
        {
            timeRef = gameTime;

            deltaTime = (gameTime.TotalGameTime.TotalMilliseconds - timeLastFrame) / 1000;
            timeLastFrame = gameTime.TotalGameTime.TotalMilliseconds;
        }
    }
}
