using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNode : MonoBehaviour
{
    public makeMesh meshScript;
    public Camera cam;
    public GameObject obj, meshMaker, tracker, center, meter;

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
                if (hit.collider.gameObject.tag == "webNode")
                {
                    GameObject mesh = Instantiate(meshMaker, center.transform.position, center.transform.rotation);
                    mesh.GetComponent<makeMesh>().center = center;
                    mesh.GetComponent<makeMesh>().meter = meter;
                    //meshScript.generateMesh();
                    GameObject[] nodes = GameObject.FindGameObjectsWithTag("webNode");
                    for(int i = 0; i < nodes.Length; i++)
                    {
                        Destroy(nodes[i]);
                    }
                }
                else
                {
                    tracker.transform.position = hit.point;
                    Instantiate(obj, tracker.transform.position, tracker.transform.rotation);
                }
            }
        }
    }
}
