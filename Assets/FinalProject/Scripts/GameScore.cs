using UnityEngine;

/// <summary>
/// Game Score
/// </summary>
public class GameScore : MonoBehaviour
{
    // Game Score View
    [SerializeField] private GameScoreView _view;

    // Value
    private int _value = 0;

    /// <summary>
    /// Add points to the game score
    /// </summary>
    /// <param name="amount"></param>
    public void AddPoints(int amount)
    {
        _value += Mathf.Abs(amount);
    }

    /// <summary>
    /// Display game score on the "Statistics" screen
    /// </summary>
    public void UpdateStatistics()
    {
        UpdateView();
    }

    /// <summary>
    /// Update view
    /// </summary>
    private void UpdateView()
    {
        _view.Display(_value);
    }
}
