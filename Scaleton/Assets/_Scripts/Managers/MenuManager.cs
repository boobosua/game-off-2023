using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scaleton
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _startButton.onClick.AddListener(() =>
            {
                ToGameScene();
            });

            _quitButton.onClick.AddListener(() =>
            {
                Quit();
            });
        }

        private void ToGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}

