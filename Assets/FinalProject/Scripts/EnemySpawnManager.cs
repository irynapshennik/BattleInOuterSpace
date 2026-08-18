using UnityEngine;

/// <summary>
/// Enemy Spawn Manager
/// </summary>
public class EnemySpawnManager : MonoBehaviour
{
    // Enemy Spawners
    [SerializeField] private EnemySpawner[] _enemySpawners;

    /// <summary>
    /// Start enemy spawn
    /// </summary>
    public void StartEnemySpawn()
    {
        foreach (var enemySpawner in _enemySpawners)
        {
            enemySpawner.StartEnemySpawn();
        }
    }

    /// <summary>
    /// Stop enemy spawn
    /// </summary>
    public void StopEnemySpawn()
    {
        foreach (var enemySpawner in _enemySpawners)
        {
            enemySpawner.StopEnemySpawn();
        }
    }
}
