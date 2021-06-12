using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("webNode").Length == 1)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
