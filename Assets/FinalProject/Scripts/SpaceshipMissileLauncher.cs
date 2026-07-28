using System.Collections;
using UnityEngine;

/// <summary>
/// Spaceship Missile Launcher
/// </summary>
public class SpaceshipMissileLauncher : MonoBehaviour
{
    // Spaceship Config
    [SerializeField] private SpaceshipConfig _spaceshipConfig;

    // Spaceship Missile Prefab
    [SerializeField] private SpaceshipMissile _missile;

    // Spaceship Launcher Positions
    [SerializeField] private Transform[] _launcherPositions;

    // Spaceship Missile Launch Count View
    [SerializeField] private SpaceshipMissileLaunchCountView _missileLaunchCountView;

    // Spaceship Attack Damage per Missile
    private int _attackDamage;

    // Spaceship Maximum Missile Launches
    private int _maxMissileLaunchCount;

    // Spaceship Missile Launch Energy Recharge Rate
    private float _missileLaunchEnergyRechargeRate;

    // Spaceship Current Missile Launches
    private int _missleLaunchCount;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _attackDamage = _spaceshipConfig.AttackDamage;
        _maxMissileLaunchCount = _spaceshipConfig.MaxMissileLaunchCount;
        _missileLaunchEnergyRechargeRate = _spaceshipConfig.MissileLaunchEnergyRechargeRate;

        _missleLaunchCount = _maxMissileLaunchCount;

        UpdateView();

        StartCoroutine(RechargeMissileLaunchEnergy());
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Launch spaceship missiles
    /// </summary>
    public void Attack()
    {
        if (_missleLaunchCount > 0)
        {
            foreach (Transform launcherPosition in _launcherPositions)
            {
                SpaceshipMissile missile = Instantiate(_missile, launcherPosition.position, launcherPosition.rotation);
                missile.Damage = _attackDamage;
            }

            _missleLaunchCount--;
            UpdateView();
        }
    }

    /// <summary>
    /// Coroutine for recharging missile launch energy
    /// </summary>
    /// <returns></returns>
    private IEnumerator RechargeMissileLaunchEnergy()
    {
        while (true)
        {
            if (_missleLaunchCount < _maxMissileLaunchCount)
            {
                _missleLaunchCount++;
                UpdateView();
            }

            yield return new WaitForSeconds(_missileLaunchEnergyRechargeRate);
        }
    }

    /// <summary>
    /// Update view
    /// </summary>
    private void UpdateView()
    {
        _missileLaunchCountView.Display(_missleLaunchCount, _maxMissileLaunchCount);
    }
}
