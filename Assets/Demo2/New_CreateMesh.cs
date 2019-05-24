using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_CreateMesh : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<MeshFilter>().mesh = CreateMesh(10, 10, 2, 5);
    }
    float angle = 60;
    Vector3[] normals;
    Vector3[] verts;
    Vector2[] uvs;
    public Mesh CreateMesh(int edg_x, int edg_y, float rad, float len)
    {
        edg_x = Mathf.Max(2, edg_x);//保证最低2个边
        edg_y = Mathf.Max(2, edg_y);
        int _deglen = edg_x * edg_y + edg_y;
        normals = new Vector3[_deglen];
        verts = new Vector3[_deglen];
        uvs = new Vector2[_deglen];
        int[] trians = new int[edg_x * (edg_y - 1) * 6];
        float reg = 6.28318f / edg_x;
        float _len = len / (edg_y - 1);
        Vector2 uvStep = new Vector2(1f / edg_x, 1f / (edg_y - 1));
        for (int y = 0; y < edg_y; y++)
            for (int x = 0; x < edg_x + 1; x++)//多一个边来保存UV值
            {
                int i = x + y * (edg_x + 1);
                verts[i] = new Vector3(Mathf.Sin((reg * (x % edg_x) + angle) % 6.28318f) * rad, Mathf.Cos((reg * (x % edg_x) + angle) % 6.28318f) * rad, y * _len);//计算顶点坐标
                normals[i] = -new Vector3(verts[i].x, verts[i].y, 0);//计算法线方向
                int id = x % (edg_x + 1) * 6 + y * edg_x * 6;
                if (x < edg_x + 1 && y < edg_y - 1 && (id + 5) < trians.Length)//计算顶点数组
                {
                    trians[id] = i;
                    trians[id + 1] = trians[id + 4] = i + edg_x + 1;
                    trians[id + 2] = trians[id + 3] = i + 1;
                    trians[id + 5] = i + edg_x + 2;
                }
                if (edg_x != 2)//计算UV，考虑到2个边的情况
                    uvs[i] = new Vector2(x == edg_x ? 1f : uvStep.x * x, y == edg_y - 1 ? 1f : uvStep.y * y);
                else
                    uvs[i] = new Vector2(x % edg_x, y == edg_y - 1 ? 1f : uvStep.y * y);
            }
        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = trians;
        mesh.uv = uvs;
        mesh.normals = normals;
        return mesh;
    }

}
