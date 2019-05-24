using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// 判断鼠标是都点击的UI还是3d物体
    /// </summary>
    public bool IsMousePointUI
    {
        get
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// 隐藏
    /// </summary>
    /// <param name="go"></param>
    public void UIHide(GameObject go)
    {
        if (go.activeInHierarchy)
        {
            go.SetActive(false);
        }
    }

    /// <summary>
    /// 显示
    /// </summary>
    public void UIShow(GameObject go)
    {
        if (!go.activeInHierarchy)
        {
            go.SetActive(true);
        }
    }

    public int indexServer = -1;
    public GameObject[] serverObjArray;
    public GameObject serverPanel;

    public void SetServerArray(GameObject[] serverArr)
    {

        serverObjArray = new GameObject[serverArr.Length];
        for (int i = 0; i < serverArr.Length; i++)
        {
            serverObjArray[i] = serverArr[i];
        }
        SetIndexServer(serverArr);
    }

    public void SetIndexServer(GameObject[] serverArr)
    {
        indexServer = -1;
        for (int i = 0; i < serverArr.Length; i++)
        {
            if (serverArr[i].activeSelf)
            {
                indexServer++;
            }
        }
    }

    public void SetAddServer()
    {
        if (indexServer >= serverObjArray.Length - 1)
            return;
        indexServer++;
        serverObjArray[indexServer].SetActive(true);
        if (indexServer >= serverObjArray.Length - 1)
        {
            indexServer = serverObjArray.Length - 1;
        }

    }

    public void SetRemoveServer()
    {
        if (indexServer <= 0)
        {
            indexServer = 0;
        }
        serverObjArray[indexServer].SetActive(false);
        indexServer--;
    }


}
