using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    private bool isMoving;

    Vector2 movement;
    [SerializeField]
    private SpiderSounds spiderSounds;
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<SpiderSounds>())
        {
            spiderSounds = this.gameObject.GetComponent<SpiderSounds>();
        }
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x != 0 || movement.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving)
        {
            if(!audioSource.isPlaying)
            {
                spiderSounds.playWalkSound();
            }
        }
        else if(!isMoving)
        {
            if(audioSource.isPlaying)
            {
                spiderSounds.stopWalkSound();
            }
        }
    }

    void FixedUpdate()
    {
        //Movement
        if(isMoving)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public bool getIsMoving()
    {
        return isMoving;
    }
}
