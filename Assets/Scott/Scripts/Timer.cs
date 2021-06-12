using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int time = 0;
    private bool isGameOver = false;

    void Update()
    {
        if(!isGameOver)
        {
            time += (int)(Time.deltaTime);
        }
    }

    public int getTime()
    {
        return time;
    }

    public void setIsGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }
}
