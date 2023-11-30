using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Source.States
{
    internal class Gameplay : State
    {
        DrawableAnimated animTest;
        public override void Load(ContentManager cm)
        {
            throw new NotImplementedException();
        }
        public override void Init()
        {
            animTest = Config.animations["WaterPriestress\\idle"];
            animTest.scale = 2.5f;
            animTest.position = new Vector2(200,200);
            animTest.Start();
        }
        public override void Update()
        {
            animTest.Update();
        }
        public override void Draw()
        {
            animTest.Draw();
        }
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
