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

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            _sm = stateMachine;

            _input = _sm.Input;
            _rb = _sm.Rb;
            _moveModule = _sm.MoveModule;
            _jumpModule = _sm.JumpModule;
        }

        protected void PlayerController_OnJumpPressed()
        {
            _jumpModule.SetBuffer();
        }
    }
}

