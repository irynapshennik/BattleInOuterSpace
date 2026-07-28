using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Timer View
/// </summary>
public class TimerView : MonoBehaviour
{
    // Text UI Element
    [SerializeField] private TMP_Text _gameScreenOutput;

    // Text UI Element
    [SerializeField] private TMP_Text _statisticsScreenOutput;

    /// <summary>
    /// Display value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isStatistics">Flag for the "Statistics" screen</param>
    public void Display(float value, bool isStatistics)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(value);
        string formattedValue = timeSpan.ToString(@"mm\:ss");

        if (isStatistics)
        {
            _statisticsScreenOutput.text = formattedValue;
        } else
        {
            _gameScreenOutput.text = formattedValue;
        }
    }
}
