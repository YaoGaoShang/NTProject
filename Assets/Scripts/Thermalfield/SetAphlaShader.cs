using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SetAphlaHandler();

/// <summary>
/// 设置 模型的 热力图
/// </summary>
public class SetAphlaShader : MonoBehaviour
{
    public event SetAphlaHandler EventHandler;
    void Start()
    {
        Init();
    }

    /// <summary>
    /// 设置热力图
    /// </summary>
    public void SetAphla()
    {

        List<InfoMessage> infoMessage = GoodArrayList.Instance.goodObj;
        for (int i = 0; i < infoMessage.Count ; i++)
        {
            infoMessage[i].SetAp();
        }
        print("事件函数被执行了");
    }

    /// <summary>
    /// 执行事件
    /// </summary>
    public void EventStart()
    {
        Init();
        EventHandler();
    }
    /// <summary>
    /// 初始化事件,注册事件
    /// </summary>
    public void Init()
    {
        EventHandler += SetAphla;
    }

    /// <summary>
    /// 注销事件
    /// </summary>
    public void OnDestroy()
    {
        EventHandler -= SetAphla;
    }
    /// <summary>
    /// 查找子物体，不需要写路径，返回值为 物体身上的组件，如果身上没有T类型的组件，就返回为default（T）
    /// </summary>
    /// <param name="objParent"> 父物体</param>
    /// <param name="objName">要查找物体的名字</param>
    /// <returns></returns>
    public static T FindChild<T>(Transform objParent, string objName) where T : Component
    {
        Transform go = objParent.Find(objName);
        if (go != null)
            return go.GetComponent<T>();
        for (int i = 0; i < objParent.childCount; i++)
        {
            Transform tempParent = objParent.GetChild(i);
            go = FindChild<Transform>(tempParent, objName);
            if (go != null)
                return go.GetComponent<T>();
        }
        return default(T);
    }

}
