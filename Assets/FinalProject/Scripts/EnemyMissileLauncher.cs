using System.Collections;
using UnityEngine;

/// <summary>
/// Enemy Missile Launcher
/// </summary>
public class EnemyMissileLauncher : MonoBehaviour
{
    // Enemy Config
    [SerializeField] private EnemyConfig _enemyConfig;

    // Enemy Missile Prefab
    [SerializeField] private EnemyMissile _missile;

    // Enemy Launcher Positions
    [SerializeField] private Transform[] _launcherPositions;

    // Enemy Attack Distance
    private float _attackDistance;

    // Enemy Attack Frequency
    private float _attackFrequency;

    // Enemy Attack Damage Per Missile
    private int _attackDamage;

    // Enemy Target
    private GameObject _target;

    // Can Enemy Attack Flag
    private bool _canAttack = false;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _attackDistance = _enemyConfig.AttackDistance;
        _attackFrequency = _enemyConfig.AttackFrequency;
        _attackDamage = _enemyConfig.AttackDamage;

        _target = GameObject.FindWithTag("Player");

        StartCoroutine(LaunchMissile());
    }

    /// <summary>
    /// Check if enemy can attack
    /// </summary>
    private void Update()
    {
        Vector3 targetPosition = GetTargetPosition();

        _canAttack = Vector3.Distance(transform.position, targetPosition) <= _attackDistance;
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Coroutine for launching enemy missiles
    /// </summary>
    /// <returns></returns>
    private IEnumerator LaunchMissile()
    {
        while (true)
        {
            if (_canAttack) 
            {                
                foreach (Transform launcherPosition in _launcherPositions) 
                {
                    EnemyMissile missile = Instantiate(_missile, launcherPosition.position, transform.rotation);
                    missile.Damage = _attackDamage;
                }
            }

            yield return new WaitForSeconds(_attackFrequency);
        }
    }

    /// <summary>
    /// Get enemy target position
    /// </summary>
    /// <returns></returns>
    private Vector3 GetTargetPosition()
    {
        return _target.transform.position;
    }
}
