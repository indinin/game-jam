using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPoints : MonoBehaviour
{
    private int points;
    private int personalBest;

    void Awake()
    {
        points = 0;
        loadPoints();
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public int getPoints()
    {
        return points;
    }

    public int getPersonalBest()
    {
        return personalBest;
    }

    public void setPersonalBest()
    {
        if(points > personalBest)
        {
            personalBest = points;
        }
    }

    public void savePoints()
    {
        PlayerPrefs.SetInt("PersonalBest", personalBest);
        PlayerPrefs.Save();
        Debug.Log("Score Is Saved");
    }

    public void loadPoints()
    {
        if(PlayerPrefs.HasKey("PersonalBest"))
        {
            personalBest = PlayerPrefs.GetInt("PersonalBest");
            Debug.Log("Data is Loaded");
        }
        else
        {
            personalBest = 0;
            Debug.Log("No Save Data");
        }
    }
}
