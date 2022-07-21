using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelScreen : MonoBehaviour
{
    public static NextLevelScreen endlevel;

    public GameObject nextLevelScreenUI;
    public GameObject hudContainerUI;
    public Text levelText;
    private string levelString;
    public Text bestTime;
    public GameObject newBest;
    public GameObject wrText;
    public GameObject goldText;
    public GameObject silverText;
    public GameObject bronzeText;
    private float[] worldRecords = { 7.82f, 7.97f, 9.88f, 16.68f, 12.62f, 17.43f, 12.90f };
    private float[,] lvlBands = {
        { 8.2f, 9.5f, 15f },   // lvl1
        { 8.1f, 11f, 17f },     // lvl2
        { 13f, 17.5f, 21f },    // lvl3
        { 17.2f, 20f, 25f },    // lvl4
        { 13.2f, 16f, 24f },    // lvl5
        { 18.5f, 22f, 28f },    // lvl6
        { 14f, 19.5f, 27f }     // lvl7
    };

    private void Awake()
    {
        endlevel = this;
    }

    private void Start()
    {
        newBest.SetActive(false);
        levelString = SceneManager.GetActiveScene().buildIndex.ToString();
        levelText.text = "Level " + levelString;
        bestTime.text = "Personal Best: " + PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1").ToString("F2");
        if (PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1") == 0)
            bestTime.text = "Personal Best: N/A";
    }

    public void newBestTime()
    {
        //Debug.Log("Latest time (nls): " + PlayerPrefs.GetFloat("LatestTime"));
        //Debug.Log("Best time: " + PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1"));

        if (PlayerPrefs.GetFloat("LatestTime") == PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1"))
            newBest.SetActive(true);
        else
            newBest.SetActive(false);

        int lvl = SceneManager.GetActiveScene().buildIndex - 1;
        wrText.SetActive(false);
        goldText.SetActive(false);
        silverText.SetActive(false);
        bronzeText.SetActive(false);

        // Displaying correct time rank
        if (PlayerPrefs.GetFloat("LatestTime") < worldRecords[lvl])
            wrText.SetActive(true);
        else if (PlayerPrefs.GetFloat("LatestTime") >= worldRecords[lvl] && PlayerPrefs.GetFloat("LatestTime") < lvlBands[lvl, 0])
            goldText.SetActive(true);
        else if (PlayerPrefs.GetFloat("LatestTime") >= lvlBands[lvl, 0] && PlayerPrefs.GetFloat("LatestTime") < lvlBands[lvl, 1])
            silverText.SetActive(true);
        else if (PlayerPrefs.GetFloat("LatestTime") >= lvlBands[lvl, 1] && PlayerPrefs.GetFloat("LatestTime") < lvlBands[lvl, 2])
            bronzeText.SetActive(true);
    }
    public void RetryLevel()
    {
        Debug.Log("RETRY!");
        PlayerPrefs.SetInt("EndScreen", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        nextLevelScreenUI.SetActive(false);
        hudContainerUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        Debug.Log("NEXTLEVEL!");
        PlayerPrefs.SetInt("EndScreen", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        nextLevelScreenUI.SetActive(false);
        hudContainerUI.SetActive(true);
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("MENU!");
        PlayerPrefs.SetInt("EndScreen", 0);
        SceneManager.LoadScene(0);
    }
}