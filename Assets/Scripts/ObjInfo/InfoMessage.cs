using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InfoMessage : MonoBehaviour
{
    public Info info;
    public ServerIfo serverInfo;
    new public string name = null;
    public string[] strName;
    public bool isFlag = true;//区分是服务器还是机柜true=机柜  、
    public component componentWeb;
    string id;
    public MeshRenderer[] meshRenderer;
    public Material material;
    private void Awake()
    {
        id = Guid.NewGuid().ToString();
        InitData("web");
        PushGoodObj();
        name = gameObject.name;
        strName = name.Split('(');
        name = strName[0];
        info = new Info();
        serverInfo = new ServerIfo();
        meshRenderer = GetComponentsInChildren<MeshRenderer>();
        material = Resources.Load<Material>("Materials/Aphla");

    }
    void Start()
    {
        for (int i = 0; i < TotalInfoShow.Instance.jsonServerObj.objInfo.Count; i++)
        {
            if (TotalInfoShow.Instance.jsonServerObj.objInfo[i].name.Equals(name))
            {
                info = TotalInfoShow.Instance.jsonServerObj.objInfo[i];
                isFlag = true;
            }
        }
        for (int i = 0; i < TotalInfoShow.Instance.jsonServerObj.objServerInfo.Count; i++)
        {
            if (TotalInfoShow.Instance.jsonServerObj.objServerInfo[i].name.Equals(name))
            {
                serverInfo = TotalInfoShow.Instance.jsonServerObj.objServerInfo[i];
                isFlag = false;
            }
        }
    }

    /// <summary>
    /// 双击显示物体信息
    /// </summary>
    private void OnMouseDown()
    {
        if (TapCountDouble() && SceneManager.GetActiveScene().name.Equals(SceneName.newPreviewScene) && !IsMousePointUI)//在预览场景才可以双击显示信息
        {
            if (isFlag)
                TotalInfoShow.Instance.SetInfo(info);
            else
                TotalInfoShow.Instance.SetInfo(serverInfo);
            if (!TotalInfoShow.Instance.infoMessagePanel.activeInHierarchy)
            {
                TotalInfoShow.Instance.infoMessagePanel.SetActive(true);
            }
        }
    }


    #region TapCountDouble

    //void TapCountDouble()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (Time.realtimeSinceStartup - lastKickTime < 0.3f)
    //        {
    //            Debug.Log("双击" + name);
    //            //  InfoShow.Instance.info = info;
    //            InfoShow.Instance.SetInfo(info);
    //            if (!InfoShow.Instance.infoMessagePanel.activeInHierarchy)
    //            {
    //                InfoShow.Instance.infoMessagePanel.SetActive(true);
    //            }
    //        }
    //        lastKickTime = Time.realtimeSinceStartup;
    //    }
    //}
    #endregion
    float lastKickTime;
    bool TapCountDouble()
    {
        bool isDouble = false;
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.realtimeSinceStartup - lastKickTime < 0.3f)
            {
                isDouble = true;
            }
        }
        lastKickTime = Time.realtimeSinceStartup;
        return isDouble;
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
    /// web 的 储存
    /// </summary>
    /// <param name="web"></param>
    public void InitData(string web)
    {
        componentWeb = new component();
        componentWeb.pos = new xyz();
        componentWeb.scale = new xyz();
        componentWeb.rotation = new xyzw();
        componentWeb.name = gameObject.name;
        componentWeb.id = id;

        componentWeb.pos.x = transform.position.x;
        componentWeb.pos.y = transform.position.y;
        componentWeb.pos.z = transform.position.z;

        componentWeb.scale.x = transform.localScale.x;
        componentWeb.scale.y = transform.localScale.y;
        componentWeb.scale.z = transform.localScale.z;

        componentWeb.rotation.x = transform.rotation.x;
        componentWeb.rotation.y = transform.rotation.y;
        componentWeb.rotation.z = transform.rotation.z;
        componentWeb.rotation.w = transform.rotation.w;

    }

    public string nowName = "";
    public void PushGoodObj()
    {
        if (!GoodArrayList.Instance.goodObj.Contains(this))
        {
            // 机柜(Clone)(Clone)
            nowName = gameObject.name;
            if (nowName.Length >= 15)
                GoodArrayList.Instance.goodObj.Add(this);
        }
    }


    public void PushGoodsList(int index)
    {
        //  if (!GoodArrayList.Instance.goodsListWeb.Contains(componentWeb))
        // GoodArrayList.Instance.goodsListWeb.Add(componentWeb);
        GoodArrayList.Instance.goodsListWeb[index] = componentWeb;
    }

    /// <summary>
    /// web 的 加载数据
    /// </summary>
    /// <param name="web"></param>
    public void LoadData(string web)
    {
        gameObject.name = componentWeb.name;
        transform.position = new Vector3(componentWeb.pos.x, componentWeb.pos.y, componentWeb.pos.z);
        transform.localScale = new Vector3(componentWeb.scale.x, componentWeb.scale.y, componentWeb.scale.z);
        transform.rotation = new Quaternion(componentWeb.rotation.x, componentWeb.rotation.y, componentWeb.rotation.z, componentWeb.rotation.w);
    }

    /// <summary>
    /// 设置 透明度
    /// </summary>
    public void SetAp()
    {
        for (int i = 0; i < meshRenderer.Length; i++)
        {
            meshRenderer[i].material = material;
        }
    }
}
