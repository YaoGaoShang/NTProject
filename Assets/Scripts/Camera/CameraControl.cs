using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CameraControl : MonoBehaviour
{
    private static CameraControl _instance;
    public static CameraControl Instance
    {
        get { return _instance; }
    }
    public bool isFlag = true;
    public Camera mainCamera;
    public Vector3 cameraOriginPos;
    public Vector3 cameraRotation;
    [Header("摄像机Z距离")]
    public float cameraZOffset;

    public Text debug_Text;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        //  mainCamera = Camera.main;
        ChangeIsFlag(isFlag);
        cameraOriginPos = mainCamera.transform.position;
        cameraRotation = mainCamera.transform.eulerAngles;
    }
    void Update()
    {

    }
    void ChangeIsFlag(bool isFlag)
    {
        mainCamera.orthographic = isFlag;
    }

    public void ChangeCamera()
    {
        isFlag = !isFlag;
        ChangeIsFlag(isFlag);
    }

    public void ChangeViewerCameraTo2D()
    {
        ChangeIsFlag(true);
    }

    public void ChangeViewerCameraTo3D()
    {
        ChangeIsFlag(false);
    }

    public void GoToYuLanScene()
    {
        DataLoadSaveControl dataLoad = GameObject.FindObjectOfType<DataLoadSaveControl>();
        dataLoad.SaveBtn();

        SceneManager.LoadScene(SceneName.newPreviewScene);
        //跳转到 预览场景
        SceneManager.LoadScene("newNTPreview");
    }

    public void GoToEditorScene()
    {
        //  SceneManager.LoadScene(SceneName.newEditorScene);
        //跳转到编辑场景
        SceneManager.LoadScene("newNT");

    }
    Vector3 pos;
    public void SetCameraPos(Transform targetPos, float x = 0, float y = 0, float z = 0)
    {
        mainCamera.transform.position = new Vector3(targetPos.parent.position.x + x, targetPos.parent.position.y + y, targetPos.parent.position.z + cameraZOffset + z);
        mainCamera.transform.localEulerAngles = new Vector3(targetPos.parent.rotation.x, 0, targetPos.parent.rotation.z);


    }
    public void SetCameraPOSRest()
    {
        mainCamera.transform.position = cameraOriginPos;
        mainCamera.transform.eulerAngles = cameraRotation;
    }


    /// <summary>
    /// 绘制
    /// </summary>
    /// <param name="cad"></param>
    public void Btn_Paint(GameObject cad)
    {
        cad.SetActive(true);
    }

    public GameObject cad;
    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="dataLoadSaveControl"></param>
    public void Btn_LoadData(DataLoadSaveControl dataLoadSaveControl)
    {
        cad.SetActive(false);
        print("加载");
        dataLoadSaveControl.ReadBtn();
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="meshObject"></param>
    public void Btn_SaveScene(GameObject meshObject)
    {
#if UNITY_EDITOR
        //GameObject  go = (GameObject) AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Wall.fbx");


        //if (null != go )
        //{
        //    Debug.Log(AssetDatabase.GetAssetPath(go));
        //    EditorGUIUtility.PingObject(go);//显示黄色的框
        //    AssetDatabase.Refresh();
        //}
#endif
        meshObject = GameObject.Find("Ground");
        GameObject[] meshObjs = new GameObject[1];
        meshObjs[0] = meshObject;
        print("保存");

        FBXExporter.ExportFBX("/Resources", "Wall", meshObjs, true);
    }


}
