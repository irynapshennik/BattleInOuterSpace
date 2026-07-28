using System.Collections;
using UnityEngine;

/// <summary>
/// Enemy Spawner
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    // Enemy Spawner Config
    [SerializeField] private EnemySpawnerConfig _config;

    // Enemy Spawn Frequency
    private float _enemySpawnFrequency;

    // Enemy Types
    private Transform[] _enemyTypes;

    // Maximum Enemy Count
    private int _maxEnemyCount = 1;

    // Difficulty
    private int _difficulty = 1;

    // Can Enemy Spawn Flag
    private bool _canSpawn = false;

    // Enemy Spawn Coroutine
    private Coroutine _coroutine = null;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _enemySpawnFrequency = _config.EnemySpawnFrequency;
        _enemyTypes = _config.EnemyTypes;
    }

    /// <summary>
    /// Check if enemy can spawn
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<SpaceshipHealth>(out _))
        {          
            _canSpawn = true;
        }
    }

    /// <summary>
    /// Check if enemy can spawn
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<SpaceshipHealth>(out _))
        {
            _canSpawn = false;
        }
    }

    /// <summary>
    /// Start enemy spawn
    /// </summary>
    public void StartEnemySpawn()
    {
        _coroutine ??= StartCoroutine(SpawnEnemy());
    }

    /// <summary>
    /// Stop enemy spawn
    /// </summary>
    public void StopEnemySpawn()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    /// <summary>
    /// Coroutine for spawning enemies with increasing difficulty
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_canSpawn)
            {
                for (int i = 0; i < _maxEnemyCount; i++)
                {
                    int randomIndex = Random.Range(0, _enemyTypes.Length);
                    Instantiate(_enemyTypes[randomIndex], transform.position, transform.rotation);
                }

                _difficulty++;

                if (_difficulty % 2 != 0)
                {
                    _maxEnemyCount++;
                }
            }

            yield return new WaitForSeconds(_enemySpawnFrequency);
        }
    }
}
