using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class UIClass
{
    public string str_Name;
    public Button[] btn_Level1Array;
    public Button[] btn_Leve2Array;
    public Button[] btn_Level3Array;
}
public class new_UIClass : MonoBehaviour
{
    [Space(3), Header("主按钮")]
    public GameObject obj_MySelf;
    public Button btn_MySelf;
    public string str_Name;

    [Space(3)]
    private UIClass uiClass;
    [Space(3), Header("一级菜单")]
    public Button[] btn_Level1Array;
    [Space(3), Header("二级菜单")]
    public Button[] btn_Leve2Array;
    [Space(3), Header("二级菜单")]
    public Button[] btn_Level3Array;

    /// <summary>
    /// 按钮是否变颜色
    /// </summary>
    //  public bool isClickColor = false;


    void Start()
    {
        uiClass = new UIClass();
        if (obj_MySelf == null)
            obj_MySelf = this.gameObject;

        btn_MySelf = obj_MySelf.GetComponent<Button>();
        btn_MySelf.onClick.AddListener(Btn_MySelf);

        str_Name = obj_MySelf.transform.GetChild(0).GetComponent<Text>().text;
        uiClass.str_Name = str_Name;
        uiClass.btn_Level1Array = btn_Level1Array;
        uiClass.btn_Leve2Array = btn_Leve2Array;
        uiClass.btn_Level3Array = btn_Level3Array;

    }

    /// <summary>
    /// 自己按钮事件
    /// </summary>
    private void Btn_MySelf()
    {
        if (new_UIMedditor.Instance.uiClass != uiClass && new_UIMedditor.Instance.uiClass != null)
        {
            new_UIMedditor.Instance.oldUiClass = new_UIMedditor.Instance.uiClass;
            new_UIMedditor.Instance.ClearOldUIClassItem();
        }
        new_UIMedditor.Instance.uiClass = uiClass;
        new_UIMedditor.Instance.SetTxtGoodsType();
        new_UIMedditor.Instance.new_DropDown.dropDown.value = 0;
        new_UIMedditor.Instance.ShowUIItem(0);
        new_UIMedditor.Instance.SetBtnColor(this.GetComponent<Image>());
    }

}
