using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;
    private bool isGameOver;

    void Awake()
    {
        isGameOver = false;
    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        if(gameOverCanvas.activeSelf)
        {
            gameOverCanvas.SetActive(false);
            Time.timeScale = 1;
            isGameOver = false;
        }
        else
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
            isGameOver = true;
        }
    }

    public bool getIsGameOver()
    {
        return isGameOver;
    }
}
