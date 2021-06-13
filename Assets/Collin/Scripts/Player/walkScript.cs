using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkScript : MonoBehaviour
{
    public GameObject bg;
    BoxCollider2D bgCollider;
    public float moveSpeed, verticalMovement, horizontalMovement;
    Vector3 movement, lastPos;
    public bool onWeb,onWall,grav;
    public jumpScript jump;
    float posTimer = 0;
    float delTime;
    private SpiderAnimations spiderAnimations;
     
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        onWeb = false;
        onWall = true;
        grav = false;
        bgCollider = bg.GetComponent<BoxCollider2D>();
        if(this.gameObject.GetComponent<SpiderAnimations>())
        {
            spiderAnimations = this.gameObject.GetComponent<SpiderAnimations>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        delTime = Time.deltaTime;


        verticalMovement = 0;
        horizontalMovement = 0;
        if (Input.GetKey(KeyCode.W))
        {
            verticalMovement += 1;
            spiderAnimations.MovingAnim();
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalMovement -= 1;
            spiderAnimations.MovingAnim();
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement -= 1;
            spiderAnimations.MovingAnim();
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement += 1;
            spiderAnimations.MovingAnim();
        }
        if (grav)
        {
            verticalMovement = 0;
        }
        if (jump.jumping)
        {
            verticalMovement = 0;
            horizontalMovement = 0;
        }
        if(verticalMovement == 0 && horizontalMovement == 0)
        {
            spiderAnimations.StopMovingAnim();
        }
        movement = Vector3.Normalize(new Vector3(horizontalMovement, verticalMovement, 0));
        this.gameObject.transform.position += movement*moveSpeed*delTime;
        
        if((onWeb || onWall) && grav)
        {
            grav = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (grav)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 6;
        }


        
         /* if(!onWall && !onWeb)
        {
            if (!grav)
            {
                grav = true;
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        } else if(grav)
        {
            print("gravity off");
            grav = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        */
    }

    void updatePosTime()
    {
        posTimer += Time.deltaTime;
    }

    void updatePos()
    {
        if (onWall || onWeb)
        {
            lastPos = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            onWall = false;
            if (!onWeb && !jump.jumping)
            {
                bgCollider.isTrigger = false;
            }
        }

        if (collision.gameObject.tag == "Web")
        {
            print("Enter web");
            if (jump.jumping && Input.anyKey)
            {

            }
            onWeb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Web")
        {
            print("Exit web");
            onWeb = false;
            if (!onWall)
            {
                if (!jump.jumping)
                {
                    grav = true;
                }
            }
        }
        if (collision.gameObject.tag == "Wall")
        {
            onWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            onWall = true;
            bgCollider.isTrigger = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "border" && jump.jumping)
        {
            jump.jumping = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (jump.jumping || onWeb)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Web")
        {
            if (!onWeb)
            {
                onWeb = true;
            }
            if(jump.jumping && Input.anyKey)
            {
                jump.jumping = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

}
