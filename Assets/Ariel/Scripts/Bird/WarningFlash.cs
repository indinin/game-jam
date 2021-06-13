using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningFlash : MonoBehaviour
{
    public GameObject birdObject;
    public int maxFlashes = 3;
    public float flashInterval = 0.5f;

    [HideInInspector]
    public bool isDone;

    private int numFlashes;
    [SerializeField]
    private float countdown;
    private bool isVisible = true;

    // Start is called before the first frame update
    void Start()
    {
        countdown = flashInterval;
        GetComponent<BirdSounds>().playWarningSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (numFlashes == maxFlashes)
        {
            isDone = true;
        }

        if (!isDone)
        {
            countdown -= Time.deltaTime;

            if (countdown < 0 )
            {
                if (isVisible)
                {
                    GetComponent<Renderer>().enabled = false;
                    isVisible = false;
                }

                else if (!isVisible)
                {
                    GetComponent<Renderer>().enabled = true;
                    isVisible = true;
                    numFlashes++;
                }

                countdown = flashInterval;
            }
        }

        else
        {
            Debug.Log("Warning: Time to spawn a bird");
            GameObject bird = Instantiate(birdObject, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
