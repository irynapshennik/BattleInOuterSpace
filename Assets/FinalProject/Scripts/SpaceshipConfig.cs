using UnityEngine;

/// <summary>
/// Spaceship Config
/// </summary>
[CreateAssetMenu(fileName = "SpaceshipConfig", menuName = "Scriptable Objects/SpaceshipConfig")]
public class SpaceshipConfig : ScriptableObject
{
    // Spaceship Health Points
    [SerializeField] private int _health;

    // Spaceship Movement Speed
    [SerializeField] private float _movementSpeed;

    // Spaceship Rotation Speed
    [SerializeField] private float _rotationSpeed;

    // Spaceship Maximum Movement Speed
    [SerializeField] private float _maxMovementSpeed;

    // Spaceship Movement Speed Boost Duration
    [SerializeField] private float _movementSpeedBoostDuration;

    // Spaceship Movement Speed Boost Recharge Time
    [SerializeField] private float _movementSpeedBoostRechargeTime;

    // Spaceship Attack Damage per Missile
    [Tooltip("Per Missile")]
    [SerializeField] private int _attackDamage;

    // Spaceship Maximum Missile Launches
    [SerializeField] private int _maxMissileLaunchCount;

    // Spaceship Missile Launch Energy Recharge Rate
    [SerializeField] private float _missileLaunchEnergyRechargeRate;

    /// <summary>
    /// Get spaceship health points
    /// </summary>
    public int Health => _health;

    /// <summary>
    /// Get spaceship movement speed
    /// </summary>
    public float MovementSpeed => _movementSpeed;

    /// <summary>
    /// Get spaceship rotation speed
    /// </summary>
    public float RotationSpeed => _rotationSpeed;

    /// <summary>
    /// Get spaceship maximum movement speed
    /// </summary>
    public float MaxMovementSpeed => _maxMovementSpeed;

    /// <summary>
    /// Get spaceship movement speed boost duration
    /// </summary>
    public float MovementSpeedBoostDuration => _movementSpeedBoostDuration;

    /// <summary>
    /// Get spaceship movement speed boost recharge time
    /// </summary>
    public float MovementSpeedBoostRechargeTime => _movementSpeedBoostRechargeTime;

    /// <summary>
    /// Get spaceship attack damage per missile
    /// </summary>
    public int AttackDamage => _attackDamage;

    /// <summary>
    /// Get spaceship maximum missile launches
    /// </summary>
    public int MaxMissileLaunchCount => _maxMissileLaunchCount;

    /// <summary>
    /// Get spaceship missile launch energy recharge rate
    /// </summary>
    public float MissileLaunchEnergyRechargeRate => _missileLaunchEnergyRechargeRate;
}
