using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool boolFullscreen = true;
    public GameObject fullscreenTick;
    public GameObject windowedTick;
    public GameObject controlsMenuUI;

    /*
    public void Start()
    {
        Debug.Log("yes");
        for (int lvl = 1; lvl < 8; lvl++)
        {
            for (int i = 1; i < 4; i++)
            {
                if (!PlayerPrefs.HasKey("r" + lvl + "." + i))
                {
                    Debug.Log("r" + lvl + "." + i);
                    PlayerPrefs.SetInt("r" + lvl + "." + i, 0);
                }
            }
        }
    }
    */

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Select level
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene(7);
    }
    // End select level

    public void FullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        boolFullscreen = true;
    }

    public void Windowed()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        boolFullscreen = false;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        PlayerPrefs.Save();
        Application.Quit();
    }
}
