using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DoorController : MonoBehaviour
{
    public CameraControl mainCamera;

    public GameObject serverPanel;

    public GameObject[] serverObjArray;
    void Start()
    {
        mainCamera = GameObject.FindObjectOfType<CameraControl>();
        PlayDoorAni();
        //    if (SceneManager.GetActiveScene().name.Equals(SceneName.PreviewScene))
        //   serverPanel = UIManager.Instance.serverPanel;

    }
    [Header("旋转角度")]
    public float angleRotation = -160f;
    [Header("动画延迟播放时间")]
    public float delayTime = 0.5f;
    private bool isIn = false;
    void PlayDoorAni()
    {
        Tweener tweener = transform.DOLocalRotate(new Vector3(0, angleRotation, 0), 0.5f, RotateMode.Fast).SetDelay(delayTime).SetLoops(1, LoopType.Incremental);
        tweener.SetAutoKill(false);// 把autokill 自动销毁设置为false
        tweener.Pause();//暂停动画播放
    }


    public void OnMouseDown()
    {
        if (mainCamera == null)
            mainCamera = GameObject.FindObjectOfType<CameraControl>();
        //  if (TapCountDouble() && SceneManager.GetActiveScene().name.Equals(SceneName.PreviewScene) && !UIManager.Instance.IsMousePointUI)
        if (TapCountDouble() && SceneManager.GetActiveScene().name.Equals(SceneName.newPreviewScene) && !IsMousePointUI)
        {
            if (isIn == false)
            {
                SmoothMouseLook.Instance.SetModelSaveNewPos();
                SmoothMouseLook.Instance.SetModelPos();
                transform.DOPlayForward();//前放
                isIn = true;
                serverPanel = UIManager.Instance.serverPanel;
                SetServer(isIn);
                UIManager.Instance.SetServerArray(serverObjArray);
                mainCamera.SetCameraPos(this.transform, -0.2f, 0.2f, -1.7f);

            }
            else
            {
                SmoothMouseLook.Instance.SetModelRestNewPos();
                transform.DOPlayBackwards();//倒放
                isIn = false;
                serverPanel = UIManager.Instance.serverPanel;
                SetServer(isIn);
                ServerControl.Instance.SetAllAni();
                mainCamera.SetCameraPOSRest();
            }
        }
    }

    void SetServer(bool isShow)
    {
        serverPanel.SetActive(isShow);
    }
    #region 双击

    float lastKickTime;
    public bool TapCountDouble()
    {
        bool isDouble = false;
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.realtimeSinceStartup - lastKickTime < 0.3f)
            {
                isDouble = true;
            }
        }
        lastKickTime = Time.realtimeSinceStartup;
        return isDouble;
    }

    #endregion
    /// <summary>
    /// 判断鼠标是都点击的UI还是3d物体
    /// </summary>
    public bool IsMousePointUI
    {
        get
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
