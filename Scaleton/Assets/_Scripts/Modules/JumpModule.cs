using UnityEngine;

namespace Scaleton
{
    public class JumpModule : MonoBehaviour
    {
        [field: SerializeField] private JumpDataSO _data;
        [field: SerializeField] private GroundDetectorModule _detector;
        [field: SerializeField] private Rigidbody2D _rb;

        public float LastOnGroundTime { get; private set; }
        public float LastJumpPressedTime { get; private set; }

        private Vector2 _velocity;

        private void FixedUpdate()
        {
            if (_detector.IsGrounded)
            {
                LastOnGroundTime = _data.CoyoteTime;
            }
            else
            {
                LastOnGroundTime -= Time.deltaTime;
            }

            if (LastJumpPressedTime > 0f)
            {
                LastJumpPressedTime -= Time.deltaTime;
            }
        }

        public void SetBuffer()
        {
            LastJumpPressedTime = _data.JumpBufferTime;
        }

        public void SetDefaultGravity()
        {
            _rb.gravityScale = 1.0f;
        }

        public void SetUpGravity()
        {
            _rb.gravityScale = _data.UpwardMultiplier;
        }

        public void SetDownGravity()
        {
            _rb.gravityScale = _data.DownwardMultiplier;
        }

        public void Jump()
        {
            _velocity = _rb.velocity;

            var jumpVelocity = Mathf.Sqrt(-2f * Physics2D.gravity.y * _data.JumpHeight * _data.UpwardMultiplier);

            LastOnGroundTime = 0f;
            LastJumpPressedTime = 0f;

            _velocity.y += jumpVelocity;

            _rb.AddForce(_velocity, ForceMode2D.Impulse);
        }
    }
}

