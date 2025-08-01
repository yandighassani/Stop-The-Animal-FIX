using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {
    [SerializeField] private RectTransform _gameOverMenu;
    [SerializeField] private TextMeshProUGUI _finalScoreText;

    public void Show(int finalScore) {
        _finalScoreText.text = $"Score : {finalScore}";
        _gameOverMenu.gameObject.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}