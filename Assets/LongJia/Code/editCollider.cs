using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editCollider : MonoBehaviour
{

    void Awake()
    {
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        if(poly == null)
        {
            poly = gameObject.AddComponent<PolygonCollider2D>();

        }
        Vector2[] points = poly.points;
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = points;
        Destroy(poly);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
