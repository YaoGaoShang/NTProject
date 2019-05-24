// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-13 13:34:41
// 版 本：1.0
// ========================================================
using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class quad : MonoBehaviour
{

    void Start()
    {
        creatPolygon();
    }

    public GameObject sphere;
    private void creatPolygon()
    {
        /* 1. 顶点，三角形，法线，uv坐标, 绝对必要的部分只有顶点和三角形。  
              如果模型中不需要场景中的光照，那么就不需要法线。如果模型不需要贴材质，那么就不需要UV */
        Vector3[] vertices =
        {
         new Vector3 (2f,0,0),
         new Vector3(4f, 0, 0),
         new Vector3(6f, 0, 0),
         new Vector3(10f, 0, 0),
         new Vector3(10f, 20f, 0),
         new Vector3(6f,10f, 0),
         new Vector3(4f, 4f, 0)

        };
        for (int i = 0; i < vertices.Length; i++)
        {
            GameObject obj = Instantiate(sphere);
            obj.name = "顶点" + i.ToString();
            obj.transform.position = vertices[i];
        }
        print("11111");
        Vector3[] normals =
        {
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up

        };

        Vector2[] uv =
        {
            Vector2.zero,
            -Vector2.left,
            Vector2.one,
            Vector2.right,
            Vector2.zero,
            -Vector2.left,
            Vector2.one

        };
        /*2. 三角形,顶点索引：  
         三角形是由3个整数确定的，各个整数就是角的顶点的index。 各个三角形的顶点的顺序通常由下往上数， 可以是顺时针也可以是逆时针，这通常取决于我们从哪个方向看三角形。 通常，当mesh渲染时，"逆时针" 的面会被挡掉。 我们希望保证顺时针的面与法线的主向一致 */
        int[] indices = new int[15];
        indices[0] = 0;
        indices[1] = 6;
        indices[2] = 1;

        indices[3] = 6;
        indices[4] = 5;
        indices[5] = 1;

        indices[6] = 5;
        indices[7] = 2;
        indices[8] = 1;

        indices[9] = 5;
        indices[10] = 4;
        indices[11] = 2;

        indices[12] = 4;
        indices[13] = 3;
        indices[14] = 2;
        //int numberOfTriangles = vertices.Length - 2;//三角形的数量等于顶点数减2
        //int[] indices = new int[numberOfTriangles * 3];//triangles数组大小等于三角形数量乘3 此时是15
        //int f = 0, b = vertices.Length - 1;//f记录前半部分遍历位置，b记录后半部分遍历位置 即0-7
        //for (int i = 1; i <= numberOfTriangles; i++)//每次给 triangles数组中的三个元素赋值，共赋值
        //{ //numberOfTriangles次
        //    if (i % 2 == 1)
        //    {
        //        indices[3 * i - 3] = f++;
        //        indices[3 * i - 2] = f;
        //        indices[3 * i - 1] = b;//正向赋值，对于i=1赋值为：0,1,2
        //    }
        //    else
        //    {
        //        indices[3 * i - 1] = b--;
        //        indices[3 * i - 2] = b;
        //        indices[3 * i - 3] = f;//逆向赋值，对于i=2赋值为：1,5,6
        //    }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uv;
        mesh.triangles = indices;

        MeshFilter meshfilter = this.gameObject.GetComponent<MeshFilter>();
        meshfilter.mesh = mesh;
        print("1111222");

    }

}