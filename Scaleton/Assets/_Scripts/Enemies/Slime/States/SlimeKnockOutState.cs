namespace Scaleton
{
    public class SlimeKnockOutState : SlimeBaseState
    {
        private const float KnockOutTime = 0.5f;

        public SlimeKnockOutState(SlimeStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _moveModule.Stop();
            _jumpModule.SetUpGravity();
            _hurtBox.enabled = false;
            _rb.sharedMaterial = _sm.Bouncy;

            _delayTimeCounter = KnockOutTime;
        }

        public override void Tick(float deltaTime)
        {
            if (_delayTimeCounter <= 0f)
            {
                if (_rb.velocity.y <= 0)
                {
                    _jumpModule.SetDownGravity();

                    if (_jumpModule.LastOnGroundTime > 0f)
                    {
                        Transit(this, _sm.Idle);

                        return;
                    }
                }
            }
            else
            {
                _delayTimeCounter -= deltaTime;
            }
        }

        public override void FixedTick(float fixedDeltaTime)
        {

        }

        public override void Exit()
        {
            _hurtBox.enabled = true;
            _rb.sharedMaterial = _sm.Frictionless;
        }
    }
}

