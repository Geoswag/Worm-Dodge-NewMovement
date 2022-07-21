using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelonTouch : MonoBehaviour
{
    public GameObject nextLevelScreenUI;
    public GameObject hudContainerUI;
    public Text endTime;
    public float endTimeFloat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("EndScreen", 1);
            nextLevelScreenUI.SetActive(true);
            TimerController.instance.GetEndTime();
            string endTimeText = endTime.text;

            // Updating records
            if (PlayerPrefs.GetFloat("LatestTime") < PlayerPrefs.GetFloat("r"+SceneManager.GetActiveScene().buildIndex+".1") || PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1") == 0)
            {
                PlayerPrefs.SetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".3", PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".2"));
                PlayerPrefs.SetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".2", PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1"));
                PlayerPrefs.SetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1", PlayerPrefs.GetFloat("LatestTime"));
            }
            else if (PlayerPrefs.GetFloat("LatestTime") < PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".2") || PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".2") == 0)
            {
                PlayerPrefs.SetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".3", PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".2"));
                PlayerPrefs.SetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".2", PlayerPrefs.GetFloat("LatestTime"));
            }
            else if (PlayerPrefs.GetFloat("LatestTime") < PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".3") || PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".3") == 0)
            {
                PlayerPrefs.SetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".3", PlayerPrefs.GetFloat("LatestTime"));
            }

            //Debug.Log("1st: " + PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".1"));
            //Debug.Log("2nd: " + PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".2"));
            //Debug.Log("3rd: " + PlayerPrefs.GetFloat("r" + SceneManager.GetActiveScene().buildIndex + ".3"));

            // Finished updating records

            Debug.Log("Latest time (nlot): " + PlayerPrefs.GetFloat("LatestTime"));

            hudContainerUI.SetActive(false);
            Time.timeScale = 0f;
            NextLevelScreen.endlevel.newBestTime();
        }
        else return;
    }
}
