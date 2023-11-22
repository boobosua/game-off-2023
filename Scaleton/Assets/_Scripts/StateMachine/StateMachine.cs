using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scaleton
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State _currentState;
        protected Dictionary<String, State> _stateDict;

        protected virtual void Awake()
        {
            _stateDict = new Dictionary<String, State>();
        }

        protected virtual void Update()
        {
            _currentState?.Tick(Time.deltaTime);
        }

        protected virtual void FixedUpdate()
        {
            _currentState?.FixedTick(Time.fixedDeltaTime);
        }

        protected void OnStateTransitioned(State from, String key)
        {
            if (_currentState != from) return;

            if (!_stateDict.TryGetValue(key, out var toState)) return;

            // Exit current state.
            _currentState?.Exit();

            // Change to new state.
            _currentState = toState;

            // Enter new state;
            _currentState?.Enter();
        }

        protected void SetInitialState(State state)
        {
            if (state == null) return;

            _currentState = state;
            _currentState.Enter();
        }
    }
}

