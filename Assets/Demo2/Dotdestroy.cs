// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-14 17:49:30
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dotdestroy : MonoBehaviour {

    private static Dotdestroy instance;
    public static Dotdestroy Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}