using UnityEngine;

namespace Scaleton
{
    public class MoveModule : MonoBehaviour
    {
        [SerializeField] private MoveDataSO _data;
        [SerializeField] private Transform _owner;
        [SerializeField] private Rigidbody2D _rb;

        private Vector2 _velocity;
        private bool _isFacingRight = true;

        public void Move(float direction, bool onGround = true)
        {
            _velocity = _rb.velocity;

            var desiredX = direction * _data.MaxSpeed;

            var accelerationRate = onGround ? _data.GroundAcceleration : _data.AirAcceleration;

            _velocity.x = Mathf.MoveTowards(_velocity.x, desiredX, accelerationRate * Time.deltaTime);

            _rb.velocity = _velocity;

            if (direction == 0) return;

            CheckDirectionToFace(direction > 0);
        }

        public void Stop() => Move(0f);

        public float GetFacingDirectionX() => _isFacingRight ? 1 : -1;

        private void CheckDirectionToFace(bool isMovingRight)
        {
            if (isMovingRight == _isFacingRight) return;

            var scale = _owner.localScale;
            scale.x *= -1;
            _owner.localScale = scale;

            _isFacingRight = !_isFacingRight;
        }
    }
}
