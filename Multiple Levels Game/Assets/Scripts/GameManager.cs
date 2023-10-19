using UnityEngine; // Import Unity's core functionality
using UnityEngine.SceneManagement; // Import Unity's scene management
using UnityEngine.UI; // Import Unity's UI components
using TMPro; // Import TextMesh Pro for advanced text rendering

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance of the GameManager

    private int enemyCount = 0; // Counter for enemies
    private int unlockedLevels = 1; // Track unlocked levels
    public TextMeshProUGUI countText; // Text field to display enemy count
    public GameObject gameOverText; // UI object to display game over message
    private bool isGameOver = false; // Flag to indicate if the game is over
    public GameObject gameOverUI; // UI object for the game over screen
    public GameObject nextLevelUI; // UI object for the next level screen
    public GameObject previousLevelUI; // UI object for the previous level screen
    public Button level2Button; // Button to unlock level 2
    public Button level3Button; // Button to unlock level 3
    public int enemiesToKillLevel1 = 10;

    public  int enemiesToKillLevel2 = 15; // Number of enemies to kill in Level 2
    public  int enemiesToKillLevel3 = 5; // Number of enemies to kill in Level 3
    public GameObject winTextObject; // UI object for the win message
    public GameObject mainMenuUI; // UI object for the main menu
    public Button pauseButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Create a singleton instance
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager instances
        }
        Time.timeScale = 1f; // Set the time scale to 1 (normal speed)
    }

    public void IncrementEnemyCount()
    {
        if (!isGameOver)
        {
            enemyCount++; // Increment the enemy count
            UpdateCountText(); // Update the displayed enemy count

            if (enemyCount >= enemiesToKillLevel1 && SceneManager.GetActiveScene().name == "Level 1")
            {
                LevelCompleted(2); // Unlock Level 2 when Level 1 is completed
                level2Button.interactable = true; // Enable the Level 2 button
                GameOver(); // Trigger game over
                //previousLevelUI.SetActive(true); // Show the previous level UI
            }
            else if (enemyCount >= enemiesToKillLevel2 && SceneManager.GetActiveScene().name == "Level 2")
            {
                LevelCompleted(3); // Unlock Level 3 when Level 2 is completed
                level3Button.interactable = true; // Enable the Level 3 button
                GameOver(); // Trigger game over
                previousLevelUI.SetActive(true); // Show the previous level UI
            }
            else if (enemyCount >= enemiesToKillLevel3 && SceneManager.GetActiveScene().name == "Level 3")
            {
                GameOver(); // Trigger game over
                gameOverUI.SetActive(false); // Hide game over UI
                nextLevelUI.SetActive(false); // Hide next level UI
                mainMenuUI.SetActive(true); // Show the main menu UI
            }
        }
    }

    public int GetEnemyCount()
    {
        return enemyCount; // Return the current enemy count
    }

    void UpdateCountText()
    {
        countText.text = "Enemy Killed: " + enemyCount.ToString(); // Update the displayed enemy count text
    }

    public void GameOver()
    {
        nextLevelUI.SetActive(true); // Show next level UI
        gameOverUI.SetActive(true); // Show game over UI
        isGameOver = true; // Set the game over flag to true
        gameOverText.SetActive(true); // Show game over text
        Time.timeScale = 0f; // Pause the game (set time scale to 0)
        // Disable the "Pause" button when the game is over
        if (pauseButton != null)
        {
            pauseButton.interactable = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current level
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu"); // Load the main menu scene
    }

    public void LoadNextLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneBuildIndex = currentSceneBuildIndex + 1;

        if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneBuildIndex); // Load the next level
        }
        else
        {
            Debug.Log("No more levels available."); // Log a message if no more levels are available
        }
    }

    public void PreviousLevel1()
    {
        SceneManager.LoadScene("Level 1"); // Load Level 1
    }

    public void PreviousLevel2()
    {
        SceneManager.LoadScene("Level 2"); // Load Level 2
    }

    public void LevelCompleted(int levelToUnlock)
    {
        unlockedLevels = levelToUnlock; // Update the unlocked levels
        PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels); // Save unlocked levels in PlayerPrefs
        PlayerPrefs.Save(); // Save PlayerPrefs data
    }
}
