using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SaveJG : MonoBehaviour
{
    public GameDataManager gameDataManager;
    /// <summary>
    /// web  存储
    /// </summary>
    /// <param name="web"></param>
    public void Save(string web)
    {
        GoodArrayList.Instance.goodsListWeb = new component[GoodArrayList.Instance.goodObj.Count];
        //根据  goodObj  来决定  goodsList
        for (int i = 0; i < GoodArrayList.Instance.goodObj.Count; i++)
        {
            GoodArrayList.Instance.goodObj[i].InitData("web");
            GoodArrayList.Instance.goodObj[i].PushGoodsList(i);
        }
        gameDataManager.gaoshanWeb.goodsList = new component[GoodArrayList.Instance.goodsListWeb.Length];
        gameDataManager.gaoshanWeb.goodsList = GoodArrayList.Instance.goodsListWeb;//吧  goodsList  赋值给  gameDataManager的  goodsList

    }

    /// <summary>
    /// web load
    /// </summary>
    /// <param name="web"></param>
    public void Load(string web)
    {
        string name;
        string[] strName;   
        for (int i = 0; i < gameDataManager.goodsArray.Length; i++) 
        {
            name = gameDataManager.goodsArray[i].name;

            strName = name.Split('(');
            name = strName[0];
            GameObject go = Instantiate(Resources.Load<GameObject>("Cabinet/" + name));
            InfoMessage objJG = go.GetComponent<InfoMessage>();
            objJG.componentWeb = gameDataManager.goodsArray[i];
            objJG.LoadData("web");
        }
    }
}
