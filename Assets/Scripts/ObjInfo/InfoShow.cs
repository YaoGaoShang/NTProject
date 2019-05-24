using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoShow : MonoBehaviour
{

    private static InfoShow _instance;
    public static InfoShow Instance
    {
        get { return _instance; }
    }
    //   public GameObject showObj;
    #region UIInfo
    new public Text name;
    public Text manufacturers;
    public Text number;
    public Text buyTime;
    public Text price;
    public Text ipAddress;
    #endregion

    public Info info;
    public ServerIfo serverInfo=null;
    public JsonObj jsonObj = null;
    public TextAsset objConfig;
    public GameObject infoMessagePanel;
    private void Awake()
    {
        _instance = this;
        if (objConfig == null)
            objConfig = Resources.Load<TextAsset>("ObjConfig/ObjConfig");
        string str = objConfig.ToString();
        jsonObj = JsonUtility.FromJson<JsonObj>(str);
    }

    private void Start()
    {
        info = new Info();
        serverInfo = new ServerIfo();
    }
    public void SetInfo(Info infoTemp)
    {
        this.info = infoTemp;
        name.text = "设备名字:  " + info.name;
        manufacturers.text = "厂商:  " + info.manufacturers;
        number.text = "设备编号:  " + info.number;
        buyTime.text = "购买时间:  " + info.buyTime;
        price.text = "购买价格:  " + info.price;
    }

    public void SetInfo(ServerIfo serverInfoTemp)
    {
        this.serverInfo = serverInfoTemp;
        name.text = "设备名字:  " + serverInfo.name;
        manufacturers.text = "厂商:  " + serverInfo.manufacturers;
        number.text = "设备编号:  " + serverInfo.number;
        buyTime.text = "购买时间:  " + serverInfo.buyTime;
        price.text = "购买价格:  " + serverInfo.price;
        ipAddress.text = "Ip地址: " + serverInfo.ipAddress;
    }

}
