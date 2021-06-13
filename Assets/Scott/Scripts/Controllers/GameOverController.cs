using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private int TitleSceneNumber;
    [SerializeField]
    private AudioClip hoverSfx, clickSfx, gameOverSfx;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private TextMeshProUGUI timeText, pointsText, bestText;
    private int timer, points, best;
    private GameObject spider;
    private SpiderPoints spiderPoints;
    [SerializeField]
    private Timer timerObj;

    void Awake()
    {
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
        spider = GameObject.FindGameObjectWithTag("Player");
        if(spider.GetComponent<SpiderPoints>())
        {
            spiderPoints = spider.GetComponent<SpiderPoints>();
        }
        timerObj.setIsGameOver(true);

        spiderPoints.setPersonalBest();
        spiderPoints.savePoints();
    }

    void Update()
    {
        points = spiderPoints.getPoints();
        timer = timerObj.getTime();
        best = spiderPoints.getPersonalBest();
        timeText.text = "Time: " + timer;
        pointsText.text = "Points: " + points;
        bestText.text = "Personal Best: " + best;
    }

    void OnEnable()
    {
        playGameOverSound();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit The Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(TitleSceneNumber);
        Debug.Log("Game Over Go To Menu");
    }

    public void playHoverSound()
    {
        audioSource.Stop();
        audioSource.clip = hoverSfx;
        audioSource.Play();
    }

    public void playClickSound()
    {
        audioSource.Stop();
        audioSource.clip = clickSfx;
        audioSource.Play();
    }

    public void playGameOverSound()
    {
        audioSource.Stop();
        audioSource.clip = gameOverSfx;
        audioSource.Play();
    }
}

