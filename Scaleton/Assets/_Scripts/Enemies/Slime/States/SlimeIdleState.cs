using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scaleton
{
    public class SlimeIdleState : SlimeBaseState
    {
        private readonly int IdleHash = Animator.StringToHash("A_SlimeIdle");
        private List<String> _nextStates = new();
        private const float DelayTimeMax = 10f;
        private const float DelayTimeMin = 5f;

        public SlimeIdleState(SlimeStateMachine stateMachine) : base(stateMachine)
        {
            // _nextStates.Add(_sm.Wander);
            _nextStates.Add(_sm.JumpAttack);
        }

        public override void Enter()
        {
            _animator.Play(IdleHash);

            _delayTimeCounter = UnityEngine.Random.Range(DelayTimeMin, DelayTimeMax);

            _jumpModule.SetDefaultGravity();
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
                _delayTimeCounter -= deltaTime;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _moveModule.Stop();
        }

        public override void Exit()
        {

        }
    }
}

