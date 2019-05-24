using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineType : MonoBehaviour, IPoint
{
    /// <summary>
    /// 自身的位置信息
    /// </summary>
    public Transform t_MyPos;


    public LineType otherDotPointControl;
    /// <summary>
    /// 吸附的最小范围
    /// </summary>
    public float minDis = 0.2f;

    void Start()
    {
        if (t_MyPos == null)
            t_MyPos = GetComponent<Transform>();
    }

    public void SetMySelfPos()
    {
        throw new System.NotImplementedException();
    }

    public void SetMySelfPos(Transform t)
    {
        throw new System.NotImplementedException();
    }

    public void SetMySelfPos(Vector3 pos)
    {
        t_MyPos.position = pos;
    }


    public List<LineType> dotList = new List<LineType>();
    /// <summary>
    /// 计算并保存所有的 点
    /// </summary>
    public void AddDot()
    {
        LineType[] dotArray = GameObject.FindObjectsOfType<LineType>();
        for (int i = 0; i < dotArray.Length; i++)
        {
            if (dotArray[i] != this)
            {
                dotList.Add(dotArray[i]);
            }
        }
        dotList.Remove(otherDotPointControl);

    }

    public List<LineType> dotListM = new List<LineType>();
    float f_minDis = 0;
    /// <summary>
    /// 瞒足在范围内的点
    /// </summary>
    public void ADDM()
    {
        for (int i = 0; i < dotList.Count; i++)
        {
            f_minDis = Vector3.Distance(dotList[i].gameObject.transform.position, gameObject.transform.position);
            if (f_minDis < minDis)
            {
                dotListM.Add(dotList[i]);
            }
        }
    }

    /// <summary>
    /// 计算出唯一一个  需要吸附的点
    /// </summary>
    public Transform UniquenessDot()
    {
        //界限  限制
        if (dotListM.Count == 0)
            return gameObject.transform;

        LineType[] dotPointArrayt = new LineType[dotListM.Count];

        for (int i = 0; i < dotListM.Count; i++)
        {
            dotPointArrayt[i] = dotListM[i];
        }
        //界限 限制
        if (dotListM.Count == 1)
            return dotPointArrayt[0].gameObject.transform;
        //冒泡排序返回最近的一个值
        for (int i = 0; i < dotPointArrayt.Length - 1; i++)
        {
            for (int j = 0; j < dotPointArrayt.Length - 1 - i; j++)
            {
                float one = Vector3.Distance(dotPointArrayt[j].gameObject.transform.position, gameObject.transform.position);
                float two = Vector3.Distance(dotPointArrayt[j + 1].gameObject.transform.position, gameObject.transform.position);

                if (one > two)
                {
                    LineType temp = new LineType();
                    temp = dotPointArrayt[j];
                    dotPointArrayt[j] = dotPointArrayt[j + 1];
                    dotPointArrayt[j + 1] = temp;
                }
            }
        }
        return dotPointArrayt[0].gameObject.transform;//返回最近的一个
    }
}
