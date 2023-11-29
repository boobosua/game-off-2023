using UnityEngine;

namespace Scaleton
{
    public class PlayerDashing : PlayerBaseState
    {
        private Vector2 _direction = Vector2.zero;
        private float _previousGravityScale;


        public PlayerDashing(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _dashModule.OnFinished += DashModule_OnFinished;

            // Calculate direction based on player movement input.
            if (_input.MoveX == 0f)
            {
                // When no input is received just dash in player facing direction.
                _direction.x = _moveModule.GetFacingDirectionX();
            }
            else
            {
                // Dash in movement input direction.
                _direction.x = _input.MoveX;
            }

            // Save previous state gravity scale.
            _previousGravityScale = _rb.gravityScale;

            // Perform the dash.
            _dashModule.Dash(_direction);
        }

        public override void Tick(float deltaTime)
        {

        }

        public override void FixedTick(float fixedDeltaTime)
        {

        }

        public override void Exit()
        {
            // Give back the gravity scale.
            _rb.gravityScale = _previousGravityScale;

            _dashModule.OnFinished -= DashModule_OnFinished;
        }

        private void DashModule_OnFinished()
        {
            if (_jumpModule.LastOnGroundTime > 0)
            {
                Transit(this, _sm.Idle);

                return;
            }
            else
            {
                Transit(this, _sm.Falling);

                return;
            }
        }
    }
}