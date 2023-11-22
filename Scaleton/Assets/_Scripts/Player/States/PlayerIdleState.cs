namespace Scaleton
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {

        }

        public override void Tick(float deltaTime)
        {
            if (_input.MoveX != 0)
            {
                Transit(this, _sm.Run);

                return;
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
