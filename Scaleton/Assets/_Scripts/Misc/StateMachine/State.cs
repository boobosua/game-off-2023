using System;
using UnityEngine.Events;

namespace Scaleton
{
    public abstract class State
    {
        public event UnityAction<State, String> OnTransitioned;

        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void FixedTick(float fixedDeltaTime);
        public abstract void Exit();

        protected void Transit(State from, String to)
        {
            OnTransitioned?.Invoke(from, to);
        }
    }
}