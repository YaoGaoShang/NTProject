using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MethTest : MonoBehaviour
{

    public Vector3[] vertices = null;   //顶点取样个数
    public Color[] colors = null;//每个定点对应的颜色 会自动进行插值
    private int[] m_yellow = { 10, 11, 12, 13, 17, 18, 19, 20, 21, 22, 25, 26, 27, 28, 29, 30, 34, 35, 36, 37 };
    private int[] m_blue = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 16, 24, 32, 40, 41, 42, 43, 44, 45, 46, 47 };
    private int[] m_Red = { 18, 19, 20, 21, 26, 27, 28, 29 };

    public Transform[] jigui_s;
    [Space (5),Header ("温度")]
    public float Wendu = 50;//设置温度
    private float time = 2;

    //定义行和列
    public int hang;
    public int lie;
    //行和列的间距
    public float hjj;



    //定义三角形定点数的数组 
    public int[] triangles = null;



    void Start()
    {
        DelegeteToUpdate();
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 2;
            DelegeteToUpdate();
        }

    }
    List<GameObject> jigui_Name = new List<GameObject>();
    List<Vector3> list_pos = new List<Vector3>();
    void DelegeteToUpdate()
    {
        //   List<GameObject> jigui_Name = new List<GameObject>();
        //  List<Vector3> list_pos = new List<Vector3>();
        //获取所有机柜的坐标保存到list集合中
        foreach (Transform item in jigui_s)
        {
            Vector3 jigui_pos = item.transform.position;
            list_pos.Add(jigui_pos);
        }


        int tCount = 0;
        //三角形数量
        int triangleCount = hang * 2 * lie;
        //三角形顶点数量
        int triangleCountPoint = hang * 2 * lie * 3;

        vertices = new Vector3[(hang + 1) * (lie + 1)];
        triangles = new int[triangleCountPoint];//三角形的定点索引
        colors = new Color[(hang + 1) * (lie + 1)];

        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
        Shader shader = Shader.Find("Sprites/Default");
        render.material = new Material(shader);
        filter.mesh = new Mesh();
        Mesh mesh = filter.mesh;

        //全部画在第一象限

        for (int i = hang; i >= 0; i--)
        {
            for (int j = 0; j <= lie; j++)
            {

                vertices[tCount] = new Vector3(j * hjj, 0, i * hjj);
                tCount++;

            }
        }

        int point = 0;

        for (int i = 0; i < hang; i++)
        {
            for (int j = 0; j < lie; j++)
            {
                triangles[point++] = i * (lie + 1) + j;
                triangles[point] = i * (lie + 1) + j + 1;
                int a = triangles[point++];
                triangles[point] = a + lie;
                int b = triangles[point++];
                triangles[point++] = a;
                triangles[point++] = b;
                triangles[point++] = b + 1;

            }
        }

        //遍历将机柜添加到集合中
        foreach (Transform item in jigui_s)
        {
            jigui_Name.Add(item.gameObject);
            //int jigui_id = item.GetComponent<JiGui>().id;
        }

        //设置基本色（绿色）
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.green;
        }
        //遍历改变黄色区域
        foreach (int item in m_yellow)
        {
          //  colors[item] = Color.yellow;
        }
        //遍历改变蓝色区域
        foreach (int item in m_blue)
        {
          //  colors[item] = Color.blue;
        }


        //判断机柜ID，根据ID动态改变红色点位
        foreach (GameObject jigui_obj in jigui_Name)
        {
            int cap = Random.Range(30, 70);//jigui_obj.GetComponent<JiGui>().otherinfo.AvailableCapacity;

            // int id = jigui_obj.GetComponent<JiGui>().id;


            if (cap >= Wendu)
            {
                foreach (Vector3 v3 in list_pos)
                {
                    if (v3.z > -0.9 && v3.z < 0.9)
                    {
                        if (v3.x <= -5.4)
                        {
                            colors[18] = Color.red;
                        }
                        if (v3.x > -5.4 && v3.x <= -3.6)
                        {
                            colors[19] = Color.red;
                        }
                        if (v3.x > -3.6 && v3.x <= -1.8)
                        {
                            colors[20] = Color.red;
                        }
                        if (v3.x <= 0 && v3.x > -1.8)
                        {
                            colors[21] = Color.red;
                        }
                    }
                    else
                    {
                        if (v3.x <= -5.4)
                        {
                            colors[26] = Color.red;
                        }
                        if (v3.x > -5.4 && v3.x <= -3.6)
                        {
                            colors[27] = Color.red;
                        }
                        if (v3.x > -3.6 && v3.x <= -1.8)
                        {
                            colors[28] = Color.red;
                        }
                        if (v3.x <= 0)
                        {
                            colors[29] = Color.red;
                        }
                    }





                }
            }
        }


        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
    }
}

