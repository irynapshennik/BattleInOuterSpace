using UnityEngine;

/// <summary>
/// Enemy Health
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    // Animation Trigger Name
    private const string AnimationTriggerName = "OnTakeDamage";
    
    // Enemy Config
    [SerializeField] private EnemyConfig _enemyConfig;

    // Animator
    [SerializeField] private Animator _animator;

    // Game Score
    private GameScore _gameScore;

    // Value
    private int _value;

    // Game Points (for destroying an enemy)
    private int _gamePoints;

    // Animation Trigger Name Hash
    private int _animationTriggerNameHash;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _value = _enemyConfig.Health;
        _gamePoints = _enemyConfig.GamePoints;
        _animationTriggerNameHash = Animator.StringToHash(AnimationTriggerName);

        _gameScore = FindAnyObjectByType<GameScore>();
    }

    /// <summary>
    /// Take damage to the enemy and add points to the game score
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        _value -= Mathf.Abs(amount);
        _animator.SetTrigger(_animationTriggerNameHash);

        if (_value <= 0)
        {
            _gameScore.AddPoints(_gamePoints);

            Destroy(gameObject);
        }
    }
}
