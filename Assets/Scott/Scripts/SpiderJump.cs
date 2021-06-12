using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJump : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private int power;
    [SerializeField]
    private bool isLessThanX, isLessThanXOld, isLessThanY, isLessThanYOld;
    [SerializeField]
    private Vector2 worldPoint, spiderPoint;

    void Awake()
    {
        if(this.gameObject.GetComponent<Rigidbody2D>())
        {
            rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        }
        isLessThanX = false;
        isLessThanXOld = isLessThanX;
        isLessThanY = false;
        isLessThanYOld = isLessThanY;
    }

    void Update()
    {
        spiderPoint = new Vector2(this.transform.position.x, this.transform.position.y);
        if(spiderPoint.x < worldPoint.x)
        {
            isLessThanX = true;
        }
        else
        {
            isLessThanX = false;
        }
        if(spiderPoint.y == worldPoint.y)
        {
            isLessThanY = true;
        }
        else
        {
            isLessThanY = false;
        }

        if(Input.GetKeyDown("space"))
        {
            Debug.Log("Space Key Pressed");
            worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            rigidbody.gravityScale = 5;
            rigidbody.AddForce((worldPoint - spiderPoint) * power);
            Debug.Log("Jump Power Activated");
            if(spiderPoint.x < worldPoint.x)
            {
                isLessThanX = true;
                isLessThanXOld = isLessThanX;
            }
            else
            {
                isLessThanX = false;
                isLessThanXOld = isLessThanX;
            }
            if(spiderPoint.y == worldPoint.y)
            {
                isLessThanY = true;
                isLessThanYOld = isLessThanY;
            }
            else
            {
                isLessThanY = false;
                isLessThanYOld = isLessThanY;
            }
        }
        if((isLessThanX != isLessThanXOld || isLessThanY != isLessThanYOld) || (rigidbody.velocity.x == 0 || rigidbody.velocity.y == 0))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.gravityScale = 0;
        }
    }
}
