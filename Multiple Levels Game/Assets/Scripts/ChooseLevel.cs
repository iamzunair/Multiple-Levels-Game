using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChooseLevel : MonoBehaviour
{

    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i=0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level " +levelId;
        SceneManager.LoadScene(levelName);


    // public void Level1()
    // {
    //     SceneManager.LoadScene("Level 1");
    // }

    // public void Level2()
    // {
    //     SceneManager.LoadScene("Level 2");
    // }
    // public void Level3()
    // {
    //     SceneManager.LoadScene("Level 3");
    // }
    // public void Level4()
    // {
    //     SceneManager.LoadScene("Level 4");
    // }
    // public void Level5()
    // {
    //     SceneManager.LoadScene("Level 5");
    // }
    // public void Level6()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level7()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level8()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level9()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level10()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level11()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level12()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level13()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level14()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }
    // public void Level15()
    // {
    //     SceneManager.LoadScene("Choose Level");
    // }




}
}
