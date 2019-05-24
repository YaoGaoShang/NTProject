using UnityEngine;
using System.Collections;
using System;

public enum Direction
{
    ClockWise,
    Anti_ClockWise
}

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TestCubeDirection : MonoBehaviour
{
    public Material mat;
    public float cube_length,cube_width, cube_high;

    void Start()
    {
                DrawAnti_ClockWiseCube(cube_length, cube_width, cube_high);
    }

    /// <summary>
    /// 按逆时针画立方体
    /// </summary>
    void DrawAnti_ClockWiseCube(float length,float width,float high )
    {
        gameObject.GetComponent<MeshRenderer>().material = mat;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        Vector3[] vertices = new Vector3[24];
        vertices[0] = new Vector3(-length / 2, 0, -width / 2);                     //前面的左下角的点

        vertices[1] = new Vector3(-length / 2, high, -width / 2);                //前面的左上角的点
        vertices[2] = new Vector3(length / 2, 0, -width / 2);                //前面的右下角的点
        vertices[3] = new Vector3(length / 2, high, -width / 2);        //前面的右上角的点

        vertices[4] = new Vector3(length / 2, 0, width / 2);           //后面的右下角的点
        vertices[5] = new Vector3(length / 2, high, width / 2);      //后面的右上角的点
        vertices[6] = new Vector3(-length / 2, 0, width / 2);                //后面的左下角的点
        vertices[7] = new Vector3(-length / 2, high, width / 2);           //后面的左上角的点

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
        //设置顶点
        //  mesh.vertices = new Vector3[24]
        //     {
        ////front
        //new Vector3(0, 0, 0),
        //new Vector3(0, 0, width),
        //new Vector3(length, 0, width),
        //new Vector3(1, 0, 0),

        ////top
        //new Vector3(0, 0, width),
        //new Vector3(0, high, width),
        //new Vector3(length, high, width),
        //new Vector3(length, 0, width),

        ////back
        //new Vector3(0, high, width),
        //new Vector3(0, high, 0),
        //new Vector3(length, high, 0),
        //  new Vector3(length, high, width),

        ////bottom
        //new Vector3(0, high, 0),
        //new Vector3(0, 0, 0),
        //new Vector3(length, 0, 0),
        //new Vector3(length, high, 0),

        ////left
        //new Vector3(0, high, 0),
        //new Vector3(0, high, width),
        //new Vector3(0, 0, width),
        //new Vector3(0, 0, 0),

        ////right
        //new Vector3(length, 0, 0),
        //new Vector3(length, 0, width),
        //new Vector3(length, high, width),
        //new Vector3(length, high, 0),

        //   };


        //逆时针设置
        mesh.triangles = new int[]
               {
              0,2,1,
              0,3,2,
              4,6,5,
              4,7,6,
              8,10,9,
              8,11,10,
              12,14,13,
              12,15,14,
              16,18,17,
              16,19,18,
              20,22,21,
              20,23,22
               };


     //   法线
        //Vector3[] normals = new Vector3[mesh.vertices.Length];
        //for (int i = 0; i < normals.Length; i++)
        //{
        //    if (i < 4)
        //        normals[i] = Vector3.forward;
        //    if (i >= 4 && i < 8)
        //        normals[i] = Vector3.up;
        //    if (i >= 8 && i < 12)
        //        normals[i] = Vector3.back;
        //    if (i >= 12 && i < 16)
        //        normals[i] = Vector3.down;
        //    if (i >= 16 && i < 20)
        //        normals[i] = Vector3.left;
        //    if (i >= 20 && i < 24)
        //        normals[i] = Vector3.right;
        //}
        //mesh.normals = normals;


        Vector2[] uvs = new Vector2[mesh.vertices.Length];
        for (int i = 0; i < uvs.Length; i += 4)
        {
            //正常贴图
            //uvs[i] = new Vector2(0, 0);
            //uvs[i + 1] = new Vector2(0, 1);
            //uvs[i + 2] = new Vector2(1, 1);
            //uvs[i + 3] = new Vector2(1, 0);
            uvs[i] = new Vector2(1, 0);
            uvs[i + 1] = new Vector2(1, 1);
            uvs[i + 2] = new Vector2(0, 1);
            uvs[i + 3] = new Vector2(0, 0);
            
        }

        mesh.uv = uvs;
    }

}