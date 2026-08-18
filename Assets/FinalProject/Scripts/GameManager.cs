using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Game Manager
/// </summary>
public class GameManager : MonoBehaviour
{
    // Player Action Map Name
    private const string PlayerActionMapName = "Player";

    // "Menu" Screen
    [SerializeField] private GameObject _menuScreen;

    // "Game" Screen
    [SerializeField] private GameObject _gameScreen;

    // "Statistics" Screen
    [SerializeField] private GameObject _statisticsScreen;

    // "Pause" Button Container
    [SerializeField] private GameObject _pauseButtonContainer;

    // "Resume" Button Container
    [SerializeField] private GameObject _resumeButtonContainer;

    // Timer 
    [SerializeField] private Timer _timer;

    // Game Score
    [SerializeField] private GameScore _gameScore;

    // Player Action Map
    private InputActionMap _playerActionMap;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();
        _playerActionMap = playerInput.actions.FindActionMap(PlayerActionMapName);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        Time.timeScale = 0f;
        _playerActionMap.Disable();
        SwitchToMenuScreen();  
    }

    /// <summary>
    /// Start game
    /// </summary>
    public void StartGame()
    {
        _playerActionMap.Enable();
        Time.timeScale = 1f;
        _timer.StartTimer();
        SwithToGameScreen();
    }

    /// <summary>
    /// Pause game
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pauseButtonContainer.SetActive(false);
        _resumeButtonContainer.SetActive(true);
    }

    /// <summary>
    /// Resume game
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pauseButtonContainer.SetActive(true);
        _resumeButtonContainer.SetActive(false);
    }

    /// <summary>
    /// Restart game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Stop game
    /// </summary>
    public void StopGame()
    {
        _timer.StopTimer();
        _timer.UpdateStatistics();
        _gameScore.UpdateStatistics();

        SwitchToStatisticsScreen();

        _playerActionMap.Disable();
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Swith to the "Menu" screen
    /// </summary>
    private void SwitchToMenuScreen()
    {
        _menuScreen.SetActive(true);
        _gameScreen.SetActive(false);
        _statisticsScreen.SetActive(false);
    }

    /// <summary>
    /// Swith to the "Game" screen
    /// </summary>
    private void SwithToGameScreen()
    {
        _menuScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _statisticsScreen.SetActive(false);

        _resumeButtonContainer.SetActive(false);
        _pauseButtonContainer.SetActive(true);
    }

    /// <summary>
    /// Swith to the "Statistics" screen
    /// </summary>
    private void SwitchToStatisticsScreen()
    {
        _menuScreen.SetActive(false);
        _gameScreen.SetActive(false);
        _statisticsScreen.SetActive(true);
    }
}
