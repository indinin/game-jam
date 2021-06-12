using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(gameOverCanvas.activeSelf)
            {
                gameOverCanvas.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                gameOverCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
