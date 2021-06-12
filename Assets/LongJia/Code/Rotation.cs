using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (transform.position.x >= 12f)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (transform.position.x <= -12f)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }

        if (transform.position.y >= 5.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (transform.position.y <= -5.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

      
    }
}
