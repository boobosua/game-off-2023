using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scaleton
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject _PauseMenu;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private PlayerController _input;

        private bool _isGamePaused = false;

        private void Awake()
        {
            _continueButton.onClick.AddListener(() =>
            {
                TogglePauseGame();
            });

            _mainMenuButton.onClick.AddListener(() =>
            {
                QuitToMainMenu();
            });
        }

        private void OnEnable()
        {
            _input.OnPausePressed += TogglePauseGame;
        }

        private void OnDisable()
        {
            _input.OnPausePressed -= TogglePauseGame;
        }

        private void TogglePauseGame()
        {
            _isGamePaused = !_isGamePaused;

            if (_isGamePaused)
            {
                Time.timeScale = 0f;
                _PauseMenu.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                _PauseMenu.gameObject.SetActive(false);
            }
        }

        private void QuitToMainMenu()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}

