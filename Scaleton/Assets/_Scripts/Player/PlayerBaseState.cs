using UnityEngine;

namespace Scaleton
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine _sm;
        protected PlayerController _input;
        protected Rigidbody2D _rb;
        protected MoveModule _moveModule;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            _sm = stateMachine;

            _input = _sm.Input;
            _rb = _sm.Rb;
            _moveModule = _sm.MoveModule;
        }

        protected void OnJumpCut()
        {

        }
    }
}

