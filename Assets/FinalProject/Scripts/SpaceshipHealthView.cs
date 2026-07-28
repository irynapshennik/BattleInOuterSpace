using TMPro;
using UnityEngine;

/// <summary>
/// Spaceship Health View
/// </summary>
public class SpaceshipHealthView : MonoBehaviour
{
    // Text UI Element
    [SerializeField] private TMP_Text _output;

    /// <summary>
    /// Display current and maximum values
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    public void Display(int value, int maxValue)
    {
        _output.text = $"{value} / {maxValue}";
    }
}
