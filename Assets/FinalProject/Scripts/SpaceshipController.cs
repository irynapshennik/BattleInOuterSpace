using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Spaceship Controller
/// </summary>
public class SpaceshipController : MonoBehaviour
{
    // Spaceship Config
    [SerializeField] private SpaceshipConfig _spaceshipConfig;

    // Spaceship Movement Handler
    [SerializeField] private SpaceshipMovementHandler _spaceshipMovementHandler;

    // Spaceship Missile Launcher
    [SerializeField] private SpaceshipMissileLauncher _spaceshipMissileLauncher;

    // Spaceship Speed Boost Recharge Timer
    [SerializeField] private SpaceshipSpeedBoostRechargeTimer _spaceshipSpeedBoostRechargeTimer;

    // Spaceship Movement Speed Boost Duration
    private float _movementSpeedBoostDuration;

    // Spaceship Movement Direction
    private Vector2 _movementDirection = Vector2.zero;

    // Is Speed Up Flag
    private bool _isSpeedUp = false;

    // Spaceship Movement Speed Boost Duration Coroutine
    private Coroutine _coroutine = null;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _movementSpeedBoostDuration = _spaceshipConfig.MovementSpeedBoostDuration;
    }

    /// <summary>
    /// Move spaceship
    /// </summary>
    private void FixedUpdate()
    {
        _spaceshipMovementHandler.Move(_movementDirection, _isSpeedUp);
    }

    /// <summary>
    /// Set movement direction
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnMove(InputValue inputValue)
    {
        _movementDirection = inputValue.Get<Vector2>();
    }

    /// <summary>
    /// Handle spaceship attack
    /// </summary>
    public void OnAttack()
    {
        _spaceshipMissileLauncher.Attack();
    }

    /// <summary>
    /// Handle spaceship speed boost
    /// </summary>
    /// <param name="value"></param>
    public void OnJump(InputValue value)
    {
        if (!_spaceshipSpeedBoostRechargeTimer.IsRunning()) {
            _isSpeedUp = value.isPressed;
            ResetIsSpeedUpValue();

            _spaceshipSpeedBoostRechargeTimer.StartTimer();
        }
    }

    /// <summary>
    /// Reset the speed up flag value
    /// </summary>
    private void ResetIsSpeedUpValue()
    {
        _coroutine ??= StartCoroutine(IsSpeedUp());
    }

    /// <summary>
    /// Coroutine for resetting the speed up flag
    /// </summary>
    /// <returns></returns>
    private IEnumerator IsSpeedUp()
    {
        yield return new WaitForSeconds(_movementSpeedBoostDuration);

        _isSpeedUp = false;
        _coroutine = null;

        yield break;
    }
}
