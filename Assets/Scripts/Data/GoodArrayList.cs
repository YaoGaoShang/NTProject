using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodArrayList : MonoBehaviour
{

    private static GoodArrayList _instance;
    public static GoodArrayList Instance
    {
        get { return _instance; }
    }


    public component[] goodsListWeb;
    public List<InfoMessage> goodObj;
    private void Awake()
    {

        goodObj = new List<InfoMessage>();
        goodsListWeb = new component[goodObj.Count];
        _instance = this;
    }
}
