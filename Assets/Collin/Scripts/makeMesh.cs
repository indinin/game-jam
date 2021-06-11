using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMesh : MonoBehaviour
{
    public GameObject[] nodes;

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            updateNodes();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            generateMesh();
        }
    }

    void updateNodes()
    {
        nodes = GameObject.FindGameObjectsWithTag("webNode");
    }

    void generateMesh()
    {
        GetComponent<MeshFilter>().mesh = mesh;
        createShape();
    }

    void createShape()
    {
        vertices = new Vector3[nodes.Length];
        int i = 0;
        foreach (GameObject node in nodes)
        {
            vertices[i] = node.transform.position;
            i++;
        }
        triangles = new int[]
        {
            0,1,2
        };

        updateMesh();
    }

    void updateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
