using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteObj : MonoBehaviour
{
    #region Test
    //  string url = "http://139.224.193.145:1111/meeting";
    // void Start()
    //   {
    //  StartCoroutine(DownFile(url));
    //  }
    //IEnumerator DownFile(string url)
    //{
    //    WWW www = new WWW(url);
    //    yield return www;
    //    if (www.isDone)
    //    {            
    //        string str = www.text;
    //        print(str);
    //    }
    //}
    #endregion

    public GameObject currentObj;
    public GameObject panel_Delete;
    public Button btn_Delete;
    //GoodArrayList.Instance.goodObj[i].InitData();
    private void Start()
    {
        btn_Delete.onClick.AddListener(Btn_Con);
    }
    public LayerMask _dragLayerMask;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 1000f, _dragLayerMask))
            {
                currentObj = hitinfo.transform.gameObject;
                //删除面板重置位置
                panel_Delete.transform.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x + (panel_Delete.transform.GetComponent<RectTransform>().sizeDelta.x / 2),
            Input.mousePosition.y - (panel_Delete.transform.GetComponent<RectTransform>().sizeDelta.y / 2)
            , 0);
            }
            else
                currentObj = null;
        }
        //当鼠标左键点击的不是UI的时候，就把currentObj 设置为null
        if (!IsMousePointUI && currentObj != null)
        {
            currentObj = null;
        }
        panel_Delete.SetActive(currentObj != null);//删除面板的  显示和隐藏
    }

    /// <summary>
    /// 删除模型按钮事件
    /// </summary>
    public void Btn_Con()
    {
        if (currentObj != null)//如果需要删除的临时对象不为null，也即有删除的目标
            if (GoodArrayList.Instance.goodObj.Contains(currentObj.GetComponent<InfoMessage>()))
            {
                GoodArrayList.Instance.goodObj.Remove(currentObj.GetComponent<InfoMessage>());
                currentObj.GetComponent<InfoMessage>().gameObject.SetActive(false);//将删除的对象隐藏，  destory 也行
                currentObj = null;  //吧临时需要删除的对象设为null
            }
    }

    /// <summary>
    /// 判断鼠标是都点击的UI还是3d物体
    /// </summary>
    public bool IsMousePointUI
    {
        get
        {
            if (Input.GetMouseButtonUp(0))//当鼠标抬起的时候
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return false;
                }
            }
            return true;
        }
    }

}
