using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private RectTransform _pauseMenu;

    private void OnEnable() {
        InputHandler.Instance.Controls.Gameplay.Pause.performed += PauseCallback;
        InputHandler.Instance.Controls.Pause.Resume.performed += ResumeCallback;
    }

    private void OnDisable() {
        InputHandler.Instance.Controls.Gameplay.Pause.performed -= PauseCallback;
        InputHandler.Instance.Controls.Pause.Resume.performed -= ResumeCallback;
    }

    private void PauseCallback(InputAction.CallbackContext _) { PauseGame(); }
    private void ResumeCallback(InputAction.CallbackContext _) { ResumeGame(); }

    public void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        InputHandler.Instance.ChangeInputMap(InputMapType.Pause);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pauseMenu.gameObject.SetActive(false);
        InputHandler.Instance.ChangeInputMap(InputMapType.Gameplay);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
