/*************************************************
 * 项目名称：UGUI通用
 * 脚本功能：UI图片拖拽功能（将脚本挂载在需要拖放的图片上）
 * ***********************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//UI图片拖拽功能类
public class UIDragByMocha : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("是否精准拖拽")]
    public bool m_isPrecision;

    //存储图片中心点与鼠标点击点的偏移量
    private Vector3 m_offset;

    //存储当前拖拽图片的RectTransform组件
    private RectTransform m_rt;
  //  public GameObject panel_delect;
    void Start()
    {
        //初始化
        m_rt = gameObject.GetComponent<RectTransform>();
    }
    //开始拖拽触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        //如果精确拖拽则进行计算偏移量操作
        if (m_isPrecision)
        {
            // 存储点击时的鼠标坐标
            Vector3 tWorldPos;
            //UI屏幕坐标转换为世界坐标
            RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out tWorldPos);
            //计算偏移量   
            m_offset = transform.position - tWorldPos;
        }
        //否则，默认偏移量为0
        else
        {
            m_offset = Vector3.zero;
        }

        SetDraggedPosition(eventData);
    }

    //拖拽过程中触发
    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    //结束拖拽触发
    public void OnEndDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    /// <summary>
    /// 设置图片位置方法
    /// </summary>
    /// <param name="eventData"></param>
    private void SetDraggedPosition(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            //存储当前鼠标所在位置
            Vector3 globalMousePos;
            //UI屏幕坐标转换为世界坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
            {
                //设置位置及偏移量
                m_rt.position = globalMousePos + m_offset;
            }
        }
    }
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public void Btn_Close()
    {
      //  panel_delect.SetActive(false);
    }
}