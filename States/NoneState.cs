using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Source
{
    internal class NoneState : State
    {
        public override void Load(ContentManager cm)
        {

        }        
        public override void Init()
        {

        }        
        public override void Update()
        {
            StateManager.Instance.SwitchState(STATE.GAMEPLAY);
        }        
        public override void Draw()
        {

        }
        public override void Dispose()
        {

        }

    }
}
