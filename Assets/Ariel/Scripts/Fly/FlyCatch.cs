using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCatch : MonoBehaviour
{
    private GameObject spider;

    private bool caught;

    private float randSpeed;
    private float speed;
    public float webAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        randSpeed = GetComponent<FlyMovement>().randSpeed;
        speed     = GetComponent<FlyMovement>().speed;
        spider = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (caught && GetComponent<FlyMovement>().isActiveAndEnabled)
        {
            GetComponent<FlyMovement>().randSpeed -= randSpeed * Time.deltaTime/2;
            GetComponent<FlyMovement>().speed     -= speed     * Time.deltaTime/2;

            if (GetComponent<FlyMovement>().randSpeed <= 0 &&
                GetComponent<FlyMovement>().speed     <= 0)
            {
                GetComponent<FlyMovement>().randSpeed = 0;
                GetComponent<FlyMovement>().speed     = 0;
                GetComponent<FlyMovement>().enabled   = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.gameObject.Equals(spider) && caught)
        {
            Debug.Log("Fly: Oof!");
            collision.otherCollider.gameObject.GetComponent<webMeterScript>().changeWebbing(webAmount);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Web"))
        {
            caught = true;
            Debug.Log("Fly: Zoo Wee Mama!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (caught && collision.gameObject.CompareTag("Web"))
        {
            caught = false;
            this.GetComponent<FlyMovement>().lifeTime = 0;
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Fly: Oof!");
        Destroy(this.gameObject);
    }
}
