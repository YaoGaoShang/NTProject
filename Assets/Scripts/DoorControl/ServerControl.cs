using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ServerControl : MonoBehaviour
{
    private static ServerControl _instance;
    public static ServerControl Instance
    {
        get { return _instance; }
    }

    public List<ServerManager> serverList = new List<ServerManager>();


   // public GameObject serverObj;

    private void Awake()
    {
        _instance = this;
    }

    public void SetAllAni()
    {
        for (int i = 0; i < serverList.Count; i++)
        {
            if (serverList[i].isClick)
            {
                serverList[i].PlayerBackWards();
                serverList[i].isClick = !serverList[i].isClick;
            }
        }
    }

}
