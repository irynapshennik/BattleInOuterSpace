using UnityEngine;

/// <summary>
/// Enemy Spawner Config
/// </summary>
[CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Scriptable Objects/EnemySpawnerConfig")]
public class EnemySpawnerConfig : ScriptableObject
{
    // Enemy Spawn Frequency
    [SerializeField] private float _enemySpawnFrequency;

    // Enemy Types
    [SerializeField] private Transform[] _enemyTypes;
    
    /// <summary>
    /// Get enemy spawn frequency
    /// </summary>
    public float EnemySpawnFrequency => _enemySpawnFrequency;

    /// <summary>
    /// Get enemy types
    /// </summary>
    public Transform[] EnemyTypes => _enemyTypes;
}
