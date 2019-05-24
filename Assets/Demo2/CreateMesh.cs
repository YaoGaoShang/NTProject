using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// 创建自定义Mesh类
public class CreateMesh : MonoBehaviour
{


    /// <summary>
    /// 生成自定义多边形方法
    /// </summary>
    /// <param name="s_Vertives">自定义的顶点数组</param>
    public void DoCreatPloygonMesh(Vector3[] s_Vertives, Material material)
    {
        //新建一个空物体进行进行绘制自定义多边形
        //  GameObject tPolygon = new GameObject("Ground");
        GameObject tPolygon = GameObject.Find("Ground");

        //绘制所必须的两个组件
        tPolygon.AddComponent<MeshFilter>();
        tPolygon.AddComponent<MeshRenderer>();

        //新申请一个Mesh网格
        Mesh tMesh = new Mesh();

        float offsetY = tPolygon.transform.position.y;
        //存储所有的顶点
        for (int i = 0; i < s_Vertives.Length; i++)
        {
            //对 存储的点 进行 偏移
            s_Vertives[i] = new Vector3(s_Vertives[i].x, s_Vertives[i].y + Mathf.Abs(offsetY), s_Vertives[i].z);
        }
        Vector3[] tVertices = s_Vertives;
        print("三角形顶点   ：   " + tVertices.Length);
        //存储画所有三角形的点排序
        List<int> tTriangles = new List<int>();

        //根据所有顶点填充点排序
        for (int i = 0; i < tVertices.Length - 1; i++)
        {
            tTriangles.Add(i);
            tTriangles.Add(i + 1);
            tTriangles.Add(tVertices.Length - i - 1);
        }


        //赋值多边形顶点
        tMesh.vertices = tVertices;

        //赋值三角形点排序
        tMesh.triangles = tTriangles.ToArray();

        Vector2[] uv = new Vector2[tVertices.Length];
        for (int i = 0; i < uv.Length; i++)
        {
            uv[i] = Vector2.up;
        }


        //将绘制好的Mesh赋值
        tPolygon.GetComponent<MeshFilter>().mesh = tMesh;
        tMesh.uv = uv;
        //重新设置UV，法线
        tMesh.RecalculateBounds();
        tMesh.RecalculateNormals();

        tPolygon.GetComponent<MeshRenderer>().material = material;
        // tPolygon.AddComponent<BoxCollider>();
        tPolygon.AddComponent<MeshCollider>().sharedMesh = tMesh;
    }


    public void DemoMesh(Vector3[] s_Vertives, Material material)
    {
        //新建一个空物体进行进行绘制自定义多边形
        //  GameObject tPolygon = new GameObject("Ground");
        GameObject tPolygon = GameObject.Find("Ground");

        //绘制所必须的两个组件
        tPolygon.AddComponent<MeshFilter>();
        tPolygon.AddComponent<MeshRenderer>();

        //新申请一个Mesh网格
        Mesh tMesh = new Mesh();

        float offsetY = tPolygon.transform.position.y;
        //存储所有的顶点
        for (int i = 0; i < s_Vertives.Length; i++)
        {
            //对 存储的点 进行 偏移
            s_Vertives[i] = new Vector3(s_Vertives[i].x, s_Vertives[i].y + Mathf.Abs(offsetY), s_Vertives[i].z);
        }
        Vector3[] tVertices = s_Vertives;
        print("三角形顶点   ：   " + tVertices.Length);
        //存储画所有三角形的点排序
        List<int> tTriangles = new List<int>();

        //根据所有顶点填充点排序
        for (int i = 0; i < tVertices.Length - 2; i++)
        {
            tTriangles.Add(0);
            tTriangles.Add(i + 1);
            tTriangles.Add(i + 2);
           // print(0 + "\t" + (i + 1) + "\t" + (i + 2));
            // print(tVertices[i] + "\t" + tVertices[i + 1] + "\t" + tVertices[tVertices.Length - i - 1]);
        }


        //赋值多边形顶点
        tMesh.vertices = tVertices;

        //赋值三角形点排序
        tMesh.triangles = tTriangles.ToArray();

       Vector2[] uv = new Vector2[tVertices.Length];
        //for (int i = 0; i < uv.Length; i++)
        //{
        //    uv[i] = Vector2.up;
        //}

        #region 四边形

        uv[0] = new Vector2(0, 1f);
        uv[1] = new Vector2(1, 1);
        uv[2] = new Vector2(1f, 0);
        uv[3] = new Vector2(0, 0);
       // uv[4] = new Vector2(0, 1f);

        #endregion
        //将绘制好的Mesh赋值
        tPolygon.GetComponent<MeshFilter>().mesh = tMesh;
        tMesh.uv = uv;
        //重新设置UV，法线
        tMesh.RecalculateBounds();
        tMesh.RecalculateNormals();

        tPolygon.GetComponent<MeshRenderer>().material = material;
        // tPolygon.AddComponent<BoxCollider>();
        tPolygon.AddComponent<MeshCollider>().sharedMesh = tMesh;
    }
}