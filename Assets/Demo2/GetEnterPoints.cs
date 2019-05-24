using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


//获取组成多变形点类
public class GetEnterPoints : MonoBehaviour
{
    //存储手动获取到的多边形点列表
    public List<Vector3> m_enterPoints = new List<Vector3>();
    public Material material;
    public GameObject cad;
    void Update()
    {
        //左键取点
        if (Input.GetMouseButtonDown(0))
        {
            //屏幕位置转射线
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //射线返回点信息
            RaycastHit tHit;
            //发射射线
            if (Physics.Raycast(tRay, out tHit))
            {
                //如果打在地面上，则将点存储起来
                if (tHit.transform.tag == "CAD" && !IsClickUI())
                {
                    //这里为了形成的面不与原先底板重合，提升了一个高度
                    //   m_enterPoints.Add(tHit.point + new Vector3(0, 1, 0));
                    print(gameObject.name + "    " + tHit.collider.gameObject);
                    m_enterPoints.Add(tHit.point);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClickUI = false;
        }
    }
    public CamCon camCon;
    public void CreateGround()
    {
        if (New_LineManager.Instance.IsBiHe())
        {
            //形成面至少三点
            if (m_enterPoints.Count > 2)
            {
                //  m_enterPoints.RemoveAt(m_enterPoints.Count - 1);
                cad.SetActive(false);
                //调用形成多变形方法
                CreateMesh tCreatMesh = new CreateMesh();
                // tCreatMesh.DoCreatPloygonMesh(m_enterPoints.ToArray(), material);//DemoMesh
                tCreatMesh.DemoMesh(m_enterPoints.ToArray(), material);//DemoMesh
                //每次绘制完清空手动获取的点列表
                m_enterPoints.Clear();
                camCon.enabled = true;
            }
            m_enterPoints.Clear();
        }

    }

    [Space(10), Header("是否点击的是UI true =是")]
    public bool isClickUI = false;
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