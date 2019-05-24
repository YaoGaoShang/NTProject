using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ServerManager : MonoBehaviour
{
    Tweener tweener;
    public bool isClick = false;

    public void OnMouseDown()
    {
        if (TapCountDouble())
        {
            if (!isClick)
            {
                if (true)
                {
                    if (!ServerControl.Instance.serverList.Contains(this))
                        ServerControl.Instance.serverList.Add(this);
                }

                SetServerAni(0.4f, 0.3f);
                PlayerForwardAni();
                ServerControl.Instance.SetAllAni();
            }
            else
            {
                PlayerBackWards();
            }

            isClick = !isClick;
        }
    }


    public void SetServerAni(float endValue, float duration)
    {
        tweener = gameObject.transform.DOLocalMoveZ(endValue, duration);
        tweener.SetAutoKill(false);
        tweener.Pause();
    }


    public void PlayerForwardAni()
    {
        tweener.PlayForward();
    }


    public void PlayerBackWards()
    {
        tweener.PlayBackwards();
    }
    #region 双击

    float lastKickTime;
    public bool TapCountDouble()
    {
        bool isDouble = false;
        if (Input.GetMouseButtonDown(0) && !IsClickUI())
        {
            if (Time.realtimeSinceStartup - lastKickTime < 0.3f)
            {
                isDouble = true;
            }
        }
        lastKickTime = Time.realtimeSinceStartup;
        return isDouble;
    }

    public bool IsClickUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    #endregion
}
