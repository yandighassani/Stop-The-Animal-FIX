using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour {
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Timer _timer;

    [Header("UI Elements")]
    [SerializeField] private RectTransform _parentPanel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void OnEnable() {
        _scoreManager.OnScoreChanged += UpdateScore;
        _timer.OnTimerStart += UpdateTimer;
        _timer.OnTimerTick += UpdateTimer;
    }

    private void OnDisable() {
        _scoreManager.OnScoreChanged -= UpdateScore;
        _timer.OnTimerStart -= UpdateTimer;
        _timer.OnTimerTick -= UpdateTimer;
    }

    public void Hide() {
        _parentPanel.gameObject.SetActive(false);
    }

    private void UpdateScore(int score) {
        _scoreText.text = $"Score : {score}";
    }

    private void UpdateTimer(int timeRemaining) {
        _timerText.text = $"Timer : {timeRemaining}";
    }
}