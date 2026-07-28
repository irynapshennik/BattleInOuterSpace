using UnityEngine;

/// <summary>
/// Enemy Missile
/// </summary>
public class EnemyMissile : MonoBehaviour
{
    /// <summary>
    /// Enemy Missile Damage
    /// </summary>
    public int Damage { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        Damage = 0;
    }

    /// <summary>
    /// Take damage to the spaceship
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SpaceshipHealth>(out var spaceshipHealth))
        {
            spaceshipHealth.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
