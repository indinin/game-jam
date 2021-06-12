using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject ControlsMenu;
    [SerializeField]
    private GameObject CreditsMenu;
    [SerializeField]
    private int LevelNumber;
    [SerializeField]
    private AudioClip hoverSfx, clickSfx;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        this.GoToMainMenu();
    }

    public void GoToMainMenu()
    {
        if(!MainMenu.activeSelf)
        {
            MainMenu.SetActive(true);
        }
        if(ControlsMenu.activeSelf)
        {
            ControlsMenu.SetActive(false);
        }
        if(CreditsMenu.activeSelf)
        {
            CreditsMenu.SetActive(false);
        }
        Debug.Log("Go To Main Menu");
    }

    public void GoToControlsMenu()
    {
        if(MainMenu.activeSelf)
        {
            MainMenu.SetActive(false);
        }
        if(!ControlsMenu.activeSelf)
        {
            ControlsMenu.SetActive(true);
        }
        if(CreditsMenu.activeSelf)
        {
            CreditsMenu.SetActive(false);
        }
        Debug.Log("Load Controls");
    }

    public void GoToCreditsMenu()
    {
        if(MainMenu.activeSelf)
        {
            MainMenu.SetActive(false);
        }
        if(ControlsMenu.activeSelf)
        {
            ControlsMenu.SetActive(false);
        }
        if(!CreditsMenu.activeSelf)
        {
            CreditsMenu.SetActive(true);
        }
        Debug.Log("Load Credits");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(LevelNumber);
        Debug.Log("Start Game");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit The Game");
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
}
