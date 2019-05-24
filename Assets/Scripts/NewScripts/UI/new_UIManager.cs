using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class new_UIManager : MonoBehaviour
{
    private static new_UIManager _instace;
    public static new_UIManager Instance
    {
        get { return _instace; }
    }

    private void Awake()
    {
        _instace = this;
    }

    /// <summary>
    /// 查找某个物体下面的已知道物体名字的物体
    /// </summary>
    /// <param name="objParent"></param>
    /// <param name="objName"></param>
    /// <returns></returns>
    public Transform FindChild(Transform objParent, string objName)
    {
        Transform go = objParent.Find(objName);
        if (go != null)
            return go;
        for (int i = 0; i < objParent.childCount; i++)
        {
            Transform tempParent = objParent.GetChild(i);
            go = FindChild(tempParent, objName);
            if (go != null)
                return go;
        }
        return null;
    }
}
