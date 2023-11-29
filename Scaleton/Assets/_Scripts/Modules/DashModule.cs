using UnityEngine;
using UnityEngine.Events;

namespace Scaleton
{
    public class DashModule : MonoBehaviour
    {
        [SerializeField] private DashDataSO _data;
        [SerializeField] private Rigidbody2D _rb;

        public event UnityAction OnFinished;
        public bool CanDash { get; private set; } = true;
        public float LastDashPressedTime { get; private set; }

        private float _cooldownCounter;
        private float _startTime;
        private bool _isDashing = false;

        private void Update()
        {
            if (LastDashPressedTime > 0f)
            {
                LastDashPressedTime -= Time.deltaTime;
            }

            CheckDashCooldown();
            CheckDashFinish();
        }

        private void CheckDashCooldown()
        {
            // Refresh dash ability after the cooldown is finished.
            if (_cooldownCounter < 0f)
            {
                if (!CanDash)
                {
                    CanDash = true;
                }
            }
            else
            {
                _cooldownCounter -= Time.deltaTime;
            }
        }

        private void CheckDashFinish()
        {
            if (!_isDashing) return;

            if (Time.time - _startTime > _data.EndTime)
            {
                OnFinished?.Invoke();
                _isDashing = false;
            }
        }

        public void ResetBufferTime()
        {
            LastDashPressedTime = _data.BufferTime;
        }

        public void Dash(Vector2 direction)
        {
            // Disable dash ability.
            CanDash = false;

            // Start dash time.
            _startTime = Time.time;

            // Disable gravity scale before dashing.
            _rb.gravityScale = 0f;

            // Reset dash buffer.
            LastDashPressedTime = 0f;

            // Start cooldown.
            _cooldownCounter = _data.Cooldown;

            // Dash.
            _rb.velocity = direction.normalized * _data.Speed;
            _isDashing = true;
        }
    }
}

