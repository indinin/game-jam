using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;
    private SpiderAnimations spiderAnimations;
    private SpiderSounds spiderSounds;
    private bool isGameOver;

    void Awake()
    {
        isGameOver = false;
        if(this.gameObject.GetComponent<SpiderAnimations>())
        {
            spiderAnimations = this.gameObject.GetComponent<SpiderAnimations>();
        }
        if(this.gameObject.GetComponent<SpiderSounds>())
        {
            spiderSounds = this.gameObject.GetComponent<SpiderSounds>();
        }
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
        spiderAnimations.DeathAnim();
        spiderSounds.playFallSound();
        Invoke("goToGameOverScreen", 1f);
    }

    public void goToGameOverScreen()
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

    public void setIsGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
        if(isGameOver)
        {
            Time.timeScale = 1;
        }
    }
}
