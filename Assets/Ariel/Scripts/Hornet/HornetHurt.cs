using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetHurt : MonoBehaviour
{
    public GameObject spider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.gameObject.Equals(spider))
        {
            Debug.Log("Hornet: Get Shrekt!");
            /* Do Something to Spider */
        }
    }
}
