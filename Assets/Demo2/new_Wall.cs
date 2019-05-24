using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WallType
{
    left_Bottom,
    center_Bottom,
    center
}
[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class new_Wall : MonoBehaviour
{


    #region 绘制长方体

    private MeshFilter meshFilter;
    public float Length, Width, Heigth;
    public WallType wallType;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        switch (wallType)
        {
            case WallType.left_Bottom:
                meshFilter.mesh = CreateMesh(Length, Width, Heigth);
                gameObject.AddComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
              //  gameObject.AddComponent<MeshCollider>();
                break;
            case WallType.center_Bottom:
                meshFilter.mesh = CreateMeshCenter_Bottom(Length, Width, Heigth);
                break;
            case WallType.center:
                meshFilter.mesh = CreateMeshCenter(Length, Width, Heigth);
                break;
            default:
                break;
        }
      

    }

    private void Update()
    {
        //switch (wallType)
        //{
        //    case WallType.left_Bottom:
        //        meshFilter.mesh = CreateMesh(Length, Width, Heigth);
        //        break;
        //    case WallType.center_Bottom:
        //        meshFilter.mesh = CreateMeshCenter_Bottom(Length, Width, Heigth);
        //        break;
        //    case WallType.center:
        //        meshFilter.mesh = CreateMeshCenter(Length, Width, Heigth);
        //        break;
        //    default:
        //        break;
       // }
    }
    /// <summary>
    /// 创建的中心点在左边的中心位置
    /// </summary>
    /// <param name="length"></param>
    /// <param name="width"></param>
    /// <param name="heigth"></param>
    /// <returns></returns>
    Mesh CreateMesh(float length, float width, float heigth)
    {

        //vertices(顶点、必须):
        int vertices_count = 4 * 6;                                 //顶点数（每个面4个点，六个面）
        Vector3[] vertices = new Vector3[vertices_count];
        #region UV计算


        //uv
        Vector2[] uv = new Vector2[vertices_count];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 0);
        uv[3] = new Vector2(1, 1);

        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(0, 1);
        uv[6] = new Vector2(1, 0);
        uv[7] = new Vector2(1, 1);
        uv[8] = uv[6];
        uv[9] = uv[7];
        uv[10] = uv[0];
        uv[11] = uv[1];


        uv[12] = uv[2];
        uv[13] = uv[3];
        uv[14] = uv[4];
        uv[15] = uv[5];


        uv[16] = uv[1];
        uv[17] = uv[7];
        uv[18] = uv[3];
        uv[19] = uv[5];

        uv[20] = uv[2];
        uv[21] = uv[4];
        uv[22] = uv[0];
        uv[23] = uv[6];
        #endregion
    


        //法线
      //  Vector3[] normals = new Vector3[vertices_count];
        vertices[0] = new Vector3(-length / 2, 0, 0);                     //前面的左下角的点

        vertices[1] = new Vector3(-length / 2, Heigth, 0);                //前面的左上角的点
        vertices[2] = new Vector3(length / 2, 0, 0);                //前面的右下角的点
        vertices[3] = new Vector3(length / 2, heigth, 0);        //前面的右上角的点

        vertices[4] = new Vector3(length / 2, 0, width);           //后面的右下角的点
        vertices[5] = new Vector3(length / 2, heigth, width);      //后面的右上角的点
        vertices[6] = new Vector3(-length / 2, 0, width);                //后面的左下角的点
        vertices[7] = new Vector3(-length / 2, heigth, width);           //后面的左上角的点

        vertices[8] = vertices[6];                              //左
        vertices[9] = vertices[7];
        vertices[10] = vertices[0];
        vertices[11] = vertices[1];

        vertices[12] = vertices[2];                              //右
        vertices[13] = vertices[3];
        vertices[14] = vertices[4];
        vertices[15] = vertices[5];

        vertices[16] = vertices[1];                              //上
        vertices[17] = vertices[7];
        vertices[18] = vertices[3];
        vertices[19] = vertices[5];

        vertices[20] = vertices[2];                              //下
        vertices[21] = vertices[4];
        vertices[22] = vertices[0];
        vertices[23] = vertices[6];

        //triangles(索引三角形、必须):
        int count = 6 * 2;
        int triangles_cout = count * 3;                  //索引三角形的索引点个数
        int[] triangles = new int[triangles_cout];            //索引三角形数组
        for (int i = 0, vi = 0; i < triangles_cout; i += 6, vi += 4)
        {
            triangles[i] = vi;
            triangles[i + 1] = vi + 1;
            triangles[i + 2] = vi + 2;

            triangles[i + 3] = vi + 3;
            triangles[i + 4] = vi + 2;
            triangles[i + 5] = vi + 1;

        }


        //负载属性与mesh
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;

        mesh.uv = uv;

        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        // mesh.uv = uv;
        return mesh;
    }


    /// <summary>
    /// 中心点  在模型的中心底部位置
    /// </summary>
    /// <param name="length"></param>
    /// <param name="width"></param>
    /// <param name="heigth"></param>
    /// <returns></returns>
    Mesh CreateMeshCenter_Bottom(float length, float width, float heigth)
    {
        //vertices(顶点、必须):
        int vertices_count = 4 * 6;                                 //顶点数（每个面4个点，六个面）
        Vector3[] vertices = new Vector3[vertices_count];
        //uv
        Vector2[] uv = new Vector2[vertices_count];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(0, -1);
        uv[6] = new Vector2(-1, -1);
        uv[7] = new Vector2(-1, 0);
        uv[8] = uv[6];
        uv[9] = uv[7];
        uv[10] = uv[0];
        uv[11] = uv[1];


        uv[12] = uv[2];
        uv[13] = uv[3];
        uv[14] = uv[4];
        uv[15] = uv[5];


        uv[16] = uv[1];
        uv[17] = uv[7];
        uv[18] = uv[3];
        uv[19] = uv[5];

        uv[20] = uv[2];
        uv[21] = uv[4];
        uv[22] = uv[0];
        uv[23] = uv[6];

        //法线
        Vector3[] normals = new Vector3[vertices_count];
        vertices[0] = new Vector3(-length / 2, 0, -width / 2);                     //前面的左下角的点

        vertices[1] = new Vector3(-length / 2, heigth, -width / 2);                //前面的左上角的点
        vertices[2] = new Vector3(length / 2, 0, -width / 2);                //前面的右下角的点
        vertices[3] = new Vector3(length / 2, heigth, -width / 2);        //前面的右上角的点

        vertices[4] = new Vector3(length / 2, 0, width / 2);           //后面的右下角的点
        vertices[5] = new Vector3(length / 2, heigth, width / 2);      //后面的右上角的点
        vertices[6] = new Vector3(-length / 2, 0, width / 2);                //后面的左下角的点
        vertices[7] = new Vector3(-length / 2, heigth, width / 2);           //后面的左上角的点

        vertices[8] = vertices[6];                              //左
        vertices[9] = vertices[7];
        vertices[10] = vertices[0];
        vertices[11] = vertices[1];

        vertices[12] = vertices[2];                              //右
        vertices[13] = vertices[3];
        vertices[14] = vertices[4];
        vertices[15] = vertices[5];

        vertices[16] = vertices[1];                              //上
        vertices[17] = vertices[7];
        vertices[18] = vertices[3];
        vertices[19] = vertices[5];

        vertices[20] = vertices[2];                              //下
        vertices[21] = vertices[4];
        vertices[22] = vertices[0];
        vertices[23] = vertices[6];


        //triangles(索引三角形、必须):
        int 分割三角形数 = 6 * 2;
        int triangles_cout = 分割三角形数 * 3;                  //索引三角形的索引点个数
        int[] triangles = new int[triangles_cout];            //索引三角形数组
        for (int i = 0, vi = 0; i < triangles_cout; i += 6, vi += 4)
        {
            triangles[i] = vi;
            triangles[i + 1] = vi + 1;
            triangles[i + 2] = vi + 2;

            triangles[i + 3] = vi + 3;
            triangles[i + 4] = vi + 2;
            triangles[i + 5] = vi + 1;

        }


        //负载属性与mesh
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        // mesh.uv = uv;
        return mesh;
    }


    /// <summary>
    /// 中心点  在模型的中心位置
    /// </summary>
    /// <param name="length"></param>
    /// <param name="width"></param>
    /// <param name="heigth"></param>
    /// <returns></returns>
    Mesh CreateMeshCenter(float length, float width, float heigth)
    {
        //vertices(顶点、必须):
        int vertices_count = 4 * 6;                                 //顶点数（每个面4个点，六个面）
        Vector3[] vertices = new Vector3[vertices_count];
        //uv
        Vector2[] uv = new Vector2[vertices_count];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(0, -1);
        uv[6] = new Vector2(-1, -1);
        uv[7] = new Vector2(-1, 0);
        uv[8] = uv[6];
        uv[9] = uv[7];
        uv[10] = uv[0];
        uv[11] = uv[1];


        uv[12] = uv[2];
        uv[13] = uv[3];
        uv[14] = uv[4];
        uv[15] = uv[5];


        uv[16] = uv[1];
        uv[17] = uv[7];
        uv[18] = uv[3];
        uv[19] = uv[5];

        uv[20] = uv[2];
        uv[21] = uv[4];
        uv[22] = uv[0];
        uv[23] = uv[6];

        //法线
        Vector3[] normals = new Vector3[vertices_count];
        vertices[0] = new Vector3(-length / 2, -heigth / 2, -width / 2);                     //前面的左下角的点

        vertices[1] = new Vector3(-length / 2, heigth / 2, -width / 2);                //前面的左上角的点
        vertices[2] = new Vector3(length / 2, -heigth / 2, -width / 2);                //前面的右下角的点
        vertices[3] = new Vector3(length / 2, heigth / 2, -width / 2);        //前面的右上角的点

        vertices[4] = new Vector3(length / 2, -heigth / 2, width / 2);           //后面的右下角的点
        vertices[5] = new Vector3(length / 2, heigth / 2, width / 2);      //后面的右上角的点
        vertices[6] = new Vector3(-length / 2, -heigth / 2, width / 2);                //后面的左下角的点
        vertices[7] = new Vector3(-length / 2, heigth / 2, width / 2);           //后面的左上角的点

        vertices[8] = vertices[6];                              //左
        vertices[9] = vertices[7];
        vertices[10] = vertices[0];
        vertices[11] = vertices[1];

        vertices[12] = vertices[2];                              //右
        vertices[13] = vertices[3];
        vertices[14] = vertices[4];
        vertices[15] = vertices[5];

        vertices[16] = vertices[1];                              //上
        vertices[17] = vertices[7];
        vertices[18] = vertices[3];
        vertices[19] = vertices[5];

        vertices[20] = vertices[2];                              //下
        vertices[21] = vertices[4];
        vertices[22] = vertices[0];
        vertices[23] = vertices[6];


        //triangles(索引三角形、必须):
        int 分割三角形数 = 6 * 2;
        int triangles_cout = 分割三角形数 * 3;                  //索引三角形的索引点个数
        int[] triangles = new int[triangles_cout];            //索引三角形数组
        for (int i = 0, vi = 0; i < triangles_cout; i += 6, vi += 4)
        {
            triangles[i] = vi;
            triangles[i + 1] = vi + 1;
            triangles[i + 2] = vi + 2;

            triangles[i + 3] = vi + 3;
            triangles[i + 4] = vi + 2;
            triangles[i + 5] = vi + 1;
        }


        //负载属性与mesh
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        // mesh.uv = uv;
        return mesh;
    }



    #endregion
}
