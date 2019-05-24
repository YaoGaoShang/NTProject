using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

//管理数据储存的类//
public class GameDataManager : MonoBehaviour
{
    [HideInInspector]
    public gaoshang gaoshanWeb;
    [HideInInspector]
    public component[] goodsArray;
    public _3d db;
    /// <summary>
    /// /=['][9LKJHGFD
    /// </summary>
    public void Awake()
    {
        db = new _3d();
         gaoshanWeb = new gaoshang();
        Load();
    }

    //存档时调用的函数//
    public void Save()
    {
        db.Save (gaoshanWeb);
    }




    /// <summary>
    ///   //读档时调用的函数//
    /// </summary>
    public void Load()
    {
         goodsArray = db.Get().goodsList;
    }


}