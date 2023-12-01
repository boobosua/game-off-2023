using UnityEngine;

namespace Scaleton
{
    public class GroundDetectorModule : MonoBehaviour
    {
        [SerializeField] private Transform _checkPoint;
        [SerializeField] private Vector2 _checkSize;
        [SerializeField] private LayerMask _checkLayer;

        public bool IsGrounded { get; private set; }

        private void FixedUpdate()
        {
            IsGrounded = GetOverlapBox();
        }

        private Collider2D GetOverlapBox()
        {
            return Physics2D.OverlapBox(_checkPoint.position, _checkSize, 0, _checkLayer);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(_checkPoint.position, _checkSize);
        }
    }
}
