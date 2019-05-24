using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class new_UIMedditor : MonoBehaviour
{
    /// <summary>
    /// 单利
    /// </summary>
    private static new_UIMedditor _instance;
    public static new_UIMedditor Instance
    {
        get { return _instance; }
    }
    public UIClass uiClass;
    public UIClass oldUiClass;
    public new_DropDown new_DropDown;
    [Space(3), Header("DropDown前面的设备类型")]
    public Text txt_GoodsType;

    public Image oldImage;
    public Image newImage;
    [Header("要改变的颜色")]
    public Color color;
    [Header("原来自己的颜色")]
    public Color oldColor;

    private void Awake()
    {
        _instance = this;
        //  txt_GoodsType.text = "";
    }

    /// <summary>
    /// 显示第几类UIITem
    /// </summary>
    /// <param name="index"></param>
    public void ShowUIItem(int index)
    {
        Button[] array0 = uiClass.btn_Level1Array;
        Button[] array1 = uiClass.btn_Leve2Array;
        Button[] array2 = uiClass.btn_Level3Array;
        switch (index)
        {
            case 0:
                for (int i = 0; i < array0.Length; i++)
                {
                    array0[i].gameObject.SetActive(true);
                }
                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i].gameObject.SetActive(false);
                }
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i].gameObject.SetActive(false);
                }
                break;
            case 1:
                for (int i = 0; i < array0.Length; i++)
                {
                    array0[i].gameObject.SetActive(false);
                }
                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i].gameObject.SetActive(true);
                }
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i].gameObject.SetActive(false);
                }
                break;
            case 2:
                for (int i = 0; i < array0.Length; i++)
                {
                    array0[i].gameObject.SetActive(false);
                }
                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i].gameObject.SetActive(false);
                }
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i].gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }


    /// <summary>
    ///清除之前加载出来的UIItem
    /// </summary>
    public void ClearOldUIClassItem()
    {
        Button[] array0 = oldUiClass.btn_Level1Array;
        Button[] array1 = oldUiClass.btn_Leve2Array;
        Button[] array2 = oldUiClass.btn_Level3Array;
        for (int i = 0; i < array0.Length; i++)
        {
            array0[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < array1.Length; i++)
        {
            array1[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < array2.Length; i++)
        {
            array2[i].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 设置DropDown操作的设备类型
    /// </summary>
    public void SetTxtGoodsType()
    {
        //  txt_GoodsType.text = uiClass.str_Name;
    }

    /// <summary>
    /// 设置按钮颜色
    /// </summary>
    /// <param name="image"></param>
    public void SetBtnColor(Image image)
    {
        if (newImage == null)
        {
            newImage = image;
            newImage.color = color;
        }
        if (newImage != null)
        {
            oldImage = newImage;
            oldImage.color = oldColor;
            newImage = image;
            newImage.color = color;
        }

    }
}
