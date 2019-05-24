using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragObject : MonoBehaviour
{
    public LayerMask _dragLayerMask;
    public Transform currentTransform;
    public bool isDrag = false;
    Vector3 screenPos = Vector3.zero;
    Vector3 offset = Vector3.zero;
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name.Equals(SceneName.newEditorScene))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 1000f, _dragLayerMask))
            {
                isDrag = true;
                currentTransform = hitinfo.transform;
                screenPos = Camera.main.WorldToScreenPoint(currentTransform.position);
                offset = currentTransform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));
            }
            else
            {
                isDrag = false;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (isDrag == true && !IsMousePointUI)
            {

                var currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
                //鼠标的屏幕空间坐标转化为世界坐标，并加上偏移量
                var currentPos = Camera.main.ScreenToWorldPoint(currentScreenPos) + offset;
                currentTransform.position = currentPos;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            currentTransform = null;
        }
    }
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