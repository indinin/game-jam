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
    private bool isLessThanX, isLessThanXOld, isLessThanY, isLessThanYOld, isJumping;
    [SerializeField]
    private Vector2 worldPoint, spiderPoint;
    [SerializeField]
    private GameObject arrow;
    private playerMovement playerMovement;
    private SpiderSounds spiderSounds;
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<Rigidbody2D>())
        {
            rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        }
        if(this.gameObject.GetComponent<playerMovement>())
        {
            playerMovement = this.gameObject.GetComponent<playerMovement>();
        }
        if(this.gameObject.GetComponent<SpiderSounds>())
        {
            spiderSounds = this.gameObject.GetComponent<SpiderSounds>();
        }
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
        // isLessThanX = false;
        // isLessThanXOld = isLessThanX;
        // isLessThanY = false;
        // isLessThanYOld = isLessThanY;
        isJumping = false;
    }

    void Update()
    {
        spiderPoint = new Vector2(this.transform.position.x, this.transform.position.y);
        // if(spiderPoint.x < worldPoint.x)
        // {
        //     isLessThanX = true;
        // }
        // else
        // {
        //     isLessThanX = false;
        // }
        // if(spiderPoint.y == worldPoint.y)
        // {
        //     isLessThanY = true;
        // }
        // else
        // {
        //     isLessThanY = false;
        // }

        if(Input.GetKeyDown("space"))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.gravityScale = 0;
            Instantiate(arrow, spiderPoint, this.transform.rotation);
        }
        if(Input.GetKeyUp("space"))
        {
            Debug.Log("Space Key Pressed");
            spiderSounds.playJumpSound();
            isJumping = true;
            worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            rigidbody.gravityScale = 5;
            rigidbody.AddForce((worldPoint - spiderPoint) * power);
            Debug.Log("Jump Power Activated");
            // if(spiderPoint.x < worldPoint.x)
            // {
            //     isLessThanX = true;
            //     isLessThanXOld = isLessThanX;
            // }
            // else
            // {
            //     isLessThanX = false;
            //     isLessThanXOld = isLessThanX;
            // }
            // if(spiderPoint.y == worldPoint.y)
            // {
            //     isLessThanY = true;
            //     isLessThanYOld = isLessThanY;
            // }
            // else
            // {
            //     isLessThanY = false;
            //     isLessThanYOld = isLessThanY;
            // }
        }
        // if((isLessThanX != isLessThanXOld || isLessThanY != isLessThanYOld) || (rigidbody.velocity.x == 0 || rigidbody.velocity.y == 0) || playerMovement.getIsMoving())
        // {
        //     rigidbody.velocity = Vector2.zero;
        //     rigidbody.gravityScale = 0;
        // }
    }

    public bool getIsJumping()
    {
        return isJumping;
    }

    public void setIsJumping(bool isJumping)
    {
        this.isJumping = isJumping;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.gravityScale = 0;
        }
        if (col.gameObject.tag == "Web")
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.gravityScale = 0;
        }
    }
}
