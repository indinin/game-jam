using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{

    public GameObject self, player;
    bool visible = true;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        self.transform.position = player.transform.position;
        if (Input.GetMouseButton(0))
        {
            if (!visible)
            {
                visible = true;
                GetComponent<SpriteRenderer>().enabled = true;
            }
            var mouse = Input.mousePosition;
            var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        } else if (visible)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            visible = false;
        }
    }
}
