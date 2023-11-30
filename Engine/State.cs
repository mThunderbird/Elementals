using Microsoft.Xna.Framework.Content;

namespace Engine
{
    internal abstract class State
    {
        public State()
        {

        }

        public abstract void Load(ContentManager cm);
        public abstract void Init();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Dispose();


    }

}
