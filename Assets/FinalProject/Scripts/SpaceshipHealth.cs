using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Spaceship Health
/// </summary>
public class SpaceshipHealth : MonoBehaviour
{
    // Spaceship Config
    [SerializeField] private SpaceshipConfig _spaceshipConfig;

    // Spaceship Health View
    [SerializeField] private SpaceshipHealthView _view;

    // Current Value
    private int _value;

    // Maximum Value
    private int _maxValue;

    // Unity Event
    [SerializeField] private UnityEvent _onSpaceshipDestroyed;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _maxValue = _spaceshipConfig.Health;
        _value = _maxValue;

        UpdateView();
    }

    /// <summary>
    /// Take damage to the spaceship
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        int newValue = _value - Mathf.Abs(amount);

        if (newValue <= 0)
        {
            _onSpaceshipDestroyed.Invoke();
        }

        _value = Mathf.Max(newValue, 0);

        UpdateView();
    }

    /// <summary>
    /// Update view
    /// </summary>
    private void UpdateView()
    {
        _view.Display(_value, _maxValue);
    }
}
