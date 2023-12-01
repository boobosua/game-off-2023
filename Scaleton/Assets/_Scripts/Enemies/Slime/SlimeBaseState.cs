namespace Scaleton
{
    public abstract class SlimeBaseState : State
    {
        protected SlimeStateMachine _sm;
        protected MoveModule _moveModule;
        protected JumpModule _jumpModule;

        public SlimeBaseState(SlimeStateMachine stateMachine)
        {
            _sm = stateMachine;

            _moveModule = _sm.MoveModule;
            _jumpModule = _sm.JumpModule;
        }
    }
}

