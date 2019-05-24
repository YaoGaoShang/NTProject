using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    private static ObjManager _instance;
    public static ObjManager Instance
    {
        get { return _instance; }
    }

    public List<GameObject> objList = new List<GameObject>();



    private void Awake()
    {

        //DontDestroyOnLoad(this);
        //if (_instance != null)
        //{
        //    Destroy(this.gameObject);
        //    return;
        //}
        //else
        //    _instance = this;
        //SetRestPos();

    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {

        }
        else
        {
            SetRestPos();
        }
    }

    public void SetRestPos()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
