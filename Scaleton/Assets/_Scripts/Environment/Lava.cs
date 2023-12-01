using Unity.Mathematics;
using UnityEngine;

namespace Scaleton
{
    public class Lava : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionVFX;

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Splash sound, effect, etc...
            Instantiate(_explosionVFX, other.gameObject.transform.position, quaternion.identity);
        }
    }
}

