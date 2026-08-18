using UnityEngine;

/// <summary>
/// Missile Movement Handler
/// </summary>
public class MissileMovementHandler : MonoBehaviour
{
    // Missile Movement Speed
    private const float Speed = 50f;

    // Missile Rigid Body
    [SerializeField] private Rigidbody _rigidbody;
    
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _rigidbody.linearVelocity = transform.forward * Speed;
    }
}
