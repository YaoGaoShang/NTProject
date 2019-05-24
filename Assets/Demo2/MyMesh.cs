using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ZhouType
{
    right,
    center
}
[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class MyMesh : MonoBehaviour
{

    #region 绘制三角形


    //private MeshFilter filter;
    //private Mesh mesh;


    //private void Start()
    //{
    //    filter = GetComponent<MeshFilter>();
    //    mesh = new Mesh();
    //    filter.mesh = mesh;
    //    PutOutMesh();
    //}


    //void PutOutMesh()
    //{
    //    Vector3[] vertices = new Vector3[] {
    //        new Vector3 (1,1,0),
    //        new Vector3 (1,-1,0),
    //        new Vector3 (-1,-1,0),
    //        new Vector3 (-1,1,0)
    //    };
    //    ///三角形顶点索引
    //    mesh.vertices = vertices;
    //    int[] triangles = new int[2 * 3] {
    //        0,1,2,
    //        2,3,0
    //    };

    //    //UV  顶点索引
    //    Vector2[] uv = new Vector2[4] {
    //          new Vector2 (1,1),
    //          new Vector2(1, 0),
    //         new Vector2(0, 0),
    //           new Vector2(0, 1),
    //              };
    //    mesh.uv = uv;
    //    mesh.triangles = triangles;
    //}
    #endregion
    #region 绘制带纹理的三角形



    //private MeshFilter filter;
    //private Mesh mesh;


    //private void Start()
    //{
    //    filter = GetComponent<MeshFilter>();
    //    mesh = new Mesh();
    //    filter.mesh = mesh;

    //    CreateTriangle();
    //}

    //private void CreateTriangle()
    //{
    //    Vector3[] vertices = new Vector3[3] {
    //        new Vector3 (0,0,0),
    //        new Vector3 (0,1,0),
    //        new Vector3 (1,0,0),
    //    };

    //    mesh.vertices = vertices;
    //    int[] triangles = new int[3] {
    //        0,1,2
    //    };
    //    mesh.triangles = triangles;
    //    Vector2[] uv = new Vector2[vertices.Length];
    //    uv[0] = new Vector2(0, 0);
    //    uv[1] = new Vector2(0, 1);
    //    uv[2] = new Vector2(1, 0);
    //    mesh.uv = uv;


    //}

    #endregion
    #region 绘制四边形
    //   private MeshFilter filter;
    //   private Mesh mesh;
    //   public float quad_With=5;
    //   public float quad_hight = 5;

    //   private void Start()
    //   {
    //       filter = GetComponent<MeshFilter>();
    //       mesh = new Mesh();
    //       filter.mesh = mesh;

    //CreateQuad();
    //   }

    //   private void Update()
    //   {
    //    CreateQuad();

    //   }
    //   /// <summary>
    //   /// 创建四边形
    //   /// </summary>
    //   private void CreateQuad()
    //   {
    //       //几何图形的顶点个数
    //       Vector3[] vertices = new Vector3[4];
    //       vertices[0] = new Vector3(0 ,0,0);
    //       vertices[1] = new Vector3(0 ,quad_hight,0);
    //       vertices[2] = new Vector3(quad_With, quad_hight, 0);
    //       vertices[3] = new Vector3(quad_With, 0, 0);
    //       mesh.vertices = vertices;


    //       //三角形的顶点个数
    //       int[] triangles = new int[2*3];
    //       triangles[0] = 0;
    //       triangles[1] = 1;
    //       triangles[2] = 2;
    //       triangles[3] =2;
    //       triangles[4] =3;
    //       triangles[5] =0;

    //       mesh.triangles = triangles;

    //       //发现  可以接受光照信息
    //       Vector3[] normals =
    //        {
    //         Vector3.up,
    //          Vector3.up,
    //         Vector3.left,
    //         Vector3.up
    //       };
    //       mesh.normals = normals;


    //       //uv  可以添加贴图信息
    //       Vector2[] uv = new Vector2[4] {
    //           new Vector2 (0,0),
    //           new Vector2 (0,1),
    //           new Vector2 (1,1),
    //           new Vector2 (1,0),
    //       };

    //       mesh.uv = uv;
    //   }


    #endregion

    #region 绘制梯形  不规则四边形

    //private MeshFilter filter;

    //private Mesh mesh;

    //private void Start()
    //{
    //    filter = GetComponent<MeshFilter>();
    //    mesh = new Mesh();
    //    filter.mesh = mesh;


    //    CreateQuad();
    //}

    //private void CreateQuad()
    //{


    //    Vector3[] vertices = new Vector3[4] {

    //        new Vector3(0,0,0),
    //        new Vector3 (0,4,0),
    //        new Vector3 (2,2,0),
    //        new Vector3 (0,2,0)


    //    };

    //    mesh.vertices = vertices;


    //    int[] triangles = new int[] {
    //            0,1,3,
    //            1,2,3
    //            //0,1,2,
    //            //2,3,0
    //    };

    //    mesh.triangles = triangles;


    //}



    #endregion
    #region 绘制 多边形
    //void Start()
    //{
    //    creatPolygon();
    //}


    //private void creatPolygon()
    //{
    //    /* 1. 顶点，三角形，法线，uv坐标, 绝对必要的部分只有顶点和三角形。  
    //          如果模型中不需要场景中的光照，那么就不需要法线。如果模型不需要贴材质，那么就不需要UV */
    //    Vector3[] vertices =
    //    {
    //     new Vector3 (2f,0,0),
    //     new Vector3(4f, 0, 0),
    //     new Vector3(6f, 0, 0),
    //     new Vector3(10f, 0, 0),
    //     new Vector3(10f, 20f, 0),
    //     new Vector3(6f,10f, 0),
    //     new Vector3(4f, 4f, 0)

    //    };

    //    Vector3[] normals =
    //    {
    //        Vector3.up,
    //        Vector3.up,
    //        Vector3.up,
    //        Vector3.up,
    //        Vector3.up,
    //        Vector3.up,
    //        Vector3.up

    //    };

    //    Vector2[] uv =
    //    {
    //        Vector2.zero,
    //        -Vector2.left,
    //        Vector2.one,
    //        Vector2.right,
    //        Vector2.zero,
    //        -Vector2.left,
    //        Vector2.one

    //    };
    //    /*2. 三角形,顶点索引：  
    //     三角形是由3个整数确定的，各个整数就是角的顶点的index。 各个三角形的顶点的顺序通常由下往上数， 可以是顺时针也可以是逆时针，这通常取决于我们从哪个方向看三角形。 通常，当mesh渲染时，"逆时针" 的面会被挡掉。 我们希望保证顺时针的面与法线的主向一致 */
    //    int[] indices = new int[15];
    //    indices[0] = 0;
    //    indices[1] = 6;
    //    indices[2] = 1;

    //    indices[3] = 6;
    //    indices[4] = 2;
    //    indices[5] = 1;

    //    indices[6] = 6;
    //    indices[7] = 5;
    //    indices[8] = 2;

    //    indices[9] = 5;
    //    indices[10] = 4;
    //    indices[11] = 2;

    //    indices[12] = 4;
    //    indices[13] = 3;
    //    indices[14] = 2;

    //    Mesh mesh = new Mesh();
    //    mesh.vertices = vertices;
    //    mesh.normals = normals;
    //    mesh.uv = uv;
    //    mesh.triangles = indices;

    //    MeshFilter meshfilter = this.gameObject.GetComponent<MeshFilter>();
    //    meshfilter.mesh = mesh;
    //}


    #endregion

    #region huizhi 333

    //private MeshFilter filter;

    //private Mesh mesh;

    //private void Start()
    //{
    //    filter = GetComponent<MeshFilter>();
    //    mesh = new Mesh();
    //    filter.mesh = mesh;


    //    CreateQuad();
    //}

    //private void CreateQuad()
    //{
    //    Vector3[] verrices = new Vector3[3] {
    //        new Vector3 (0,0,0),
    //        new Vector3 (0,4,0),
    //        new Vector3 (1,0,0),
    //    };
    //    mesh.vertices = verrices;
    //    int[] triangles = new int[3] {
    //        0, 1,2
    //    };
    //    mesh.triangles = triangles;
    //}
    #endregion


    #region 绘制圆
    /// <summary>
    ///  //半径  
    /// </summary>
    //public float Radius = 6;
    ///// <summary>
    ///// //分割数    60边形
    ///// </summary>
    //public int Segments = 60;

    //private MeshFilter meshFilter;

    //void Start()
    //{

    //    meshFilter = GetComponent<MeshFilter>();
    //    meshFilter.mesh = CreateMesh(Radius, Segments);
    //}

    //Mesh CreateMesh(float radius, int segments)
    //{
    //    //vertices:
    //    int vertices_count = Segments + 1; //+1  是因为 还有个圆心，圆心是所有三角形的一个中心点。
    //    Vector3[] vertices = new Vector3[vertices_count];// 多边形+1个点
    //    vertices[0] = Vector3.zero;//原点
    //    float angledegree = 360.0f;
    //    float angleRad = Mathf.Deg2Rad * angledegree;//360度转化为弧度
    //    float angleCur = angleRad;
    //    float angledelta = angleRad / Segments;//60 份 中每一份对应的弧度

    //    for (int i = 1; i < vertices_count; i++)
    //    {
    //        float cosA = Mathf.Cos(angleCur);
    //        float sinA = Mathf.Sin(angleCur);

    //        vertices[i] = new Vector3(Radius * cosA, 0, Radius * sinA);
    //        angleCur -= angledelta;
    //    }

    //    //triangles
    //    int triangle_count = segments * 3;//60个三角形  就对应了  60*3个顶点
    //    int[] triangles = new int[triangle_count];
    //    for (int i = 0, vi = 1; i <= triangle_count - 1; i += 3, vi++)     //因为该案例分割了60个三角形，故最后一个索引顺序应该是：0 60 1；所以需要单独处理
    //    {
    //        triangles[i] = 0;
    //        triangles[i + 1] = vi;
    //        triangles[i + 2] = vi + 1;
    //    }
    //    triangles[triangle_count - 3] = 0;
    //    triangles[triangle_count - 2] = vertices_count - 1;
    //    triangles[triangle_count - 1] = 1;                  //为了完成闭环，将最后一个三角形单独拎出来

    //    //uv:
    //    Vector2[] uvs = new Vector2[vertices_count];
    //    for (int i = 0; i < vertices_count; i++)
    //    {
    //        uvs[i] = new Vector2(vertices[i].x / radius / 2 + 0.5f, vertices[i].z / radius / 2 + 0.5f);
    //    }
    //    //Vector3[] normals = new Vector3[Segments];
    //    //for (int i = 0; i < Segments; i++)
    //    //{
    //    //    normals[i] = Vector3.up;
    //    //}


    //    //负载属性与mesh
    //    Mesh mesh = new Mesh();
    //   // mesh.normals = normals;
    //    mesh.vertices = vertices;
    //    mesh.triangles = triangles;
    //    mesh.uv = uvs;
    //    return mesh;
    //}
    #endregion


    #region 绘制长方体

    //private MeshFilter meshFilter;
    //private Mesh mesh;
    //public float cube_Length = 1;
    //public float cube_Width = 1;
    //public float cube_Hight = 1;


    //private void Start()
    //{
    //    meshFilter = GetComponent<MeshFilter>();
    //    mesh = new Mesh();
    //    mesh = CreateCubeMesh(cube_Length, cube_Width, cube_Hight);
    //}

    //private Mesh CreateCubeMesh(float cube_Length, float cube_Width, float cube_Hight)
    //{
    //    Mesh mesh = new Mesh();


    //    Vector3[] vertices = new Vector3[24];//长方体顶点 位置信息

    //    int[] triangles = new int[36];//长方体 一个6个面 一个面2个三角形，一个三角形3个顶点   所以共需要 6*2*3=36个索引，每三个索引代表一个三角形，这个所以和vertices中的位置信息有关系
    //    Vector2[] uv = new Vector2[24]; //UV  接收贴图信息
    //    Vector3[] normals = new Vector3[24];//法线  接收光照信息

    //    ///.... 顶点数组  vector3[]
    //    ///


    //    ///...三角形索引数组  int[]
    //    ///



    //    ///... 法线数组  vector3[]
    //    ///



    //    ////...  UV 数组   vector2[]



    //    return mesh;
    //}


    #endregion

    #region 绘制长方体

    private MeshFilter meshFilter;
    public float Length, Width, Heigth;
    public ZhouType zhouType;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        switch (zhouType)
        {
            case ZhouType.right:
                meshFilter.mesh = CreateMesh(Length, Width, Heigth);
                break;
            case ZhouType.center:
                meshFilter.mesh = CreateMeshCenter(Length, Width, Heigth);
                break;
            default:
                break;
        }
       
    }

    private void Update()
    {
        switch (zhouType)
        {
            case ZhouType.right:
                meshFilter.mesh = CreateMesh(Length, Width, Heigth);
                break;
            case ZhouType.center:
                meshFilter.mesh = CreateMeshCenter(Length, Width, Heigth);
                break;
            default:
                break;
        }
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
        vertices[0] = new Vector3(-length / 2, 0, 0);                     //前面的左下角的点

        vertices[1] = new Vector3(-length / 2, Heigth, 0);                //前面的左上角的点
        vertices[2] = new Vector3(length / 2, 0, 0);                //前面的右下角的点
        vertices[3] = new Vector3(length / 2, heigth, 0);        //前面的右上角的点

        vertices[4] = new Vector3(length / 2, 0, width );           //后面的右下角的点
        vertices[5] = new Vector3(length / 2, heigth, width);      //后面的右上角的点
        vertices[6] = new Vector3(-length / 2, 0, width );                //后面的左下角的点
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
        vertices[0] = new Vector3(-length / 2, 0, -width/2);                     //前面的左下角的点

        vertices[1] = new Vector3(-length / 2, Heigth, -width / 2);                //前面的左上角的点
        vertices[2] = new Vector3(length / 2, 0, -width / 2);                //前面的右下角的点
        vertices[3] = new Vector3(length / 2, heigth, -width / 2);        //前面的右上角的点

        vertices[4] = new Vector3(length / 2, 0, width/2);           //后面的右下角的点
        vertices[5] = new Vector3(length / 2, heigth, width/2);      //后面的右上角的点
        vertices[6] = new Vector3(-length / 2, 0, width/2);                //后面的左下角的点
        vertices[7] = new Vector3(-length / 2, heigth, width/2);           //后面的左上角的点

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