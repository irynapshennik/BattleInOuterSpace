using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spaceship Speed Boost Recharge Timer View
/// </summary>
public class SpaceshipSpeedBoostRechargeTimerView : MonoBehaviour
{
    // Slider UI Element
    [SerializeField] private Slider _output;

    /// <summary>
    /// Display the remaining time
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="remainingTime"></param>
    public void Display(float startTime, float remainingTime)
    {
        float progress = remainingTime / startTime;

        _output.value = progress;
    }
}
