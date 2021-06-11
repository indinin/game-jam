using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNode : MonoBehaviour
{
    
    public Camera cam;
    public GameObject obj, tracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                tracker.transform.position = hit.point;
                Instantiate(obj, tracker.transform.position, tracker.transform.rotation);
            }
        }
    }
}
