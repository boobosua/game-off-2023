using UnityEngine;

namespace Scaleton
{
    public abstract class SlimeBaseState : State
    {
        protected SlimeStateMachine _sm;
        protected MoveModule _moveModule;
        protected JumpModule _jumpModule;
        protected GroundDetectorModule _edgeDetector;
        protected HurtBoxModule _hurtBox;
        protected Rigidbody2D _rb;
        protected Animator _animator;

        protected float _delayTimeCounter;
        protected float _direction = 1; // Right direction.

        public SlimeBaseState(SlimeStateMachine stateMachine)
        {
            _sm = stateMachine;

            _moveModule = _sm.MoveModule;
            _jumpModule = _sm.JumpModule;
            _edgeDetector = _sm.EdgeDetector;
            _hurtBox = _sm.HurtBox;

            _rb = _sm.Rb;
            _animator = _sm.Animator;
        }
    }
}

