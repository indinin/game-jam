using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshManager : MonoBehaviour
{
    public GameObject obj, meshMaker, player, center, meter;
    bool jumped;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {           
        if(player.GetComponent<jumpScript>().jumping && !jumped)
        {
            jumped = true;
            if (!player.GetComponent<walkScript>().onWeb)
            {
                Instantiate(obj, player.transform.position, new Quaternion(0, 0, 0, 0));
            }
        }
        if(jumped && !player.GetComponent<jumpScript>().jumping)
        {
            jumped = false;
        }
    }

    public void makeMesh()
    {
        GameObject mesh = Instantiate(meshMaker, center.transform.position, center.transform.rotation);
        mesh.GetComponent<makeMesh>().center = center;
        mesh.GetComponent<makeMesh>().meter = meter;

        GameObject[] nodes = GameObject.FindGameObjectsWithTag("webNode");
        foreach (GameObject node in nodes)
        {
            Destroy(node.gameObject);
        }
    }
}
