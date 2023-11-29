using System;
using UnityEngine;

namespace Scaleton
{
    public class PlayerStateMachine : StateMachine
    {
        [field: Header("Data")]
        [field: SerializeField, Space(1)] public PlayerController Input { get; private set; }

        [field: Header("Modules"), Space(2)]
        [field: SerializeField, Space(1)] public MoveModule MoveModule { get; private set; }
        [field: SerializeField, Space(1)] public JumpModule JumpModule { get; private set; }
        [field: SerializeField, Space(1)] public DashModule DashModule { get; private set; }

        [field: Header("Components"), Space(2)]
        [field: SerializeField, Space(1)] public Rigidbody2D Rb { get; private set; }

        public readonly String Idle = "PlayerIdle";
        public readonly String Run = "PlayerRun";
        public readonly String Jumping = "PlayerJumping";
        public readonly String Falling = "PlayerFalling";
        public readonly String Dashing = "PlayerDashing";

        private PlayerIdleState _idleState;
        private PlayerRunState _runState;
        private PlayerJumpingState _jumpingState;
        private PlayerFallingState _fallingState;
        private PlayerDashing _dashingState;

        protected override void Awake()
        {
            base.Awake();

            _idleState = new PlayerIdleState(this);
            _runState = new PlayerRunState(this);
            _jumpingState = new PlayerJumpingState(this);
            _fallingState = new PlayerFallingState(this);
            _dashingState = new PlayerDashing(this);

            _stateDict.Add(Idle, _idleState);
            _stateDict.Add(Run, _runState);
            _stateDict.Add(Jumping, _jumpingState);
            _stateDict.Add(Falling, _fallingState);
            _stateDict.Add(Dashing, _dashingState);

            foreach (var state in _stateDict.Values)
            {
                state.OnTransitioned += OnStateTransitioned;
            }
        }

        private void Start()
        {
            SetInitialState(_idleState);
        }

        private void OnDestroy()
        {
            foreach (var state in _stateDict.Values)
            {
                state.OnTransitioned -= OnStateTransitioned;
            }

            _stateDict.Clear();
        }

        private void OnGUI()
        {
            var state = _currentState.ToString();

            // state = state.Remove(0, 32);

            GUI.Label(new Rect(40, 40, 200, 40), state);
        }
    }
}

