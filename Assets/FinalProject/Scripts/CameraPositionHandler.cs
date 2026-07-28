using UnityEngine;

/// <summary>
/// Camera Positon Handler
/// </summary>
public class CameraPositionHandler : MonoBehaviour
{
    // Target
    [Tooltip("Spaceship")]
    [SerializeField] private Transform _target;

    // Camera Offset
    [SerializeField] private Vector3 _offset = new Vector3(0f, 25f, 0f);

    // Interpolation Ratio
    [SerializeField] private float _interpolationRatio = 0.125f;

    /// <summary>
    /// 
    /// </summary>
    private void FixedUpdate()
    {
        if (_target != null)
        {
            Vector3 offsetPosition = Vector3.Lerp(transform.position, _target.position + _offset, _interpolationRatio);

            transform.position = offsetPosition;
        }
    }
}
