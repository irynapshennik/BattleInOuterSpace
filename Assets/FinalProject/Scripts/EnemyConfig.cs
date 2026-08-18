using UnityEngine;

/// <summary>
/// Enemy Config
/// </summary>
[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Scriptable Objects/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    // Enemy Health Points
    [SerializeField] private int _health;

    // Enemy Movement Speed
    [SerializeField] private float _movementSpeed;

    // Enemy Attack Distance
    [SerializeField] private float _attackDistance;

    // Enemy Attack Frequency
    [SerializeField] private float _attackFrequency;

    // Enemy Attack Damage
    [SerializeField] private int _attackDamage;

    // Game Points
    [Tooltip("Added to the game score after destroying an enemy by player")]
    [SerializeField] private int _gamePoints;

    /// <summary>
    /// Get enemy health points
    /// </summary>
    public int Health => _health;

    /// <summary>
    /// Get enemy movement speed
    /// </summary>
    public float MovementSpeed => _movementSpeed;

    /// <summary>
    /// Get enemy attack distance
    /// </summary>
    public float AttackDistance => _attackDistance;

    /// <summary>
    /// Get enemy attack frequency
    /// </summary>
    public float AttackFrequency => _attackFrequency;

    /// <summary>
    /// Get enemy attack damage
    /// </summary>
    public int AttackDamage => _attackDamage;

    /// <summary>
    /// Get game points
    /// </summary>
    public int GamePoints => _gamePoints;
}
