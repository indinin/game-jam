using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float time = 0;
    [SerializeField]
    private int showTime = 0;
    private bool isGameOver = false;

    void Update()
    {
        if(!isGameOver)
        {
            time += Time.deltaTime;
            showTime = (int)(time);
            Debug.Log("Updating Time - " + Time.deltaTime);
        }
    }

    public int getTime()
    {
        return showTime;
    }

    public void setIsGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }
}
