using System.Collections;
using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    [SerializeField] private Vector3 _throwDirection = new(1, 0, 0);
    [SerializeField] private float _throwSpeed = 5f;
    [SerializeField] private float _lifeTime = 3f;

    private IEnumerator Start() {
        AudioManager.Instance.Play("Throw");
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        // Move the object in the specified direction at the specified speed
        transform.Translate(_throwSpeed * Time.deltaTime * _throwDirection);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Animal"))
        {
            Destroy(gameObject);
        }
    }
}
