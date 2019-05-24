using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DataLoadSaveControl : MonoBehaviour
{

    public GameDataManager gameDataManager;
    SaveJG saveJG;
    public Button[] loadSave;
    [Space(8), Header("是否自动加载数据 是=true；否=false")]
    public bool isAuto = true;
    void Start()
    {
        // if (SceneManager.GetActiveScene().name.Equals("newNTPreview"))
        if (!SceneManager.GetActiveScene().name.Equals("newNT"))
            ReadBtn();
    }

    /// <summary>
    /// 当游戏退出的时候  API
    /// </summary>
    private void OnApplicationQuit()
    {
        if (isAuto && SceneManager.GetActiveScene().name.Equals("newNT"))//只有在 编辑场景退出程序的时候 才会保存场景数据
        {
            // print("程序退出 、、、、保存数据、、、");
            //    SaveBtn();
        }
    }


    public void SaveBtn()
    {
        print("保存数据@@@");
        saveJG = gameObject.GetComponent<SaveJG>();
        saveJG.Save("web");
        gameDataManager.Save();
    }

    public void ReadBtn()
    {
        GameObject wall_Temp = Resources.Load<GameObject>("Wall");
        if (wall_Temp != null)
        {
            GameObject exist = GameObject.Find("Ground");
            DestroyImmediate(exist);
            GameObject wall = Instantiate<GameObject>(wall_Temp);
            wall.name = "Ground";
            wall.layer = 9;
       //     wall.AddComponent<BoxCollider>();
            wall.AddComponent<Dotdestroy>();
            MeshRenderer[] wall_Gather = wall.transform.GetComponentsInChildren<MeshRenderer>();
            print(wall_Gather.Length);
            for (int i = 0; i < wall_Gather.Length ; i++)
            {
                wall_Gather[i].gameObject.AddComponent<BoxCollider>(); 
            }
        }

        saveJG = gameObject.GetComponent<SaveJG>();
        saveJG.Load("web");
        InfoMessage[] infoMessageArray = GameObject.FindObjectsOfType<InfoMessage>();
        for (int i = 0; i < infoMessageArray.Length; i++)
        {
            infoMessageArray[i].PushGoodObj();//List<InfoMessage>
        }

        SetObjParent setObj = GameObject.FindObjectOfType<SetObjParent>();
        setObj.SetObjParentEvent();
        SetAphlaShader setAphlaShader = GameObject.FindObjectOfType<SetAphlaShader>();
        if (setAphlaShader != null)
            setAphlaShader.EventStart();
    }

}
