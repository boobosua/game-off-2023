using UnityEngine;
using UnityEngine.SceneManagement;

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

        private void OnEnable()
        {
            PlayerStateMachine.OnPlayerDied += () => { SceneManager.LoadScene("MainMenuScene"); };
        }
    }
}

