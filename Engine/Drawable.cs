using Engine.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SimpleJSON;

namespace Engine
{
    public class Drawable
    {
        public Drawable() { }

        public Vector2 position;
        public Vector2 dimensions = Vector2.Zero;
        protected Texture2D texture;
        public float scale = 1.0f;
        public Vector2 origin = Vector2.Zero;      // point from which the texture is rendered
        public Rectangle srcRect;
        public Texture2D Texture
        {
            get { return texture; }
            set
            {
                texture = value;
                if (dimensions == Vector2.Zero && value != null)
                {
                    dimensions.X = value.Width;
                    dimensions.Y = value.Height;
                }
            }
        }

        public Color mColor = Color.White;

        public Rectangle Bounds()
        {
            return new Rectangle((int)(position.X - origin.X), (int)(position.Y - origin.Y), (int)dimensions.X, (int)dimensions.Y);
        }

        public virtual void Draw()
        {
            Render.Draw(this);
        }

    }

    public class DrawableRotated : Drawable
    {
        public DrawableRotated() { }

        public Single rotation;
        public override void Draw()
        {
            Render.Draw(this);
        }
    }

    public class DrawableAnimated : Drawable
    {
        public DrawableAnimated() { }

        public double startTime;
        private int currentFrame;

        public int frameCount;
        public int frameWidth;
        public int frameChangeSpeed;
        private bool loop = false;
        public bool hasPlayed = false;

        List<Texture2D> frames = new List<Texture2D>();
        public void Load(JSONNode json)
        {
            frameCount = int.Parse(json["frameCount"]);
            frameChangeSpeed = int.Parse(json["frameChangeSpeed"]);
            loop = bool.Parse(json["loop"]);
            srcRect.X = int.Parse(json["srcRect"][0]);
            srcRect.Y = int.Parse(json["srcRect"][1]);
            srcRect.Width = int.Parse(json["srcRect"][2]);
            srcRect.Height = int.Parse(json["srcRect"][3]);

            string path = Helper.stripPRTHS(json["animFolder"].ToString());

            for(int i = 1; i <= frameCount; i++)
            {
                Texture2D temp = Config.ContentManager.Load<Texture2D>(path + i.ToString());
                frames.Add(temp);
            }
        }
        public void Start()
        {
            startTime = Chrono.timeRef.TotalGameTime.TotalMilliseconds;
            currentFrame = 0;
            Texture = frames[currentFrame];
        }
        public void Update()
        {
            if (Chrono.timeRef.TotalGameTime.TotalMilliseconds - startTime > frameChangeSpeed * (frameCount))
            {
                hasPlayed = true;

                if(loop) Start();
            }
            else if(Chrono.timeRef.TotalGameTime.TotalMilliseconds - startTime > frameChangeSpeed * (currentFrame+1))
            {
                currentFrame++;
                texture = frames[currentFrame];
            }
        }
        public override void Draw()
        {
            Render.Draw((Drawable)this);
        }
    }
}
