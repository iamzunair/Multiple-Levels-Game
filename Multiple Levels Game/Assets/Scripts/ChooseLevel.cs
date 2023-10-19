using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    //Declare public variables for buttons
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button refreshButton;
    
    //Initialize the number of unlocked levels
    private int unlockedLevels = 1; // Initialize with the first level unlocked

    void Start()
    {
        // Load the player's progress from PlayerPrefs
        unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);

        // Enable buttons based on the player's progress
        level1Button.interactable = true;  //Always enable the first level
        level2Button.interactable = false; //Initially disable the second level
        level3Button.interactable = false; //Initiallyy disable the third level

        // Enable buttons based on the player's progress
        for (int i = 2; i <= unlockedLevels; i++)
        {
            if (i == 2)
            {
                level2Button.interactable = true;  //Enable the second level
            }
            else if (i == 3)
            {
                level3Button.interactable = true; //Enable the third level
            }
        }

        // Attach click event handlers to the buttons
        level1Button.onClick.AddListener(() => LoadLevel("Level 1"));
        level2Button.onClick.AddListener(() => LoadLevel("Level 2"));
        level3Button.onClick.AddListener(() => LoadLevel("Level 3"));
        refreshButton.onClick.AddListener(RefreshLevels);
    }

    // Load a level when its button is clicked
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Load the main menu

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }

    // Reset the level selection by locking all levels except the first one
    void RefreshLevels()
    {
        unlockedLevels = 1; //Reset to having only the first level unlocked
        PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels);
        PlayerPrefs.Save();

        level1Button.interactable = true; //Always enable the first level
        level2Button.interactable = false; //Disable the second level
        level3Button.interactable = false; //Disable the third level
    }
}
