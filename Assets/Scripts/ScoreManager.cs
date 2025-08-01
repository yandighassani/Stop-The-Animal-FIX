using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Action<int> OnScoreChanged;
    private int _score = 0;
    public int Score => _score;

    private void OnEnable() {
        Animal.OnAnimalGetHit += OnAnimalHit;
        Animal.OnAnimalPasses += OnAnimalPasses;
    }

    private void OnDisable() {
        Animal.OnAnimalGetHit -= OnAnimalHit;
        Animal.OnAnimalPasses -= OnAnimalPasses;
    }

    private void OnAnimalHit() {
        AddScore(1);
    }

    private void OnAnimalPasses() {
        DeductScore(3);
    }

    private void Start() {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
    }

    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreChanged?.Invoke(_score);
    }

    public void DeductScore(int amount)
    {
        _score -= amount;
        if (_score < 0) _score = 0; // Prevent negative score
        OnScoreChanged?.Invoke(_score);
    }
}
