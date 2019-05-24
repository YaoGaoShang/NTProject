using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_LineCon : MonoBehaviour
{

    [Header("lineRenderer中的第一个点")]
    public Vector3 v_pos1;
    [Header("LineRenderer中的第二个点"), Space(5)]
    public Vector3 v_pos2;

    public LineRenderer line;

    [Space(10), Header("两个子物体，判定lineRenderer两端的坐标")]
    public LineType t_Pos1;
    public LineType t_Pos2;


    public LineRenderer line_Dot;

    public new_Wall new_wall;

    void Start()
    {
        ////代码获得LineRenderer 的两端的物体
        if (t_Pos1 == null)
            t_Pos1 = transform.GetChild(0).GetComponent<LineType>();
        if (t_Pos2 == null)
            t_Pos2 = transform.GetChild(1).GetComponent<LineType>();
        ////获得 LineRenderer的左右坐标
        line = gameObject.GetComponent<LineRenderer>();      
    }
    #region 设置  hit  点
    /// <summary>
    /// 获得 LineRenderer的左右坐标
    /// </summary>
    public void SetLinePos(int index0, int index1)
    {
        v_pos1 = line.GetPosition(index0);
        v_pos2 = line.GetPosition(index1);
    }


    /// <summary>
    /// 设置第一个点的位置
    /// </summary>
    public void SetLinePos1()
    {
        v_pos1 = line.GetPosition(0);
    }
    /// <summary>
    /// 设置第二个点的位置
    /// </summary>
    public void SetLinePos2()
    {
        v_pos2 = line.GetPosition(1);
    }
    #endregion
    /// <summary>
    /// 设置子物体下面point1的位置
    /// </summary>
    public void SetPos1()
    {
        // t_Pos1.position = v_pos1;
        t_Pos1.SetMySelfPos(v_pos1);
    }
    public void SetPosT1()
    {
        t_Pos1.SetMySelfPos(t_Pos1.UniquenessDot().position);
        line.SetPosition(0, t_Pos1.UniquenessDot().position);
    }

    /// <summary>
    /// 设置子物体下面point2的位置
    /// </summary>
    public void SetPos2()
    {
        //   t_Pos2.position = v_pos2;
        t_Pos2.SetMySelfPos(v_pos2);
    }

    public void SetPosT2()
    {
        t_Pos2.SetMySelfPos(t_Pos2.UniquenessDot().position);//设置 point的位置
        line.SetPosition(1, t_Pos2.UniquenessDot().position);//设置 lineRenderer的  SetPosition
    }



    /// <summary>
    /// 寻找符合吸附点
    /// </summary>
    public void AddDotPoint1()
    {
        t_Pos1.AddDot();
        t_Pos1.ADDM();
    }

    /// <summary>
    /// 寻找符合吸附点
    /// </summary>
    public void AddDotPoint2()
    {
        t_Pos2.AddDot();
        t_Pos2.ADDM();
    }

    public float dis;
    /// <summary>
    /// 计算出两点之间的距离
    /// </summary>
    /// <returns></returns>
    public float Point1ToPoint2Length()
    {
        float dis = Vector3.Distance(v_pos1, v_pos2);
        return dis;
    }

    /// <summary>
    /// 设置 小圆点
    /// </summary>
    public void SetDot()
    {
        //设置lineRenderer开头的小原点
        line_Dot.SetPosition(0, t_Pos1.UniquenessDot().position);
        line_Dot.SetPosition(1, t_Pos1.UniquenessDot().position);
    }

    /// <summary>
    /// 创建出 wall
    /// </summary>
    /// <param name="wallType"></param>
    /// <param name="length"></param>
    /// <param name="width"></param>
    /// <param name="high"></param>
    public void createWall( float length, float width, float high = 2.5f, WallType wallType = WallType.left_Bottom)
    {
       // new_wall.gameObject.transform.position = t_Pos1.gameObject.transform.position;
        new_wall.gameObject.transform.LookAt(t_Pos2.gameObject.transform.position);
        wallType = new_wall.wallType;
        float dis = Vector3.Distance(t_Pos1.transform.position,t_Pos2.transform.position);
        new_wall.Length = length;
        new_wall.Width = dis;
        new_wall.Heigth = high;
        new_wall.wallType = wallType;
        new_wall.gameObject.SetActive(true);
    }

}



