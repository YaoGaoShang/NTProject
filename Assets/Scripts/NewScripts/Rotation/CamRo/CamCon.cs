// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-06 13:41:49
// 版 本：1.0
// ========================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 摄像机 放大的方式
/// </summary>
public enum CameraScaleView
{
    none,
    fileOfView,
    cameraZ
}
public class CamCon : MonoBehaviour
{

    public Transform target;
    public float sentivity;
    private float rotationX;
    private float rotationY;
    public CameraScaleView cameraScaleView = CameraScaleView.none;
    public float fileOfView_min = 5;
    public float fileOfView_max = 40;
    public float fileOfView;


    public Camera cam;
    public bool isClickUI;

    public float cameraZ;




    void Start()
    {
        target = GameObject.Find("Ground").GetComponent<Transform>();
        cam = Camera.main;
        fileOfView = cam.fieldOfView;
        EventCneter.eventSetTarget += SetTarget;
    }

    private void OnDestroy()
    {
        EventCneter.eventSetTarget -= SetTarget;
    }
    private void SetTarget(GameObject target)
    {
        this.target = target.transform;
        cam.transform.LookAt(this.target);
    }


    void Update()
    {

        #region MyRegion

   
        isClickUI = IsClickUI();
        switch (cameraScaleView)
        {
            case CameraScaleView.none:

                break;
            case CameraScaleView.fileOfView:
                fileOfView = Mathf.Clamp(fileOfView, fileOfView_min, fileOfView_max);
                cam.fieldOfView = fileOfView;
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    fileOfView--;
                }

                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    fileOfView++;
                }
                break;
            case CameraScaleView.cameraZ:
                break;
            default:
                break;
        }
        #endregion

        if (Input.GetMouseButtonUp(0))
        {
            isClickUI = false;
        }
        if (IsClickUI())
            return;
        SetRotation();
    }

    void SetRotation()
    {
        if (target == null)//且闭合才能旋转
            return;

        rotationX = 0;
        rotationY = 0;
        if (Input.GetMouseButton(0))
        {
            rotationX -= Input.GetAxisRaw("Mouse X") * sentivity * Time.timeScale * Time.deltaTime;
            rotationY += Input.GetAxisRaw("Mouse Y") * sentivity * Time.timeScale * Time.deltaTime;

            if (Mathf.Abs(rotationX) >= Mathf.Abs(rotationY))
            {
                transform.RotateAround(target.position, Vector3.up, rotationX);
            }
            else
            {
                #region 注释  显示范围
                // transform.RotateAround(target.position, -Vector3.right, rotationY);

                //if (0 < transform.rotation.eulerAngles.x && transform.rotation.eulerAngles.x < 89)
                //   {
                //       transform.RotateAround(target.position, gameObject.transform.right, rotationY);
                //   }
                //   if (270 < transform.rotation.eulerAngles.x && transform.rotation.eulerAngles.x < 360)
                //   {
                //       transform.RotateAround(target.position, gameObject.transform.right, rotationY);
                //   }
                //   if (-5<transform.rotation.eulerAngles.x&& transform.rotation.eulerAngles.x<0)
                //   {
                //       // transform.rotation.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
                //         transform.rotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0);
                //   }
                //   if (89<transform.rotation.eulerAngles.x&& transform.rotation.eulerAngles.x<95)
                //   {
                //       transform.rotation = Quaternion.Euler(89, transform.rotation.eulerAngles.y, 0);

                //   }
                //   if (269 < transform.rotation.eulerAngles.x && transform.rotation.eulerAngles.x < 270)
                //   {
                //       transform.rotation = Quaternion.Euler(270, transform.rotation.eulerAngles.y, 0);

                //   }
                #endregion
                transform.RotateAround(target.position, gameObject.transform.right, rotationY);
            }
        }

        //  transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);
    }

    #region 四元数控制旋转

    public float current_X;
    public float current_Y;
    public float min_X;
    public float max_X;
    public float min_Y;
    public float max_Y;
    void SetRotation(float current_X, float current_Y)
    {
        if (target == null)//且闭合才能旋转
            return;
        if (Input.GetMouseButton(0))
        {
            rotationX -= Input.GetAxisRaw("Mouse X") * sentivity * Time.timeScale * Time.deltaTime;
            rotationY += Input.GetAxisRaw("Mouse Y") * sentivity * Time.timeScale * Time.deltaTime;
            if (Mathf.Abs(rotationX) >= Mathf.Abs(rotationY))
            {
                transform.RotateAround(target.position, Vector3.up, rotationX);
            }
            else
            {
                transform.RotateAround(target.position, gameObject.transform.right, rotationY);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rotationX = 0;
            rotationY = 0;
        }

    //    current_X = transform.eulerAngles.x;
   //     current_X = Mathf.Clamp(current_X, min_X, max_X);

     //   current_Y = transform.eulerAngles.y;
     //   current_Y = Mathf.Clamp(current_Y, min_Y, max_Y);

    //    transform.rotation = Quaternion.Euler(current_X, current_Y, 0);


    }
    #endregion
    /// <summary>
    /// 判断是在3dobj  还是在UI上
    /// </summary>
    /// <returns></returns>
    bool IsClickUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                isClickUI = true;
            }
        }
        return isClickUI;
    }

}
