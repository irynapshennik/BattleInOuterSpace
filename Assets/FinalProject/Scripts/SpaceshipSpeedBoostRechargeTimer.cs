using System.Collections;
using UnityEngine;

/// <summary>
/// Spaceship Speed Boost Recharge Timer
/// </summary>
public class SpaceshipSpeedBoostRechargeTimer : MonoBehaviour
{
    // Countdown Interval
    private const float CountdownInterval = 0.1f;

    // Spaceship Config
    [SerializeField] private SpaceshipConfig _spaceshipConfig;

    // Spaceship Speed Boost Recharge Timer View
    [SerializeField] private SpaceshipSpeedBoostRechargeTimerView _view;

    // Start Time
    private float _startTime;

    // Timer Coroutine
    private Coroutine _coroutine = null;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _startTime = _spaceshipConfig.MovementSpeedBoostRechargeTime;

        UpdateView(_startTime, _startTime);
    }

    /// <summary>
    /// Start timer
    /// </summary>
    public void StartTimer()
    {
        _coroutine ??= StartCoroutine(CountdownTime(_startTime));
    }

    /// <summary>
    /// Check if timer is running
    /// </summary>
    /// <returns></returns>
    public bool IsRunning()
    {
        return _coroutine != null;
    }

    /// <summary>
    /// Coroutine for the timer countdown
    /// </summary>
    /// <param name="startTime"></param>
    /// <returns></returns>
    private IEnumerator CountdownTime(float startTime)
    {
        float remainingTime = 0f;

        do
        {
            yield return new WaitForSeconds(CountdownInterval);

            remainingTime += CountdownInterval;
            UpdateView(startTime, remainingTime);
        } while (remainingTime < startTime);

        _coroutine = null;

        yield break;
    }

    /// <summary>
    /// Update view
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="remainingTime"></param>
    private void UpdateView(float startTime, float remainingTime)
    {
        _view.Display(startTime, remainingTime);
    }
}
