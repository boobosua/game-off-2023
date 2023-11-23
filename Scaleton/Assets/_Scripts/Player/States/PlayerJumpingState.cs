using UnityEngine;

namespace Scaleton
{
    public class PlayerJumpingState : PlayerBaseState
    {
        public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _jumpModule.Jump();
            _jumpModule.SetUpGravity();
            _input.OnJumpReleased += CancelJump;
        }

        public override void Tick(float deltaTime)
        {
            if (_rb.velocity.y <= 0)
            {
                Transit(this, _sm.Falling);

                return;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _moveModule.Move(_input.MoveX, false);
        }

        public override void Exit()
        {
            _input.OnJumpReleased -= CancelJump;
            _jumpModule.SetDefaultGravity();
        }

        private void CancelJump()
        {
            _rb.velocity = Vector2.zero;
            Transit(this, _sm.Falling);
        }
    }
}

