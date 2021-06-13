using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newNodeScript : MonoBehaviour
{
    bool firstNode = false;
    bool waited = false; //waits to prevent a misfirign of the make mesh
    public float waitTime;
    GameObject player;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.FindGameObjectsWithTag("webNode").Length == 1)
        {
            firstNode = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstNode)
        {
            if (!waited)
            {
                if (firstNode && !waited)
                {
                    waitTime -= Time.deltaTime;
                }

                if (waitTime <= 0)
                {
                    waited = true;
                }
            }
            else
            {
                if(Vector3.Distance(transform.position, player.transform.position) < distance)
                {
                    GameObject[] nodes = GameObject.FindGameObjectsWithTag("webNode");
                    if (nodes.Length > 2)
                    {
                        print("Make web");
                        player.GetComponent<meshManager>().makeMesh();
                    }

                    player.GetComponent<meshManager>().deleteNodes();
                }
            }
        }
    }
}
