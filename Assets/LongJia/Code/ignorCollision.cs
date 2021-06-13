﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignorCollision : MonoBehaviour
{
    public bool inWeb;

    public GameObject g1;
    public GameObject g2;

    public float objWidth;
    public float objHeight;

    // Start is called before the first frame update
    void Start()
    {
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inWeb == true)
        {
            Physics2D.IgnoreCollision(g1.GetComponent<Collider2D>(), g2.GetComponent<Collider2D>());
        }
        if (inWeb == false)
        {
            Physics2D.IgnoreCollision(g1.GetComponent<Collider2D>(), g2.GetComponent<Collider2D>(),false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            print("enetered");
            inWeb = false;

        }
        if (col.gameObject.tag == "Web")
        {
            print("enetered");
            inWeb = true;
        }

        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (transform.position.y <= -5.44 && transform.position.y >= -5.96)
        {
            inWeb = false;
        }
        if (transform.position.y >= 5.44 && transform.position.y <= 5.96)
        {
            inWeb = false;
        }

        if (transform.position.x <= -12.296 && transform.position.x >= -12.888)
        {
            inWeb = false;
        }
        if (transform.position.x >= 12.296 && transform.position.x <= 12.888)
        {
            inWeb = false;
        }
        else
        {
            inWeb = true;
        }
    }



        void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Web")
        {
            print("Exit");
            
                if (transform.position.y <= -5.44 && transform.position.y >= -5.96)
                {
                    inWeb = false;
                }
                if (transform.position.y >= 5.44 && transform.position.y <= 5.96)
                {
                    inWeb = false;
                }

                if (transform.position.x <= -12.296 && transform.position.x >= -12.888)
                {
                    inWeb = false;
                }
                if (transform.position.x >= 12.296 && transform.position.x <= 12.888)
                {
                    inWeb = false;
                }
            

        }
    }


}
