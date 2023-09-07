using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public float size = 1.0f;

    private MeshFilter filter;

    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenenratorMesh();
    }

     void Update()
    {
        
    }

    Mesh GenenratorMesh()
    {
        Mesh mesh = new Mesh();

        mesh.SetVertices(new List<Vector3>()
        {
            new Vector3(-size * 0.5f, 0, -size * 0.5f),
            new Vector3(size * 0.5f, 0, -size * 0.5f),
            new Vector3(size * 0.5f, 0, size * 0.5f),
            new Vector3(-size * 0.5f, 0, size * 0.5f),
        });

        mesh.SetTriangles(new List<int>()
        {
            0, 1, 3,
            1, 2, 3
        },0);

        mesh.SetNormals(new List<Vector3>()
        {
            Vector3.down,
            Vector3.down,
            Vector3.down,
            Vector3.down,
        });

        mesh.SetUVs(0, new List<Vector2>()
        {
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(1,1),
            new Vector2(0,1),
        });

        return mesh;
    }
}
