// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-14 13:49:02
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBoolClickRotate : MonoBehaviour
{

    public CamCon camCon;
    public LayerMask layer;
    Ray ray;
    RaycastHit hit;
    void Start()
    {
        if (!camCon)
        {
            camCon = GameObject.FindObjectOfType<CamCon>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
             //   print(hit.collider.gameObject.tag+"    "+ hit.collider.gameObject.name);
     

                if (hit.collider.gameObject.tag.Equals("obj"))
                {
                    camCon.isClickUI = true;
                }

            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            camCon.isClickUI = false;
        }
    }
}
