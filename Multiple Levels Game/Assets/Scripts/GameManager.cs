using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemyCount = 0;
    public TextMeshProUGUI countText;
    public GameObject gameOverText;
    private bool isGameOver = false;
    public GameObject gameOverUI;
    public GameObject nextLevelUI;
    public GameObject previousLevelUI;
    public Button level2Button;
    public Button level3Button;

    private int enemiesToKillLevel2 = 15; // Number of enemies to kill in Level 2
    private int enemiesToKillLevel3 = 5;
    public GameObject winTextObject;
    public GameObject mainMenuUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
    }

    public void IncrementEnemyCount()
    {
        if (!isGameOver)
        {
            enemyCount++;

            UpdateCountText();

            // Check if the enemy count reaches the level completion condition
            if (enemyCount >= enemiesToKillLevel2 && SceneManager.GetActiveScene().name == "Level 2")
            {
                GameOver();
                UnlockNextLevel(); // Unlock Level 3 when Level 2 is completed
                previousLevelUI.SetActive(true);
            
            }
            else if (enemyCount >= 10 && SceneManager.GetActiveScene().name == "Level 1")
            {
                GameOver();
                UnlockNextLevel(); // Unlock Level 2 when Level 1 is completed
            }
            else if (enemyCount >= enemiesToKillLevel3 && SceneManager.GetActiveScene().name == "Level 3")
            {
                GameOver(); //Level 3 Reached
                gameOverUI.SetActive(false);
                nextLevelUI.SetActive(false);
                mainMenuUI.SetActive(true);
                //previousLevelUI.SetActive(true);
                //winTextObject.SetActive(true);
                //Time.timeScale = 2f;
               // mainMenu() ;
                // PreviousLevel2();

            }
        }
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    void UpdateCountText()
    {
        countText.text = "Enemy Killed: " + enemyCount.ToString();
    }

    public void GameOver()
    {
        nextLevelUI.SetActive(true);
        gameOverUI.SetActive(true);
        isGameOver = true;
        gameOverText.SetActive(true);
        UnlockNextLevel();
        Time.timeScale = 0f;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneBuildIndex = currentSceneBuildIndex + 1;

        if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneBuildIndex);
        }
        else
        {
            Debug.Log("No more levels available.");
        }
    }

    public void UnlockNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex+1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel",1)+1);
            PlayerPrefs.Save();
        }
    }

    public void PreviousLevel1()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void PreviousLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }


}
