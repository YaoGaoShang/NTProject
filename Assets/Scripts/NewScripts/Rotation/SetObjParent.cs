using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjParent : MonoBehaviour
{

    [Space(5), Header("建筑零件的父物体")]
    public Transform parent;


    public void SetObjParentEvent()
    {
        if (parent == null)
            //  parent = GameObject.FindGameObjectWithTag("Build").GetComponent<Transform>();//查找父物体
            parent = GameObject.Find("Ground").GetComponent<Transform>();//查找父物体


            List<InfoMessage> infoMessageObj = GoodArrayList.Instance.goodObj;//获得场景中所有的可编辑对象
        for (int i = 0; i < infoMessageObj.Count; i++)
        {
            infoMessageObj[i].transform.SetParent(parent);//遍历每个对象，为其添加父对象
        }
    }

}
