using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SimpleJSON;

namespace Engine
{
    public static class Config
    {
        public static Dictionary<string, DrawableAnimated> animations = new();
        public static ContentManager ContentManager { get; set; }
        public static void SetLoad(ContentManager r)
        {
            ContentManager = r;
        }
        public static void Init()
        {
            DrawableAnimated temp = new DrawableAnimated();
            JSONNode node = JSONNode.Parse(System.IO.File.ReadAllText("Content\\Config\\WaterPriestressAnim.json").ToString());
            temp.Load(node["idle"]);
            animations.Add("WaterPriestress\\idle", temp);
        }
    }
}
