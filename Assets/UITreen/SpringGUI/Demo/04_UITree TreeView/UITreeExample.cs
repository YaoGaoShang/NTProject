
/*=========================================
* Author: springDong
* Description: SpringGUI.UITree example
==========================================*/

using UnityEngine;
using System.Collections.Generic;
using SpringGUI;

public class UITreeExample : MonoBehaviour
{
    public UITree UITree = null;

    public void Awake()
    {
        var data = new UITreeData("工具栏", new List<UITreeData>()
        {
            new UITreeData("交换机 ",new List<UITreeData>()
            {
                new UITreeData("交换机"),
            }),
          //  new UITreeData("Pie"),
          //  new UITreeData("DatePicker"),
            new UITreeData("机柜 ",new List<UITreeData>()
            {
              //  new UITreeData("high-level syntax",new List<UITreeData>()
             //   {
                    //new UITreeData("Action",new List<UITreeData>()
                    //    {
                    //        new UITreeData("One parameter"),
                    //        new UITreeData("Two parameter"),
                    //        new UITreeData("Three parameter"),
                    //        new UITreeData("Four parameter"),
                    //        new UITreeData("Five parameter")
                    //    }),
                 //   new UITreeData("冰箱"),
                    new UITreeData("机柜"),
               // }),
               // new UITreeData("Reflect")
            }),
               new UITreeData("空调  ",new List<UITreeData>()
            {
                new UITreeData("空调"),
            })  ,
               new UITreeData("服务器  ",new List<UITreeData>()
            {
                new UITreeData("服务器"),
            })
        });
        //UITree.SetData(data);
        UITree.Inject(data);
    }
}