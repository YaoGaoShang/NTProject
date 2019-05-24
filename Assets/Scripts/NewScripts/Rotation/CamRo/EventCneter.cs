// ========================================================
// 描述：
// 作者：MeKey 
// 创建时间：2019-05-06 15:58:02
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void SetTargetHandler(GameObject target);

public class EventCneter : MonoBehaviour
{

    public static event SetTargetHandler eventSetTarget;
    float timer = -1;
    Ray ray;
    RaycastHit hit;
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (TapCountDouble())
        {

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null&&hit.collider.tag .Equals ("obj"))
                {
                    print(hit.collider.name);
                    eventSetTarget(hit.collider.gameObject);
                }
            }
        }
    }


    float lastKickTime;
    public bool TapCountDouble()
    {
        bool isDouble = false;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Time.realtimeSinceStartup - lastKickTime < 0.3f)
            {
                isDouble = true;
            }
            lastKickTime = Time.realtimeSinceStartup;
        }
        return isDouble;
    }



}
