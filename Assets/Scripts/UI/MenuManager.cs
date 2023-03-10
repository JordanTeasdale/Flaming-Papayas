using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ExitGame()
    {
        //Exit
        Application.Quit();
    }

    public void StartGame()
    {
        //Start Load next level function
        PlayerPrefs.SetInt("CanTalkPref", 0);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
