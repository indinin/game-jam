using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    public bool jumping = false;
    public float jumpSpeed;
    private GameoverToggle gameoverToggle;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.GetComponent<GameoverToggle>())
        {
            gameoverToggle = this.gameObject.GetComponent<GameoverToggle>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !gameoverToggle.getIsGameOver())
        {
            if (!jumping && (!GetComponent<walkScript>().grav))
            {
                var mouse = Input.mousePosition;
                var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
                var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
                var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                jumping = true;
            }
        }
        if (jumping)
        {
            transform.position += transform.up * Time.deltaTime * jumpSpeed;
        }
        
    }
}
