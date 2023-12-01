using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scaleton
{
    public class SlimeJumpAttackState : SlimeBaseState
    {
        private List<String> _nextStates = new();

        public SlimeJumpAttackState(SlimeStateMachine stateMachine) : base(stateMachine)
        {
            _nextStates.Add(_sm.Idle);
            _nextStates.Add(_sm.Wander);
        }

        public override void Enter()
        {
            _rb.velocity = Vector2.zero;
            _jumpModule.SetUpGravity();
            _jumpModule.Jump();
        }

        public override void Tick(float deltaTime)
        {
            // Check when the slime is going down.
            if (_rb.velocity.y <= 0)
            {
                _jumpModule.SetDownGravity();

                if (_jumpModule.LastOnGroundTime > 0f)
                {
                    Transit(this, _nextStates.GetRandomElement());

                    return;
                }
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _moveModule.Stop();
        }

        public override void Exit()
        {
            _jumpModule.SetDefaultGravity();
        }
    }
}
