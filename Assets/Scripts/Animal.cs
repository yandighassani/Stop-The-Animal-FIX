using System;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public static Action OnAnimalGetHit;
    public static Action OnAnimalPasses;

    [SerializeField] private Vector3 _moveDirection = new(0, 0, -1);
    [SerializeField] private float _moveSpeed = 5f;

    private void Update() {
        transform.Translate(_moveSpeed * Time.deltaTime * _moveDirection);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pizza")) {
            OnAnimalGetHit?.Invoke();
            AudioManager.Instance.PlayOneShot("Eat");
            Destroy(gameObject);
        } else if (other.CompareTag("Destroy")) {
            OnAnimalPasses?.Invoke();
            AudioManager.Instance.PlayOneShot("Destroy");
            Destroy(gameObject);
        }
    }
}
