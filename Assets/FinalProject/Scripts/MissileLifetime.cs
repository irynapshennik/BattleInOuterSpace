using UnityEngine;

/// <summary>
/// Missile Lifetime
/// </summary>
public class MissileLifetime : MonoBehaviour
{
    // Missile Lifetime
    private const float Lifetime = 10f;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}
