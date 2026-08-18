using UnityEngine;

/// <summary>
/// Player Action Controller
/// </summary>
public class PlayerActionController : MonoBehaviour
{
    // Game Manager
    [SerializeField] private GameManager _gameManager;

    /// <summary>
    /// Handle the "Play" button click
    /// </summary>
    public void OnPlayButtonClick()
    {
        _gameManager.StartGame();
    }

    /// <summary>
    /// Handle the "Pause" button click
    /// </summary>
    public void OnPauseButtonClick() 
    {
        _gameManager.PauseGame();
    }

    /// <summary>
    /// Handle the "Resume" button click
    /// </summary>
    public void OnResumeButtonClick()
    {
        _gameManager.ResumeGame();
    }

    /// <summary>
    /// Handle the "Menu" button click
    /// </summary>
    public void OnMenuButtonClick()
    {
        _gameManager.RestartGame();
    }
}
