using System;
using UnityEngine;

namespace Scaleton
{
    public class SlimeStateMachine : StateMachine
    {
        [field: Header("Modules"), Space(2)]
        [field: SerializeField, Space(1)] public MoveModule MoveModule { get; private set; }
        [field: SerializeField, Space(1)] public JumpModule JumpModule { get; private set; }
        [field: SerializeField, Space(1)] public GroundDetectorModule EdgeDetector { get; private set; }
        [field: SerializeField, Space(1)] public HurtBoxModule HurtBox;

        [field: Header("Components"), Space(2)]
        [field: SerializeField, Space(1)] public Rigidbody2D Rb { get; private set; }
        [field: SerializeField, Space(1)] public Animator Animator { get; private set; }

        [field: Header(header: "Materials"), Space(2)]
        [field: SerializeField, Space(1)] public PhysicsMaterial2D Frictionless { get; private set; }
        [field: SerializeField, Space(1)] public PhysicsMaterial2D Bouncy { get; private set; }

        public readonly String Appear = "SlimeAppear";
        public readonly String Idle = "SlimeIdle";
        public readonly String Wander = "SlimeWander";
        public readonly String JumpAttack = "SlimeJumpAttack";
        public readonly String KnockOut = "SlimeKnockOut";

        private SlimeAppearState _appearState;
        private SlimeIdleState _idleState;
        private SlimeWanderState _wanderState;
        private SlimeJumpAttackState _jumpAttackState;
        private SlimeKnockOutState _knockOutState;

        protected override void Awake()
        {
            base.Awake();

            _appearState = new SlimeAppearState(this);
            _idleState = new SlimeIdleState(this);
            _wanderState = new SlimeWanderState(this);
            _jumpAttackState = new SlimeJumpAttackState(this);
            _knockOutState = new SlimeKnockOutState(this);

            _stateDict.Add(Appear, _appearState);
            _stateDict.Add(Idle, _idleState);
            _stateDict.Add(Wander, _wanderState);
            _stateDict.Add(JumpAttack, _jumpAttackState);
            _stateDict.Add(KnockOut, _knockOutState);

            ConnectTransitions();
        }

        private void Start()
        {
            SetInitialState(_appearState);
        }

        private void OnEnable()
        {
            HurtBox.OnHit += HurtBoxModule_OnHit;
        }

        private void OnDisable()
        {
            HurtBox.OnHit -= HurtBoxModule_OnHit;
        }

        private void HurtBoxModule_OnHit(Vector3 sourceDir)
        {
            // Apply force.
            var distance = sourceDir - transform.position;
            var reflectedDir = Vector2.Reflect(distance, distance.normalized).normalized;

            Rb.AddForce(reflectedDir * 15f * Rb.mass, ForceMode2D.Impulse);

            OnStateTransitioned(_currentState, KnockOut);
        }
    }
}

