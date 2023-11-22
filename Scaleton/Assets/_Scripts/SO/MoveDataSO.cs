using UnityEngine;

namespace Scaleton
{
    [CreateAssetMenu(fileName = "MoveData", menuName = "Data/Move Data")]
    public class MoveDataSO : ScriptableObject
    {
        [field: SerializeField, Range(0f, 100f)] public float MaxSpeed { get; private set; }
        [field: SerializeField, Range(0f, 100f)] public float GroundAcceleration { get; private set; }
        [field: SerializeField, Range(0f, 100f)] public float AirAcceleration { get; private set; }
    }
}


