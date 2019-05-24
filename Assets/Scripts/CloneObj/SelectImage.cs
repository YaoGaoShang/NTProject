using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectImage : MonoBehaviour, IPointerDownHandler
{
    //需要被实例化的预制
    public GameObject inistatePrefab;
    //实例化后的对象
    private GameObject inistateObj;

    public string str_Name;

    void Start()
    {

        str_Name = transform.GetChild(1).GetComponent<Text>().text;
        try
        {
            inistatePrefab = Resources.Load<GameObject>("Cabinet/" + str_Name);
        }
        catch (System.Exception e)
        {

            print(e.Message);
        }


        if (inistatePrefab == null) return;
        //实例化预制
        inistateObj = Instantiate(inistatePrefab) as GameObject;
      //  inistateObj.name = str_Name;
        inistateObj.SetActive(false);
    }
    //实现鼠标按下的接口
    public void OnPointerDown(PointerEventData eventData)
    {
        if (inistateObj == null) return;
        inistateObj.SetActive(true);
        //将当前需要被实例化的对象传递到管理器中
        SelectObjManager.Instance.AttachNewObject(inistateObj);
    }
}
