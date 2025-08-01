using System.Collections;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameplayUI _gameplayUI;
    [SerializeField] private GameOverUI _gameOverUI;
    [SerializeField] private PlayerController _player;

    [Header("Game Settings")]
    [SerializeField] private int _initialTime = 60;

    private void OnEnable() {
        _timer.OnTimerFinish += FinalizeGame;
    }

    private void OnDisable() {
        _timer.OnTimerFinish -= FinalizeGame;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _timer.StartTimer(_initialTime);
        _cameraManager.UseGameplayCamera();
        _enemySpawner.StartSpawning();

        AudioManager.Instance.Play("Gameplay");
    }

    private void FinalizeGame()
    {
        _timer.StopTimer();
        _cameraManager.UseGameOverCamera();
        _enemySpawner.StopSpawning();
        _gameplayUI.Hide();

        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Animal");
        foreach (GameObject enemy in remainingEnemies)
        {
            Destroy(enemy);
        }

        AudioManager.Instance.PlayOneShot("GameOver");
        _player.GameOver();
        StartCoroutine(DisableControl());
        StartCoroutine(ShowGameOverUI());
    }

    private IEnumerator DisableControl()
    {
        yield return new WaitForSeconds(1f);
        InputHandler.Instance.ChangeInputMap(InputMapType.UI);
    }

    private IEnumerator ShowGameOverUI()
    {
        yield return new WaitForSeconds(2f);
        _gameOverUI.Show(_scoreManager.Score);
        InputHandler.Instance.ChangeInputMap(InputMapType.UI);
    }
}
