using UnityEngine;

namespace Scaleton
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine _sm;
        protected PlayerController _input;
        protected Rigidbody2D _rb;
        protected MoveModule _moveModule;
        protected JumpModule _jumpModule;
        protected DashModule _dashModule;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            _sm = stateMachine;

            _input = _sm.Input;
            _rb = _sm.Rb;
            _moveModule = _sm.MoveModule;
            _jumpModule = _sm.JumpModule;
            _dashModule = _sm.DashModule;
        }

        protected void PlayerController_OnJumpPressed()
        {
            _jumpModule.ResetBufferTime();
        }

        protected void PlayerController_OnDashPressed()
        {
            if (!_dashModule.CanDash) return;

            _dashModule.ResetBufferTime();
        }
    }
}

