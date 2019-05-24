/*此脚本挂载 被旋转的物体上
 * 
 * */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
[DisallowMultipleComponent]
public class SmoothMouseLook : MonoBehaviour
{

    private static SmoothMouseLook instance;
    public static SmoothMouseLook Instance
    {
        get { return instance; }
    }

    public Vector3 pos;
    public Vector3 rotation;

    public Vector3 newPos;
    public Vector3 newRotation;
    public float sensitivity = 4.0f;
    [HideInInspector]
    public float sensitivityAmt = 4.0f;//actual sensitivity modified by IronSights Script

    private float minimumX = -360f;
    private float maximumX = 360f;

    private float minimumY = -85f;
    private float maximumY = 85f;
    [HideInInspector]
    public float rotationX = 0.0f;
    [HideInInspector]
    public float rotationY = 0.0f;
    [HideInInspector]
    public float inputY = 0.0f;

    public float smoothSpeed = 0.35f;

    private Quaternion originalRotation;
    private Transform myTransform;
    [HideInInspector]
    public float recoilX;//non recovering recoil amount managed by WeaponKick function of WeaponBehavior.cs
    [HideInInspector]
    public float recoilY;//non recovering recoil amount managed by WeaponKick function of WeaponBehavior.cs

    [Header("Server")]
    public GameObject serverPanel;

    private void Awake()
    {
        instance = this;
        pos = transform.position;
        rotation = transform.eulerAngles;
    }
    /// <summary>
    ///恢复模型的 初始位置
    /// </summary>
    public void SetModelPos()
    {
        transform.position = pos;
        transform.eulerAngles = rotation;
    }
    /// <summary>
    /// 保存场景模型的旋转位置
    /// </summary>
    public void SetModelSaveNewPos()
    {
        newPos = transform.position;
        newRotation = transform.eulerAngles;
    }
    /// <summary>
    /// 当鼠标点击门的时候关闭门的时候，  把场景的model  变为旋转的位置
    /// </summary>
    public void SetModelRestNewPos()
    {
        transform.position = newPos;
        transform.eulerAngles = newRotation;
    }
    void Start()
    {
        myTransform = transform;//cache transform for efficiency

        originalRotation = myTransform.localRotation;
        //sync the initial rotation of the main camera to the y rotation set in editor
        Vector3 tempRotation = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        originalRotation.eulerAngles = tempRotation;

        sensitivityAmt = sensitivity;//initialize sensitivity amount from var set by player

        // Hide the cursor
        Cursor.visible = true;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals(SceneName.newEditorScene))
            return;
        if (serverPanel.activeInHierarchy)
            return;
        if (Time.timeScale > 0 && Time.deltaTime > 0)
        {//allow pausing by setting timescale to 0

            // Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Read the mouse input axis
            if (Input.GetMouseButton(0))
                rotationX -= Input.GetAxisRaw("Mouse X") * sensitivityAmt * Time.timeScale;//lower sensitivity at slower time settings
                                                                                           //   rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityAmt * Time.timeScale;

            //reset vertical recoilY value if it would exceed maximumY amount 
            //  if (maximumY - Input.GetAxisRaw("Mouse Y") * sensitivityAmt * Time.timeScale < recoilY)
            //    {
            //     rotationY += recoilY;
            //      recoilY = 0.0f;
            //     }

            //reset horizontal recoilX value if it would exceed maximumX amount 
            if (maximumX - Input.GetAxisRaw("Mouse X") * sensitivityAmt * Time.timeScale < recoilX)
            {
                rotationX += recoilX;
                recoilX = 0.0f;
            }

            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY - recoilY, maximumY - recoilY);

            inputY = rotationY + recoilY;//set public inputY value for use in other scripts

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX + recoilX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY + recoilY, -Vector3.right);

            //smooth the mouse input
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, originalRotation * xQuaternion * yQuaternion, smoothSpeed * Time.smoothDeltaTime * 60 / Time.timeScale);
            //lock mouselook roll to prevent gun rotating with fast mouse movements
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.eulerAngles.x, myTransform.rotation.eulerAngles.y, 0.0f);

        }
        else
        {
            //Show the cursor
            // Screen.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    //function used to limit angles
    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }

}