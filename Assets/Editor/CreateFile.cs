using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateFile
{

    [MenuItem("Tools / CreateFolder")]//需要引入命名空间using UnityEditor 
    public static void CreateFolder()
    {
        string path = Application.dataPath + "/";
        Directory.CreateDirectory(path + "Resources");//需要引入命名空间 using System.Io 
        Directory.CreateDirectory(path + "Plugins");
        Directory.CreateDirectory(path + "StreamingAssets");
        Directory.CreateDirectory(path + "Editor");
        Directory.CreateDirectory(path + "Scenes");
        Directory.CreateDirectory(path + "Scripts");
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools / CreateScenes")]
    public static void CreateScenes()
    {
        string path = Application.dataPath + "/";
        Directory.CreateDirectory(path + "Scenes");
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools / CreateScripts")]
    public static void CreateScripts()
    {
        string path = Application.dataPath + "/";
        Directory.CreateDirectory(path + "Scripts");
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools / CreateResources")]
    public static void CreateResources()
    {
        string path = Application.dataPath + "/";
        Directory.CreateDirectory(path + "Resources");
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools / CreateStreamingAssets")]
    public static void CreateStreamingAssets()
    {
        //string path = Application.dataPath + "/";
        //Directory.CreateDirectory(path + "StreamingAssets");
        //AssetDatabase.Refresh();
        SetPath("StreamingAssets");
    }
    [MenuItem("Tools / CreatePrefabs")]
    public static void CreateCreatePrefabs()
    {

        SetPath("Prefabs");
    }

    static void SetPath(string fileName)
    {
        string path = Application.dataPath + "/";
        Directory.CreateDirectory(path + fileName);
        AssetDatabase.Refresh();
    }
}

