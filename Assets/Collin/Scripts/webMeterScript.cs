using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webMeterScript : MonoBehaviour
{
    public float web, lenience;
    float max;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        max = web;
        GetComponent<webUI>().setMax(web);
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
        if (web >= 0)
        {
            GetComponent<webUI>().changeValue(web);
        }
        else if (web + lenience >= 0)
        {
            GetComponent<webUI>().changeValue(max * .0667f);
        }
        else
        {
            GetComponent<webUI>().changeValue(0);
        }
    }
}
