// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-20 09:14:03
// 版 本：1.0
// ========================================================
using UnityEngine;

public class ExportModel:MonoBehaviour  {


    GameObject meshObject;
    void Start()
    {
        meshObject = this.gameObject;
        GameObject[] meshObjs = new GameObject[1];
        meshObjs[0] = meshObject;
        //用到动态库WRP_FBXExporter
        // FBXExporter.ExportFBX("", "Wall", meshObjs, true);
        FBXExporter.ExportFBX("/Resources", "Wall", meshObjs, true);


    }



}
