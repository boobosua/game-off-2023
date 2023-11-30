using UnityEngine;
using UnityEngine.UI;

namespace Scaleton
{
    public class ProgressBarUI : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Image _progressFill;
        [SerializeField] private Sprite _greenFill;
        [SerializeField] private Sprite _yellowFill;
        [SerializeField] private Sprite _redFill;

        [Header("Settings"), Space(1)]
        [SerializeField, Range(0.4f, 0.6f)] private float _warningThreshold = 0.5f;
        [SerializeField, Range(0.7f, 0.95f)] private float _dangerThreshold = 0.8f;
    }
}

