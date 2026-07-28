using UnityEngine;

/// <summary>
/// Enemy Attack Handler
/// </summary>
public class EnemyAttackHandler : MonoBehaviour
{
    // Enemy Config
    [SerializeField] private EnemyConfig _enemyConfig;

    // Enemy Attack Damage
    private int _attackDamage;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _attackDamage = _enemyConfig.AttackDamage;
    }

    /// <summary>
    /// Take damage to the spaceship
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<SpaceshipHealth>(out var spaceshipHealth))
        {
            spaceshipHealth.TakeDamage(_attackDamage);

            Destroy(gameObject);
        }
    }
}
