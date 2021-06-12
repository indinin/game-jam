using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webMeterScript : MonoBehaviour
{
    public float web, lenience;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(web + lenience < 0 && !gameOver)
        {
            print("Game Over");
            gameOver = true;
        }
    }

    public void changeWebbing(float amount)
    {
        web += amount;
    }
}
