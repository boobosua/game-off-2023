namespace Scaleton
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _input.OnJumpPressed += PlayerController_OnJumpPressed;
            _input.OnDashPressed += PlayerController_OnDashPressed;
        }

        public override void Tick(float deltaTime)
        {
            if (_input.MoveX != 0)
            {
                Transit(this, _sm.Run);

                return;
            }

            if (_jumpModule.LastJumpPressedTime > 0)
            {
                Transit(this, _sm.Jumping);

                return;
            }

            if (_dashModule.LastDashPressedTime > 0)
            {
                Transit(this, _sm.Dashing);

                return;
            }

            if (_jumpModule.LastOnGroundTime <= 0)
            {
                Transit(this, _sm.Falling);

                return;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _moveModule.Stop();
        }

        public override void Exit()
        {
            _input.OnJumpPressed -= PlayerController_OnJumpPressed;
            _input.OnDashPressed -= PlayerController_OnDashPressed;
        }
    }

}
