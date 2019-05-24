// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-14 19:03:08
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 这个代码只会执行一次
/// </summary>
public class DontSestroyManager : MonoBehaviour
{

    private static DontSestroyManager instance;
    public static DontSestroyManager Instance
    { get { return instance; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        
    }
}
