using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action<int> OnTimerStart;
    public Action<int> OnTimerTick;
    public Action OnTimerFinish;

    private int _timeRemaining;
    private bool _isRunning = false;


    public void StartTimer(int duration)
    {
        _timeRemaining = duration;
        _isRunning = true;
        OnTimerStart?.Invoke(_timeRemaining);
        StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    private IEnumerator TimerCoroutine()
    {
        while (_isRunning && _timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            _timeRemaining--;
            OnTimerTick?.Invoke(_timeRemaining);
        }

        if (_timeRemaining <= 0)
        {
            EndTimer();
        }
    }

    public void EndTimer()
    {
        OnTimerTick?.Invoke(0);
        _isRunning = false;
        _timeRemaining = 0;
        OnTimerFinish?.Invoke();
    }
}
