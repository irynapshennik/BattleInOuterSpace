using UnityEngine;

/// <summary>
/// Spaceship Movement Handler
/// </summary>
public class SpaceshipMovementHandler : MonoBehaviour
{
    // Spaceship Config
    [SerializeField] private SpaceshipConfig _spaceshipConfig;

    // Spaceship Rigid Body
    [SerializeField] private Rigidbody _rigidbody;

    // Spaceship Movement Speed
    private float _movementSpeed;

    // Spaceship Rotation Speed
    private float _rotationSpeed;

    // Spaceship Maximum Movement Speed
    private float _maxMovementSpeed;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _movementSpeed = _spaceshipConfig.MovementSpeed;
        _maxMovementSpeed = _spaceshipConfig.MaxMovementSpeed;
        _rotationSpeed = _spaceshipConfig.RotationSpeed;
    }

    /// <summary>
    /// Move spaceship
    /// </summary>
    /// <param name="movementDirection"></param>
    /// <param name="isSpeedUp"></param>
    public void Move(Vector2 movementDirection, bool isSpeedUp)
    {
        Quaternion deltaRotation = Quaternion.Euler(0f, movementDirection.x * _rotationSpeed * Time.fixedDeltaTime, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);

        float movementSpeed = isSpeedUp ? _maxMovementSpeed : _movementSpeed;

        Quaternion rotationQuaternion = Quaternion.Euler(0f, movementDirection.x, movementDirection.y);
        _rigidbody.AddForce(rotationQuaternion * transform.forward * movementSpeed);
        _rigidbody.linearVelocity = Vector3.ClampMagnitude(_rigidbody.linearVelocity, movementSpeed);
    }
}
