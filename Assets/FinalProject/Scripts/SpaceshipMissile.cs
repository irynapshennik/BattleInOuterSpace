using UnityEngine;

/// <summary>
/// Spaceship Missile
/// </summary>
public class SpaceshipMissile : MonoBehaviour
{
    /// <summary>
    /// Spaceship Missile Damage
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
    /// Take damage to the enemy
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }
}
