using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class New_CreateLine : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public LineRenderer line;

    public LayerMask layer;
    public Vector3 pos;
    public Transform cad;
    float z_lineRenderer;
    public bool isFlag = false;

    Ray ray;
    RaycastHit hit;
    public int index = 0;
    New_LineCon lineCon;
    public GetEnterPoints getEnterPoints;

    public Transform line_Parent;
    private void Awake()
    {
        line_Parent = GameObject.Find("Ground").GetComponent<Transform>();
    }
    void Start()
    {
        if (cad != null)
            z_lineRenderer = cad.position.y + 0.1f;
    }
    private void Update()
    {

        PaintingLine();
    }
    void PaintingLine()
    {
        if (New_LineManager.Instance.IsBiHe())
            return;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            isClickUI = false;
        }
        if (IsMouseDown(0) && !IsClickUI())
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.collider.gameObject.tag.Equals("CAD"))
                    return;
                if (index % 2 == 0 && !isFlag)
                {
                    LineRenderer line_temp = Instantiate<LineRenderer>(lineRenderer);
                    line_temp.transform.SetParent(line_Parent);
                    lineCon = line_temp.GetComponent<New_LineCon>();
                    line = line_temp;//为了下面引用克隆出来的 line，设置一个临时的
                    line.gameObject.transform.position = hit.point;
                    pos = hit.point;

                    line.SetPosition(0, new Vector3(pos.x, z_lineRenderer, pos.z));//没问题
                    print(hit.collider.gameObject.name + "   " + hit.point.y + "    " + z_lineRenderer);
                    lineCon.SetLinePos(0, 0);
                    lineCon.SetLinePos1();
                    lineCon.SetLinePos2();
                    lineCon.AddDotPoint1();
                    lineCon.SetPosT1();
                    lineCon.SetDot();

                }
                isFlag = true;
                if (index % 2 != 0)
                {
                    line.SetPosition(1, new Vector3(hit.point.x, z_lineRenderer, hit.point.z));
                    lineCon.SetLinePos2();
                    lineCon.SetPos2();
                    lineCon.AddDotPoint2();
                    lineCon.SetPosT2();
                    lineCon.createWall(0.1f, 2f);
                    print("Hit.Point " + hit.point + "    " + z_lineRenderer);


                    New_LineManager.Instance.lineCon.Add(lineCon);
                    if (New_LineManager.Instance.IsBiHe())
                    {
                        getEnterPoints.CreateGround();
                        // getEnterPoints.m_enterPoints.Clear();
                        index = 0;
                        isFlag = false;
                        New_LineManager.Instance.lineCon.Clear();
                        return;
                    }
                    LineRenderer line_temp = Instantiate<LineRenderer>(lineRenderer);
                    line_temp.transform.SetParent(line_Parent);
                    lineCon = line_temp.GetComponent<New_LineCon>();
                    line = line_temp;//为了下面引用克隆出来的 line，设置一个临时的
                    line.gameObject.transform.position = hit.point;
                    pos = hit.point;
                    line.SetPosition(0, new Vector3(pos.x, z_lineRenderer, pos.z));
                    lineCon.SetDot();

                    index++;
                }
            }
            index++;
        }

        if (isFlag)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.collider.gameObject.tag.Equals("CAD"))
                    return;
                if (line == null)
                    return;
                line.SetPosition(1, new Vector3(hit.point.x, z_lineRenderer, hit.point.z));//0.2600005
                                                                                           //  line.SetPosition(1, new Vector3(hit.point.x, 0.26f, hit.point.z));
            }
        }
    }

    bool IsMouseDown(int index)
    {
        return Input.GetMouseButtonDown(index);
    }


    #region 鼠标样式
    [Header("鼠标样式"), Space(15)]
    public Texture2D cursor_Image;
    /// <summary>
    /// 鼠标样式是否改变
    /// </summary>
    public bool isChange_CursorStyle = true;


    /// <summary>
    /// 更改鼠标样式
    /// </summary>
    void Chanage_CursorStytle()
    {
        if (isChange_CursorStyle)
        {
            Cursor.SetCursor(cursor_Image, Vector2.zero, CursorMode.Auto);//鼠标样式变为自己设置的Texture2D
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);//保持鼠标原来的样式
        }
    }
    #endregion


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
