namespace Scaleton
{
    public class PlayerFallingState : PlayerBaseState
    {
        public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _jumpModule.SetDownGravity();
        }

        public override void Tick(float deltaTime)
        {
            if (_jumpModule.LastOnGroundTime > 0)
            {
                Transit(this, _sm.Idle);

                return;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _moveModule.Move(_input.MoveX, false);
        }

        public override void Exit()
        {
            _jumpModule.SetDefaultGravity();
        }
    }
}
