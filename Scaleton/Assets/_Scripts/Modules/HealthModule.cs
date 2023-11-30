using UnityEngine;

namespace Scaleton
{
    public class HealthModule : MonoBehaviour
    {
        [SerializeField] private GameObject _owner;
        [SerializeField] private HurtBoxModule _hurtBox;

        private void OnEnable()
        {
            _hurtBox.OnInstantDeath += HurtBox_OnInstantDeath;
        }

        private void OnDisable()
        {
            _hurtBox.OnInstantDeath -= HurtBox_OnInstantDeath;
        }

        private void HurtBox_OnInstantDeath()
        {
            Debug.Log($"Destroyed {_owner.name}.");

            Destroy(_owner);
        }
    }
}

