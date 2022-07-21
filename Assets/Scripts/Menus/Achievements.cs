using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    private float[,] lvlBands = {
        { 8.2f, 9.5f, 15f },     // lvl1
        { 8.1f, 11f, 17f },     // lvl2
        { 13f, 17.5f, 21f },    // lvl3
        { 17.2f, 20f, 25f },    // lvl4
        { 13.2f, 16f, 24f },    // lvl5
        { 18.5f, 22f, 28f },  // lvl6
        { 14f, 19.5f, 27f }   // lvl7
    };
    private float[] levelsCheck = { 0, 0, 0, 0, 0, 0, 0};
    public GameObject allLevels;
    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;

    void Start()
    {
        //AllLevels
        for (int lvl = 1; lvl < 8; lvl++)
        {
            if (PlayerPrefs.GetFloat("r" + lvl + ".1", 0) > 0)
                levelsCheck[lvl-1] = 1;
            else
                levelsCheck[lvl - 1] = 0;
        }
        if (levelsCheck[0] == 1 && levelsCheck[1] == 1 && levelsCheck[2] == 1 && levelsCheck[3] == 1 && levelsCheck[4] == 1 && levelsCheck[5] == 1 && levelsCheck[6] == 1)
        {
            PlayerPrefs.SetInt("AllLevels", 1);
            allLevels.SetActive(false);
        }

        //Bronze
        for (int lvl = 1; lvl < 8; lvl++)
        {
            if (PlayerPrefs.GetFloat("r" + lvl + ".1", 0) < lvlBands[lvl - 1, 2])
                levelsCheck[lvl - 1] = 1;
            else
                levelsCheck[lvl - 1] = 0;
        }
        if (levelsCheck[0] == 1 && levelsCheck[1] == 1 && levelsCheck[2] == 1 && levelsCheck[3] == 1 && levelsCheck[4] == 1 && levelsCheck[5] == 1 && levelsCheck[6] == 1)
        {
            PlayerPrefs.SetInt("Bronze", 1);
            bronze.SetActive(false);
        }

        //Silver
        for (int lvl = 1; lvl < 8; lvl++)
        {
            if (PlayerPrefs.GetFloat("r" + lvl + ".1", 0) < lvlBands[lvl - 1, 1])
                levelsCheck[lvl - 1] = 1;
            else
                levelsCheck[lvl - 1] = 0;
        }
        if (levelsCheck[0] == 1 && levelsCheck[1] == 1 && levelsCheck[2] == 1 && levelsCheck[3] == 1 && levelsCheck[4] == 1 && levelsCheck[5] == 1 && levelsCheck[6] == 1)
        {
            PlayerPrefs.SetInt("Silver", 1);
            silver.SetActive(false);
        }

        //Gold
        for (int lvl = 1; lvl < 8; lvl++)
        {
            if (PlayerPrefs.GetFloat("r" + lvl + ".1", 0) < lvlBands[lvl - 1, 0])
                levelsCheck[lvl - 1] = 1;
            else
                levelsCheck[lvl - 1] = 0;
        }
        if (levelsCheck[0] == 1 && levelsCheck[1] == 1 && levelsCheck[2] == 1 && levelsCheck[3] == 1 && levelsCheck[4] == 1 && levelsCheck[5] == 1 && levelsCheck[6] == 1)
        {
            PlayerPrefs.SetInt("Gold", 1);
            gold.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
