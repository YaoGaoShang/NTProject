// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-13 10:30:08
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDemo : MonoBehaviour
{

    // Use this for initialization
    public GameObject sphere;
    void Start()
    {
        //this.GetPentagon();
        this.GetTriangle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetTriangle()
    {
        GameObject go = new GameObject("Triangle");
        MeshFilter filter = go.AddComponent<MeshFilter>();

        // 构建三角形的三个顶点，并赋值给Mesh.vertices
        Mesh mesh = new Mesh();
        filter.sharedMesh = mesh;
        mesh.vertices = new Vector3[] {
                new Vector3 (0, 0, 1),
                new Vector3 (0, 2, 0),
                new Vector3 (2, 0, 5),
            };
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            GameObject obj = Instantiate(sphere);
            obj.name = "顶点" + i.ToString();
            obj.transform.position = mesh.vertices[i];
        }
        // 构建三角形的顶点顺序，因为这里只有一个三角形，
        // 所以只能是(0, 1, 2)这个顺序。
        mesh.triangles = new int[3] { 1, 2, 0 };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        Vector2[] uvs = new Vector2[mesh. vertices.Length];
           uvs[0] = new Vector2(0, 0.5f);
           uvs[1] = Vector2.one;
           uvs[2] = Vector2.right;
        mesh.uv = uvs;
        // 使用Shader构建一个材质，并设置材质的颜色。
        Material material = new Material(Shader.Find("Diffuse"));
        material.SetColor("_Color", Color.yellow);

        // 构建一个MeshRender并把上面创建的材质赋值给它，
        // 然后使其把上面构造的Mesh渲染到屏幕上。
        MeshRenderer renderer = go.AddComponent<MeshRenderer>();
        renderer.sharedMaterial = material;

        return go;
    }
    public GameObject GetPentagon()
    {
        GameObject go = new GameObject("Pentagon");
        MeshFilter filter = go.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        filter.sharedMesh = mesh;
        mesh.vertices = new Vector3[] {
        new Vector3 (0, 0, 0),
        new Vector3 (0, 2, 0),
        new Vector3 (2, 0, 0),
        new Vector3 (2, -2, 0),
        new Vector3 (1, -2, 0),
    };
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            GameObject obj = Instantiate(sphere);
            obj.name = "顶点" + i.ToString();
            obj.transform.position = mesh.vertices[i];
        }

        mesh.triangles = new int[9] { 0, 1, 2, 2, 3, 0, 4, 0, 3 };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        Material material = new Material(Shader.Find("Diffuse"));
        material.SetColor("_Color", Color.yellow);

        MeshRenderer renderer = go.AddComponent<MeshRenderer>();
        renderer.sharedMaterial = material;

        return go;
    }
}