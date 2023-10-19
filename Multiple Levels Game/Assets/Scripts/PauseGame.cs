using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import Unity's scene management

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button resumeButton;
    public Button restartButton;
    public Button mainMenuButton;

    private bool isPaused = false;

    void Start()
    {
        // Initially, the pause menu is hidden.
        pauseMenuPanel.SetActive(false);

        // Set button click listeners.
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGamee();
        }
    }

    public void PauseGamee()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause the game's time.
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Unpause the game's time.
        pauseMenuPanel.SetActive(false);
    }

    public void RestartGame()
    {
        // Implement your restart logic here.
        // For example, you can reload the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     public void ReturnToMainMenu()
    {
        // Implement the logic to return to the main menu here.
        SceneManager.LoadScene("Menu"); // Replace "MainMenu" with your main menu scene's name.
    }
}
