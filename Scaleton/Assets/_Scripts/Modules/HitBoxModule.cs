using UnityEngine;

namespace Scaleton
{
    public class HitBoxModule : MonoBehaviour
    {
        [SerializeField] private bool _selfDestruct = false;
        [SerializeField, Range(0f, 10f)] private float _selfDestructTimer = 0.5f;

        private void Start()
        {
            if (!_selfDestruct) return;

            Destroy(gameObject, _selfDestructTimer);
        }
    }
}

