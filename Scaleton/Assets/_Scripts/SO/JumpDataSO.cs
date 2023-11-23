using UnityEngine;

namespace Scaleton
{
    [CreateAssetMenu(fileName = "JumpData", menuName = "Data/Jump Data")]
    public class JumpDataSO : ScriptableObject
    {
        [field: SerializeField, Range(0.0f, 5.0f)] public float JumpHeight { get; private set; }
        [field: SerializeField, Range(0.0f, 10.0f)] public float DownwardMultiplier { get; private set; }
        [field: SerializeField, Range(0.0f, 10.0f)] public float UpwardMultiplier { get; private set; }
        [field: SerializeField, Range(0.0f, 0.2f)] public float CoyoteTime { get; private set; }
        [field: SerializeField, Range(0.0f, 0.2f)] public float JumpBufferTime { get; private set; }
    }
}


