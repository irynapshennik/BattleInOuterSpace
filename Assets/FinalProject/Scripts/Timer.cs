using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Timer
/// </summary>
public class Timer : MonoBehaviour
{
    // Interval
    private const float Interval = 1f;

    // Timer View
    [SerializeField] private TimerView _view;

    // Value
    private float _value = 0f;

    // Timer Coroutine
    private Coroutine _coroutine = null;

    // Unity Event
    [SerializeField] private UnityEvent _onTimerStart;
    
    // Unity Event
    [SerializeField] private UnityEvent _onTimerStop;

    /// <summary>
    /// Start timer
    /// </summary>
    public void StartTimer()
    {
        _coroutine ??= StartCoroutine(Run());
        _onTimerStart.Invoke();
    }

    /// <summary>
    /// Stop timer
    /// </summary>
    public void StopTimer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            _onTimerStop.Invoke();
        }
    }

    /// <summary>
    /// Display time on the "Statistics" screen
    /// </summary>
    public void UpdateStatistics()
    {
        UpdateView(true);
    }

    /// <summary>
    /// Coroutine for running the timer
    /// </summary>
    /// <returns></returns>
    private IEnumerator Run()
    {
        while (true)
        {
            _value++;
            UpdateView();

            yield return new WaitForSeconds(Interval);
        }
    }

    /// <summary>
    /// Update view
    /// </summary>
    /// <param name="isStatistics">Flag for the "Statistics" screen</param>
    private void UpdateView(bool isStatistics = false)
    {
        _view.Display(_value, isStatistics);
    }
}
