using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public float size = 1.0f;
    public int gridsize = 16;

    private MeshFilter filter;

    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();

    }

     void Update()
    {
        
    }

    Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();

        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector3>();
        for(int x = 0; x < gridsize; ++x)
        {
            
        }
        mesh.SetVertices(new List<Vector3>()
        {
            new Vector3(-size * 0.5f, 0, -size * 0.5f),
            new Vector3(size  * 0.5f, 0, -size * 0.5f),
            new Vector3(size  * 0.5f, 0, size  * 0.5f),
            new Vector3(-size * 0.5f, 0, size  * 0.5f),
        });

        mesh.SetTriangles(new List<int>()
        {
            3, 1, 0,
            3, 2, 1
        },0);

        mesh.SetNormals(new List<Vector3>()
        {
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up
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
