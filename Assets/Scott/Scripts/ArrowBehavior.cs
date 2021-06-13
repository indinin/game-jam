using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    private Vector3 mousePos, objPos;
    private float angle;
    [SerializeField]
    private SpiderJump spiderJump;
    private GameObject spider;
    private GameoverToggle gameoverToggle;

    void Awake()
    {
        spider = GameObject.FindWithTag("Player");
        if(spider.GetComponent<SpiderJump>())
        {
            spiderJump = spider.GetComponent<SpiderJump>();
        }
        if(spider.GetComponent<GameoverToggle>())
        {
            gameoverToggle = spider.GetComponent<GameoverToggle>();
        }
    }

    void Update()
    {
        if(spiderJump.getIsJumping())
        {
            spiderJump.setIsJumping(false);
            Destroy(this.gameObject);
            Debug.Log("Arrow Destroyed");
        }

        if(!gameoverToggle.getIsGameOver())
        {
            makeArrow();
        }
    }

    public void makeArrow()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 5.23f; //The distance between the camera and object
        objPos = Camera.main.WorldToScreenPoint(this.transform.position);
        mousePos.x = mousePos.x - objPos.x;
        mousePos.y = mousePos.y - objPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
