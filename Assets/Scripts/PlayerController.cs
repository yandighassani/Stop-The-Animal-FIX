using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class RangeFloat
{
    public float Min;
    public float Max;

    public RangeFloat(float min, float max)
    {
        Min = min;
        Max = max;
    }

    public float GetRandomValue()
    {
        return Random.Range(Min, Max);
    }
}

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private RangeFloat _xClamp = new(-5f, 5f);

    [Header("Throw")]
    [SerializeField] private GameObject _throwablePrefab;
    [SerializeField] private Transform _throwPoint;

    [Header("Animation")]
    [SerializeField] private Animator _animator;

    private void OnEnable() {
        InputHandler.Instance.Controls.Gameplay.Throw.performed += Throw;
    }

    private void OnDisable() {
        InputHandler.Instance.Controls.Gameplay.Throw.performed -= Throw;
    }

    private void Throw(InputAction.CallbackContext _) 
    {
        Instantiate(_throwablePrefab, _throwPoint.position, Quaternion.identity);
        _animator.SetTrigger("Throw");
    }

    private void Update()
    {
        float input = InputHandler.Instance.Controls.Gameplay.Move.ReadValue<float>();
        if ((input > 0 && transform.position.x >= _xClamp.Max) ||
            (input < 0 && transform.position.x <= _xClamp.Min)) 
        {
            input = 0;
        }

        _animator.SetFloat("HorizontalMove", input);

        if (input == 0) return;
        Vector3 moveDirection = new(input, 0, 0);
        transform.Translate(_speed * Time.deltaTime * moveDirection);
    }

    public void GameOver()
    {
        _animator.SetTrigger("GameOver");
    }
}
