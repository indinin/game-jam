using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private int TitleSceneNumber;

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
}

