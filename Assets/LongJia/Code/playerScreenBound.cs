using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScreenBound : MonoBehaviour
{
    public Vector2 screenBounds;
    public float objWidth;
    public float objHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.x = Mathf.Clamp(objectPosition.x, -screenBounds.x + objWidth, screenBounds.x - objWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, -screenBounds.y + objHeight, screenBounds.y - objHeight);
        transform.position = objectPosition;
    }
}
