using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs = new();
    [SerializeField] private int _spawnCountPerInterval = 1;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private RangeFloat _spawnXRange = new(-6.2f, 6.2f);
    private bool _isSpawning = false;
    private Coroutine _spawnCoroutine;

    public void StartSpawning()
    {
        if (_isSpawning) return; // Prevent multiple coroutines from running simultaneously
        _isSpawning = true;
        _spawnCoroutine = StartCoroutine(SpawnEnemiesCoroutine());
    }

    public void StopSpawning()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
        _isSpawning = false;
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (_isSpawning)
        {
            for (int i = 0; i < _spawnCountPerInterval; i++)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (_enemyPrefabs.Count == 0) return;

        int randomIndex = Random.Range(0, _enemyPrefabs.Count);
        GameObject enemyPrefab = _enemyPrefabs[randomIndex];

        Vector3 spawnPosition = transform.position + new Vector3( _spawnXRange.GetRandomValue(), 0, 0);
        Instantiate(enemyPrefab, spawnPosition, transform.rotation);
    }
}
