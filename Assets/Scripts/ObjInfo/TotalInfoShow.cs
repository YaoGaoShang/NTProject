using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalInfoShow : MonoBehaviour
{

    private static TotalInfoShow _instance;
    public static TotalInfoShow Instance
    {
        get { return _instance; }
    }
    public TextAsset objConfig;
    public JsonServerObj jsonServerObj = null;
    public Info info;
    public ServerIfo serverInfo = null;
    public GameObject infoMessagePanel;

    #region UIInfo
    new public Text name;
    public Text manufacturers;
    public Text number;
    public Text buyTime;
    public Text price;
    public Text ipAddress;

    //  public Text txt_Prefabs;
    #endregion


    private void Awake()
    {
        _instance = this;
        if (objConfig == null)
            objConfig = Resources.Load<TextAsset>("ObjConfig/ObjServerConfig");
        string str = objConfig.ToString();
        jsonServerObj = JsonUtility.FromJson<JsonServerObj>(str);
    }


    public void SetInfo(Info infoTemp)
    {
        this.info = infoTemp;
        name.text = "name:  " + info.name;
        manufacturers.text = "manufacturers:  " + info.manufacturers;
        number.text = "number:  " + info.number;
        buyTime.text = "buyTime:  " + info.buyTime;
        price.text = "price:  " + info.price;
        ipAddress.text = "";
    }

    public void SetInfo(ServerIfo serverInfoTemp)
    {
        this.serverInfo = serverInfoTemp;
        name.text = "name:  " + serverInfo.name;
        manufacturers.text = "manufacturers:  " + serverInfo.manufacturers;
        number.text = "number:  " + serverInfo.number;
        buyTime.text = "buyTime:  " + serverInfo.buyTime;
        price.text = "price:  " + serverInfo.price;
        ipAddress.text = "ipAddress: " + serverInfo.ipAddress;
    }


}
