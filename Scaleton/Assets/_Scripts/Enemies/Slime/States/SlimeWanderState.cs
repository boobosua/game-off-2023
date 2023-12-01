using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scaleton
{
    public class SlimeWanderState : SlimeBaseState
    {
        private readonly int WanderHash = Animator.StringToHash("A_SlimeWander");

        private List<String> _nextStates = new();
        private const float DelayTimeMax = 15f;
        private const float DelayTimeMin = 7f;

        public SlimeWanderState(SlimeStateMachine stateMachine) : base(stateMachine)
        {
            _nextStates.Add(_sm.Idle);
            _nextStates.Add(_sm.JumpAttack);
        }

        public override void Enter()
        {
            _animator.Play(WanderHash);

            _delayTimeCounter = UnityEngine.Random.Range(DelayTimeMin, DelayTimeMax);
        }

        public override void Tick(float deltaTime)
        {
            if (_delayTimeCounter <= 0f)
            {
                Transit(this, _nextStates.GetRandomElement());

                return;
            }
            else
            {
                if (!_edgeDetector.IsGrounded)
                {
                    StopAndChangeDirection();
                }

                _delayTimeCounter -= deltaTime;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _moveModule.Move(_direction);
        }

        public override void Exit()
        {

        }

        private void StopAndChangeDirection()
        {
            _moveModule.Stop();
            _direction = -_direction;
        }
    }
}

