using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetHurt : MonoBehaviour
{
    private GameObject spider;
    public float webAmount = -2f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spider = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(spider))
        {
            Debug.Log("Hornet: Get Shrekt!");
            animator.SetBool("HittingPlayer", true);

            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<HornetSounds>().playStingSound();
            }

            /* Do Something to Spider */
            collision.gameObject.GetComponent<meshManager>().meter.GetComponent<webMeterScript>().changeWebbing(webAmount);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(spider))
        {
            animator.SetBool("HittingPlayer", false);
        }
    }
}
