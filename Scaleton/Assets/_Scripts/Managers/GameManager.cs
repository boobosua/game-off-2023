using UnityEngine;

namespace Scaleton
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int _maxFPS = 60;

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = _maxFPS;
        }
    }
}

