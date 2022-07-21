using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool boolGamePaused = false;
    public GameObject pauseMenuUI;

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (boolGamePaused)
                Resume();
            else
                Pause();
    }
    */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        boolGamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /*
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        boolGamePaused = true;
    }
    */
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("MENU!");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}


