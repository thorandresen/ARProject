using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScript : MonoBehaviour
{
    public float width = 1;
    public float height = 1;
    
    [SerializeField] private Material material;


    public void Start()
    { 
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = material;
        

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();


        Vector3[] vertices = new Vector3[17]
        {
            //new Vector3(0, 0, 0),
            //new Vector3(width, 0, 0),
            //new Vector3(0, height, 0),
            //new Vector3(width, height, 0)
            new Vector3(1,0,0),
            new Vector3(0,4,0),
            new Vector3(3,4,0),
            new Vector3(3,1,-1),
            new Vector3(1,7,0),
            new Vector3(4,6,1),
            new Vector3(2,9,0),
            new Vector3(4,9,0),
            new Vector3(3,12,0),
            new Vector3(4,13,0),
            new Vector3(5,12,0),
            new Vector3(6,9,0),
            new Vector3(7,7,0),
            new Vector3(5,4,0),
            new Vector3(8,4,0),
            new Vector3(5,1,-1),
            new Vector3(7,0,0),
        };
        mesh.vertices = vertices;

        int[] tris = new int[48]
        {
            // lower left triangle
            // 0, 2, 1,
            // upper right triangle
            // 2, 3, 1
            0,1,2,
            0,2,3,
            1,4,2,
            2,4,5,
            4,6,5,
            5,6,11,
            6,8,7,
            7,8,10,
            8,9,10,
            7,10,11,
            5,11,12,
            2,5,13,
            13,5,12,
            13,12,14,
            15,13,16,
            13,14,16


        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        //mesh.normals = normals;
        mesh.RecalculateNormals();

        Vector2[] uv = new Vector2[18]
        {
            //new Vector2(0, 0),
            //new Vector2(1, 0),
            //new Vector2(0, 1),
            //new Vector2(1, 1)

            new Vector2(1,0),
            new Vector2(0,4),
            new Vector2(3,3),
            new Vector2(3,1),
            new Vector2(1,7),
            new Vector2(4,6),
            new Vector2(3,1),
            new Vector2(2,9),
            new Vector2(4,9),
            new Vector2(3,12),
            new Vector2(4,13),
            new Vector2(5,12),
            new Vector2(6,9),
            new Vector2(7,7),
            new Vector2(5,4),
            new Vector2(8,4),
            new Vector2(5,1),
            new Vector2(7,0),

        };
        //mesh.uv = uv;

        meshFilter.mesh = mesh;
    }
}
