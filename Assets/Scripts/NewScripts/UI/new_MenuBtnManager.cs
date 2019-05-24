using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class new_MenuBtnManager : MonoBehaviour
{

    public Image[] btn_ImageArray;
    [Header("要改变的颜色")]
    public Color color;
    [Header("原来自己的颜色")]
    public Color oldColor;


    void Start()
    {
        btn_ImageArray = transform.GetComponentsInChildren<Image>();
     //   btn_ImageArray[0].color = color;
    }

    /// <summary>
    /// 设置按钮颜色
    /// </summary>
    public  void SetBtnColor()
    {
     
    }

}
