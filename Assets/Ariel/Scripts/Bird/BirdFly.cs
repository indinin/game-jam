using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float startSizeNum = 1f;
    private Vector3 startSize;
    private Vector3 currentSize;
    public float endSizeNum = 10f;
    private Vector3 endSize;

    public float time = 2f;
    private float addProg;
    private float progress;


    // Start is called before the first frame update
    void Start()
    {
        startSize = new Vector3(startSizeNum, startSizeNum, startSizeNum);
        currentSize = this.transform.localScale;
        endSize = new Vector3(endSizeNum, endSizeNum, endSizeNum);
        
        addProg = (endSizeNum - startSizeNum)/time;

        this.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (progress < 1)
        {
            progress += addProg * Time.deltaTime;

            this.transform.localScale = Vector3.Lerp(startSize, endSize, progress);
        }

        else if (progress > 1)
        {
            this.transform.localScale = endSize;
            Debug.Log("Bird: I'm out of here!");
            Destroy(this.gameObject);
        }

        if (Mathf.Abs(currentSize.x - this.transform.localScale.x) < 0.5f)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }

        else
        {
            this.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Web") ||
            collision.gameObject.CompareTag("Fly") ||
            collision.gameObject.CompareTag("Hornet"))
        {
            Debug.Log("Bird: Killed stuff!");
            Destroy(collision.gameObject);
        }
    }
}
