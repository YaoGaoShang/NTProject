using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class new_DropDown : Selectable
{

    [Space(5)]
    public UIClass uiClass;
    public UIClass oldUiClass;

    public Dropdown dropDown;


    new void Start()
    {
        // dropDown.value = 1;
    }
    void Update()
    {

    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        new_UIMedditor.Instance.ShowUIItem(dropDown.value);
    }

}
