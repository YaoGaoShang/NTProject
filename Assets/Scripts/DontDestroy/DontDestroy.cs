using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    public GameObject[] dontObj;
    private void Awake()
    {
        for (int i = 0; i < dontObj.Length; i++)
        {
            DontDestroyOnLoad(dontObj[i]);
        }
    }
}
