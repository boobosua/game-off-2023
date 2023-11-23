namespace Scaleton
{
    public class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _input.OnJumpPressed += PlayerController_OnJumpPressed;
        }

        public override void Tick(float deltaTime)
        {
            if (_input.MoveX == 0)
            {
                Transit(this, _sm.Idle);

                return;
            }

            if (_jumpModule.LastJumpPressedTime > 0)
            {
                Transit(this, _sm.Jumping);

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
            _moveModule.Move(_input.MoveX);
        }

        public override void Exit()
        {
            _input.OnJumpPressed -= PlayerController_OnJumpPressed;
        }
    }
}
