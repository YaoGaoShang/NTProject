// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-23 18:04:55
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveMeshStream : MonoBehaviour
{


    void Start()
    {
        //  ObjExporter.MeshToFile(gameObject.GetComponent <MeshFilter>(), " Assets/ ExportedObj/wall.fbx", 1);
        MeshTest.CreatMesh(Application.dataPath+"/MMM/","Wall.fbx",gameObject.GetComponent <MeshFilter >().mesh);
    }






}
