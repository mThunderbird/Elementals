using System;
using Engine.Source.States;
using Microsoft.Xna.Framework;
using Source;

namespace Engine
{
    /// <summary>
    /// Solution using Lazy implementation.
    /// </summary>
    internal sealed class StateManager
    {
        private static readonly StateManager instance = new StateManager();
        static StateManager() { }
        private StateManager()
        {
            CurrentState = new NoneState();
            CurrentState.Init();
        }
        public static StateManager Instance { get { return instance; } }

        public State CurrentState { get; private set; }


        public void SwitchState(STATE state)
        {
            CurrentState.Dispose();

            switch (state)
            {
                case STATE.GAMEPLAY:
                    CurrentState = new Gameplay();
                    break;
                default:
                    break;
            }

            CurrentState.Init();
        }
    }

    public enum STATE
    {
        NONE = 0,
        GAMEPLAY = 1
    }
}
