using UnityEngine;

namespace Scaleton
{
    [CreateAssetMenu(fileName = "DashData", menuName = "Data/Dash Data")]
    public class DashDataSO : ScriptableObject
    {
        [field: SerializeField, Range(0f, 100f)] public float Speed { get; private set; }
        [field: SerializeField, Range(0f, 2f)] public float EndTime { get; private set; }
        [field: SerializeField, Range(0f, 0.2f)] public float BufferTime { get; private set; }
        [field: SerializeField, Range(0f, 10f)] public float Cooldown { get; private set; }
    }
}

