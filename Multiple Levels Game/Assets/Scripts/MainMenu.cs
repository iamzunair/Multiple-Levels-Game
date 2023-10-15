using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void PlayNow()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene("Choose Level");
    }

    public void ChoosePlayer()
    {
        SceneManager.LoadScene("Choose Player");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // void UnlockNewLevel()
    // {
    //     if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
    //     {
    //         PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
    //         PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
    //         PlayerPrefs.Save();

    //     }
    }


