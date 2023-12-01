using UnityEngine;
using UnityEngine.Events;

namespace Scaleton
{
    public class HurtBoxModule : MonoBehaviour
    {
        public event UnityAction OnInstantDeath;
        public event UnityAction<Vector3> OnHit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Lava>(out var lava))
            {
                OnInstantDeath?.Invoke();
            }

            if (other.gameObject.TryGetComponent<HitBoxModule>(out var hitBox))
            {
                OnHit?.Invoke(hitBox.gameObject.transform.position);
            }
        }
    }
}

