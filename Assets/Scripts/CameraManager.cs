using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _gameplayCamera;
    [SerializeField] private Camera _gameOverCamera;

    public void UseGameplayCamera()
    {
        _gameplayCamera.gameObject.SetActive(true);
        _gameOverCamera.gameObject.SetActive(false);
    }

    public void UseGameOverCamera()
    {
        _gameplayCamera.gameObject.SetActive(false);
        _gameOverCamera.gameObject.SetActive(true);
    }
}
