using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetHurt : MonoBehaviour
{
    private GameObject spider;
    public float webAmount = -2f;

    // Start is called before the first frame update
    void Start()
    {
        spider = GameObject.FindGameObjectWithTag("Player");
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
            collision.otherCollider.gameObject.GetComponent<webMeterScript>().changeWebbing(webAmount);
        }
    }
}
