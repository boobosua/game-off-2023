using UnityEngine;

namespace Scaleton
{
    public class Weight : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private HingeJoint2D _hingeJoint;
        [SerializeField] private DistanceJoint2D _distanceJoint;
        [SerializeField] private ProgressBarUI _progressBar;

        [Header("Parameters"), Space(1)]
        [SerializeField, Range(0f, 100000f)] private float _maxReactionForce = 20000f;

        private float _currentReactionForce;

        private void FixedUpdate()
        {
            // Prevent the reaction force check when the platform has already fallen.
            if (_hingeJoint == null || _distanceJoint == null) return;

            // Update the reaction force value.
            _currentReactionForce = Mathf.Abs(_hingeJoint.reactionForce.y);

            // Update progress UI.
            var percent = _currentReactionForce / _maxReactionForce;
            _progressBar.UpdateReactionForceBar(percent);

            // Destroy the platform connected link.
            if (_currentReactionForce >= _maxReactionForce)
            {
                Destroy(_hingeJoint);
                Destroy(_distanceJoint);
            }
        }
    }
}

