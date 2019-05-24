using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_LineManager : MonoBehaviour
{

    private static New_LineManager instance;

    public static New_LineManager Instance
    {
        get { return instance; }
    }


 //   public List<LineType> lineType = new List<LineType>();
    public List<New_LineCon> lineCon = new List<New_LineCon>();
    private void Awake()
    {
        instance = this;
    }

    public bool IsBiHe()
    {
        if (lineCon.Count < 2)
            return false;
        Transform one = lineCon[0].t_Pos1.t_MyPos;
        Transform two = lineCon[lineCon.Count - 1].t_Pos2.t_MyPos;
        if (one.position == two.position)
            return true;
        return false;
    }

}
