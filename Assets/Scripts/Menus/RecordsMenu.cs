using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordsMenu : MonoBehaviour
{
    private float[] worldRecords = { 7.82f, 7.97f, 9.88f, 16.68f, 12.62f, 17.43f, 12.90f };
    private float[,] lvlBands = { 
        { 8.2f, 9.5f, 15f },     // lvl1
        { 8.1f, 11f, 17f },     // lvl2
        { 13f, 17.5f, 21f },    // lvl3
        { 17.2f, 20f, 25f },    // lvl4
        { 13.2f, 16f, 24f },    // lvl5
        { 18.5f, 22f, 28f },  // lvl6
        { 14f, 19.5f, 27f }   // lvl7
    };
    public GameObject recordsList;
    public TextMeshProUGUI time1;
    public TextMeshProUGUI rating1;
    public TextMeshProUGUI time2;
    public TextMeshProUGUI rating2;
    public TextMeshProUGUI time3;
    public TextMeshProUGUI rating3;
    public Text worldRecord;
    public TMP_Dropdown levelSelect;

    private void Awake()
    {
        recordsList.SetActive(true);
        // Display level 1 records when menu is first opened
        string[] ratings = { "Gold", "Gold", "Gold" };

        worldRecord.text = worldRecords[0].ToString();

        time1.text = PlayerPrefs.GetFloat("r1.1", 0).ToString("F2");
        time2.text = PlayerPrefs.GetFloat("r1.2", 0).ToString("F2");
        time3.text = PlayerPrefs.GetFloat("r1.3", 0).ToString("F2");

        //temp
        //time1.text = "0";
        //time2.text = "0";
        //time3.text = "0";
        //temp

        rating1.color = new Color(253f / 255f, 162f / 255f, 56f / 255f, 1f);
        rating2.color = new Color(253f / 255f, 162f / 255f, 56f / 255f, 1f);
        rating3.color = new Color(253f / 255f, 162f / 255f, 56f / 255f, 1f);

        for (int i = 1; i < 4; i++)
        {
            if (PlayerPrefs.GetFloat("r1." + i, 0) == 0)
            {
                if (i == 1)
                    rating1.color = new Color(1f, 0f, 0f, 1f);
                else if (i == 2)
                    rating2.color = new Color(1f, 0f, 0f, 1f);
                else if (i == 3)
                    rating3.color = new Color(1f, 0f, 0f, 1f);
                ratings[i - 1] = "N/A";
            }
            else if (PlayerPrefs.GetFloat("r1." + i, 0) >= lvlBands[0,0] && PlayerPrefs.GetFloat("r1." + i, 0) < lvlBands[0, 1])
            {
                if (i == 1)
                    rating1.color = new Color(229f / 255f, 228f / 255f, 226f / 255f, 1f);
                else if (i == 2)
                    rating2.color = new Color(229f / 255f, 228f / 255f, 226f / 255f, 1f);
                else if (i == 3)
                    rating3.color = new Color(229f / 255f, 228f / 255f, 226f / 255f, 1f);
                ratings[i - 1] = "Silver";
            }
            else if (PlayerPrefs.GetFloat("r1." + i, 0) >= lvlBands[0, 1] && PlayerPrefs.GetFloat("r1." + i, 0) < lvlBands[0, 2])
            {
                if (i == 1)
                    rating1.color = new Color(80f / 255f, 50f / 255f, 20f / 255f, 1f);
                else if (i == 2)
                    rating2.color = new Color(80f / 255f, 50f / 255f, 20f / 255f, 1f);
                else if (i == 3)
                    rating3.color = new Color(80f / 255f, 50f / 255f, 20f / 255f, 1f);
                ratings[i - 1] = "Bronze";
            }
            else if (PlayerPrefs.GetFloat("r1." + i, 0) >= lvlBands[0, 2])
            {
                if (i == 1)
                    rating1.color = new Color(107f / 255f, 142f / 255f, 35f / 255f, 1f);
                else if (i == 2)
                    rating2.color = new Color(107f / 255f, 142f / 255f, 35f / 255f, 1f);
                else if (i == 3)
                    rating3.color = new Color(107f / 255f, 142f / 255f, 35f / 255f, 1f);
                ratings[i - 1] = "Trash";
            }
        }
        rating1.text = ratings[0];
        rating2.text = ratings[1];
        rating3.text = ratings[2];
    }

    // Update records for level chosen in dropdown menu
    public void LevelSelector()
    {
        string[] ratings = { "Gold", "Gold", "Gold" };

        int lvl = levelSelect.value + 1;

        worldRecord.text = worldRecords[levelSelect.value].ToString();

        time1.text = PlayerPrefs.GetFloat("r"+lvl+".1", 0).ToString("F2");
        time2.text = PlayerPrefs.GetFloat("r"+lvl+".2", 0).ToString("F2");
        time3.text = PlayerPrefs.GetFloat("r"+lvl+".3", 0).ToString("F2");

        rating1.color = new Color(253f / 255f, 162f / 255f, 56f / 255f, 1f);
        rating2.color = new Color(253f / 255f, 162f / 255f, 56f / 255f, 1f);
        rating3.color = new Color(253f / 255f, 162f / 255f, 56f / 255f, 1f);
        for (int i = 1; i < 4; i++)
        {
            if (PlayerPrefs.GetFloat("r" + lvl + "." + i, 0) == 0)
            {
                if (i == 1)
                    rating1.color = new Color(1f, 0f, 0f, 1f);
                else if (i == 2)
                    rating2.color = new Color(1f, 0f, 0f, 1f);
                else if (i == 3)
                    rating3.color = new Color(1f, 0f, 0f, 1f);
                ratings[i - 1] = "N/A";
                Debug.Log("Did this for i= " + i);
            }
            else if (PlayerPrefs.GetFloat("r" + lvl + "." + i, 0) >= lvlBands[lvl-1, 0] && PlayerPrefs.GetFloat("r" + lvl + "." + i, 0) < lvlBands[lvl-1, 1])
            {
                if (i == 1)
                    rating1.color = new Color(229f / 255f, 228f / 255f, 226f / 255f, 1f);
                else if (i == 2)
                    rating2.color = new Color(229f / 255f, 228f / 255f, 226f / 255f, 1f);
                else if (i == 3)
                    rating3.color = new Color(229f / 255f, 228f / 255f, 226f / 255f, 1f);
                ratings[i - 1] = "Silver";
            }
            else if (PlayerPrefs.GetFloat("r" + lvl + "." + i, 0) >= lvlBands[lvl-1, 1] && PlayerPrefs.GetFloat("r" + lvl + "." + i, 0) < lvlBands[lvl-1, 2])
            {
                if (i == 1)
                    rating1.color = new Color(80f / 255f, 50f / 255f, 20f / 255f, 1f);
                else if (i == 2)
                    rating2.color = new Color(80f / 255f, 50f / 255f, 20f / 255f, 1f);
                else if (i == 3)
                    rating3.color = new Color(80f / 255f, 50f / 255f, 20f / 255f, 1f);
                ratings[i - 1] = "Bronze";
            }
            else if (PlayerPrefs.GetFloat("r" + lvl + "." + i, 0) >= lvlBands[lvl-1, 2])
            {
                if (i == 1)
                    rating1.color = new Color(107f / 255f, 142f / 255f, 35f / 255f, 1f);
                else if (i == 2)
                    rating2.color = new Color(107f / 255f, 142f / 255f, 35f / 255f, 1f);
                else if (i == 3)
                    rating3.color = new Color(107f / 255f, 142f / 255f, 35f / 255f, 1f);
                ratings[i - 1] = "Trash";
            }
        }
        rating1.text = ratings[0];
        rating2.text = ratings[1];
        rating3.text = ratings[2];
        //Debug.Log(lvlBands[lvl - 1,0]);
        //Debug.Log(lvlBands[lvl - 1, 1]);
        //Debug.Log(lvlBands[lvl - 1, 2]);
    }
}

