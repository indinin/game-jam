using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private int TitleSceneNumber;
    [SerializeField]
    private AudioClip hoverSfx, clickSfx, gameOverSfx;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
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

