using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMesh : MonoBehaviour
{
    public GameObject[] nodes;
    public GameObject center, meter;
    public float dim3;
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    PolygonCollider2D poly;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        poly = GetComponent<PolygonCollider2D>();
        generateMesh();
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

    public void generateMesh()
    {
        updateNodes();
        GetComponent<MeshFilter>().mesh = mesh;
        createShape();
    }

    void createShape()
    {
        setVertices();
        setTriangles();

        updateMesh();
    }

    void setVertices()
    {
        vertices = new Vector3[nodes.Length];
        int i = 0;
        foreach (GameObject node in nodes)
        {
            vertices[i] = node.transform.position;
            vertices[i].z = dim3;
            i++;
        }

        sortVertices();
    }
    void sortVertices()
    {
        //Vector3[] sortedVerts = new Vector3[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            int smallest = i;
            for(int j = i; j < vertices.Length; j++)
            {
                if(getAngle(j) < getAngle(smallest))
                {
                    smallest = j;
                }
            }
            Vector3 temp = vertices[i];
            vertices[i] = vertices[smallest];
            vertices[smallest] = temp;
        }
    }
    
    float getAngle(int index)
    {
        return (Vector3.SignedAngle(Vector3.up, -center.transform.position + vertices[index], new Vector3(0, 0, -1)) + 360) % 360;
    }

    void setTriangles()
    {
        triangles = new int[3 * (vertices.Length - 2)];
        int vert = 1;
        for(int i = 0; i < triangles.Length; i += 3)
        {
            triangles[i] = 0;
            triangles[i + 1] = vert;
            triangles[i + 2] = vert + 1;
            vert++;
        }
    }

    void updateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        Vector2[] uvs = new Vector2[vertices.Length];

        for(int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }

        mesh.uv = uvs;
        poly.SetPath(0,uvs);

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        print("Area: " + CalculateSurfaceArea());

        meter.GetComponent<webMeterScript>().changeWebbing(-1 * CalculateSurfaceArea());
    }


    float CalculateSurfaceArea()
    {
        var triangles = mesh.triangles;
        var vertices = mesh.vertices;

        double sum = 0.0;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 corner = vertices[triangles[i]];
            Vector3 a = vertices[triangles[i + 1]] - corner;
            Vector3 b = vertices[triangles[i + 2]] - corner;

            sum += Vector3.Cross(a, b).magnitude;
        }

        return (float)(sum / 2.0);
    }
}
