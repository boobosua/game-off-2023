using System;
using UnityEngine;

namespace Scaleton
{
    public class SlimeStateMachine : StateMachine
    {
        [field: Header("Modules"), Space(2)]
        [field: SerializeField, Space(1)] public MoveModule MoveModule { get; private set; }
        [field: SerializeField, Space(1)] public JumpModule JumpModule { get; private set; }

        [field: Header("Components"), Space(2)]
        [field: SerializeField, Space(1)] public Rigidbody2D Rb { get; private set; }

        public readonly String Appear = "SlimeAppear";
        public readonly String Idle = "SlimeIdle";
        public readonly String Wander = "SlimeWander";
        public readonly String JumpAttack = "SlimeJumpAttack";

        private SlimeAppearState _appearState;
        private SlimeIdleState _idleState;
        private SlimeWanderState _wanderState;
        private SlimeJumpAttackState _jumpAttackState;

        protected override void Awake()
        {
            base.Awake();

            _appearState = new SlimeAppearState(this);
            _idleState = new SlimeIdleState(this);
            _wanderState = new SlimeWanderState(this);
            _jumpAttackState = new SlimeJumpAttackState(this);

            _stateDict.Add(Appear, _appearState);
            _stateDict.Add(Idle, _idleState);
            _stateDict.Add(Wander, _wanderState);
            _stateDict.Add(JumpAttack, _jumpAttackState);

            ConnectTransitions();
        }

        private void Start()
        {
            SetInitialState(_appearState);
        }
    }
}

