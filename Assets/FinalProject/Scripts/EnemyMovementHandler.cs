using UnityEngine;

/// <summary>
/// Enemy Movement Handler
/// </summary>
public class EnemyMovementHandler : MonoBehaviour
{
    // Repulsion Force
    private const float RepulsionForce = 1f;

    // Enemy Config
    [SerializeField] private EnemyConfig _enemyConfig;

    // Enemy Rigid Body
    [SerializeField] private Rigidbody _rigidbody;

    // Enemy Movement Speed
    private float _movementSpeed;

    // Enemy Attack Distance
    private float _attackDistance;

    // Enemy Target
    private GameObject _target;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _movementSpeed = _enemyConfig.MovementSpeed;
        _attackDistance = _enemyConfig.AttackDistance;

        _target = GameObject.FindWithTag("Player");
    }

    /// <summary>
    /// Move enemy and check if enemy can attack
    /// </summary>
    private void FixedUpdate()
    {        
        Vector3 targetPosition = GetTargetPosition();

        Vector3 targetDirection = targetPosition - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(targetDirection);

        _rigidbody.MoveRotation(newRotation);

        Vector3 newPosition = Vector3.MoveTowards(_rigidbody.position, targetPosition, _movementSpeed * Time.fixedDeltaTime);
        
        if (_attackDistance == 0 || Vector3.Distance(_rigidbody.position, targetPosition) > _attackDistance)
        {
            _rigidbody.MovePosition(newPosition);
        }
    }

    /// <summary>
    /// Handle enemy collisions
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out _))
        {
            Vector3 repulsionDirection = collision.transform.position - transform.position;
            collision.rigidbody.AddForce(repulsionDirection.normalized * RepulsionForce, ForceMode.Impulse);
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
