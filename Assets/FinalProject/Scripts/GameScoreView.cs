using TMPro;
using UnityEngine;

/// <summary>
/// Game Score View
/// </summary>
public class GameScoreView : MonoBehaviour
{
    // Text UI Element
    [SerializeField] private TMP_Text _output;

    /// <summary>
    /// Display value
    /// </summary>
    /// <param name="value"></param>
    public void Display(int value)
    {
        _output.text = value.ToString();
    }
}
