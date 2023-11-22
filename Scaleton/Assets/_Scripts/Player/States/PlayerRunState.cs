namespace Scaleton
{
    public class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {

        }

        public override void Tick(float deltaTime)
        {
            if (_input.MoveX == 0)
            {
                Transit(this, _sm.Idle);

                return;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _moveModule.Move(_input.MoveX);
        }

        public override void Exit()
        {

        }
    }
}
