using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPoints : MonoBehaviour
{
    private int points;

    void Awake()
    {
        points = 0;
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public int getPoints()
    {
        return points;
    }
}
