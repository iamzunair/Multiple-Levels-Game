using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public Button level1Button; // Assign this in the Inspector
    public Button level2Button;
    public Button level3Button;

    private void Start()
    {
        // Initially, only level 1 is accessible.
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);

        // Enable the buttons based on the unlocked levels
        level1Button.interactable = unlockedLevels >= 1;
        level2Button.interactable = unlockedLevels >= 2;
        level3Button.interactable = unlockedLevels >= 3;
    }

    // Method to load a specific level (Level 1, 2, or 3)
    public void LoadLevel(int levelIndex)
    {
        int maxLevelIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (levelIndex >= 1 && levelIndex <= maxLevelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.Log("Invalid level index.");
        }
    }
        public void UnlockNextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            level2Button.interactable = true; // Unlock Level 2
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            level3Button.interactable = true; // Unlock Level 3
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadLevel1()
    {
    SceneManager.LoadScene("Level 1"); // Assuming Level 1 is the first scene in build settings
    }
    public void LoadLevel2()
    {
    SceneManager.LoadScene("Level 2");
    }
    public void LoadLevel3()
    {
    SceneManager.LoadScene("Level 3");
    }
}
