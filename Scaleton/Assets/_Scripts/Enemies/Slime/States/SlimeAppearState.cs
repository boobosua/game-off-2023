using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scaleton
{
    public class SlimeAppearState : SlimeBaseState
    {
        private readonly int AppearHash = Animator.StringToHash("A_SlimeAppear");
        private const float DelayTime = 0.55f;
        private List<String> _nextStates = new();

        public SlimeAppearState(SlimeStateMachine stateMachine) : base(stateMachine)
        {
            _nextStates.Add(_sm.Idle);
            _nextStates.Add(_sm.Wander);
        }

        public override void Enter()
        {
            // Temporarily disable rigidbody.
            _rb.isKinematic = true;

            // Play animation.
            _animator.Play(AppearHash);

            // Set counter time.
            _delayTimeCounter = DelayTime;
        }

        public override void Tick(float deltaTime)
        {
            if (_delayTimeCounter <= 0f)
            {
                // Give the slime back its gravity.
                _rb.isKinematic = false;

                _jumpModule.SetDownGravity();
            }
            else
            {
                _delayTimeCounter -= deltaTime;
            }

            // Allow the slime to be active when touching the ground.
            if (_jumpModule.LastOnGroundTime > 0f)
            {
                Transit(this, _nextStates.GetRandomElement());

                return;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {

        }

        public override void Exit()
        {
            _jumpModule.SetDefaultGravity();
        }
    }
}

