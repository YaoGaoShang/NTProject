using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;


public enum HideType
{
    Alpha,//透明度
    Meshrenderer//hide MeshRenderer
}
public class CollisionHandling : MonoBehaviour
{

    public Transform targetObj;//目标物体

    public List<GameObject> collideredObjects;//本次射线hit到的GameObject
    public List<GameObject> bufferOfCollideredObjects;//上次射线hit到的GameObject
    public HideType hideType = HideType.Alpha;
    public float radius;
    public float maxDis;
    void Start()
    {
        // targetObj = GameObject.Find("Ground").GetComponent <Transform >();
        targetObj = GameObject.Find("Ground").GetComponent<Transform>();
        collideredObjects = new List<GameObject>();
        bufferOfCollideredObjects = new List<GameObject>();
        EventCneter.eventSetTarget += SetTarget;
    }
    /// <summary>
    /// 需要注册的事件
    /// </summary>
    /// <param name="target"></param>
    private void SetTarget(GameObject target)
    {
        targetObj = target.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (targetObj != null)
            Set();
        else
        {
            for (int i = 0; i < bufferOfCollideredObjects.Count; i++)
            {
                switch (hideType)
                {
                    case HideType.Alpha:
                        SetMaterialsColor(bufferOfCollideredObjects[i].GetComponent<Renderer>(), true);
                        break;
                    case HideType.Meshrenderer:
                        rendererSet(bufferOfCollideredObjects[i].GetComponent<MeshRenderer>(), false);
                        break;
                    default:
                        break;
                }


            }
            for (int i = 0; i < collideredObjects.Count; i++)
            {
                switch (hideType)
                {
                    case HideType.Alpha:
                        SetMaterialsColor(collideredObjects[i].GetComponent<Renderer>(), false);
                        break;
                    case HideType.Meshrenderer:
                        rendererSet(collideredObjects[i].GetComponent<MeshRenderer>(), true);
                        break;
                    default:
                        break;
                }
            }
            bufferOfCollideredObjects.Clear();
            collideredObjects.Clear();
        }
    }


    void Set()
    {
        bufferOfCollideredObjects.Clear();
        for (int temp = 0; temp < collideredObjects.Count; temp++)
        {
            bufferOfCollideredObjects.Add(collideredObjects[temp]);//得到上次的
        }
        collideredObjects.Clear();

        //发射射线
        Vector3 dir = -(targetObj.position - transform.position).normalized;
        RaycastHit[] hits;
        hits = Physics.RaycastAll(targetObj.position, dir, Vector3.Distance(targetObj.position, transform.position));
        Debug.DrawLine(targetObj.position, transform.position, Color.red);//让其显示以便观测

        for (int i = 0; i < hits.Length; i++)
        {
            collideredObjects.Add(hits[i].collider.gameObject);//得到现在的
        }
        //把上次的还原，这次的透明
        for (int i = 0; i < bufferOfCollideredObjects.Count; i++)
        {
            switch (hideType)
            {
                case HideType.Alpha:
                    SetMaterialsColor(bufferOfCollideredObjects[i].GetComponent<Renderer>(), false);
                    break;
                case HideType.Meshrenderer:
                    rendererSet(bufferOfCollideredObjects[i].GetComponent<MeshRenderer>(), true);
                    break;
                default:
                    break;
            }
        }
        for (int i = 0; i < collideredObjects.Count; i++)
        {
            switch (hideType)
            {
                case HideType.Alpha:
                    SetMaterialsColor(collideredObjects[i].GetComponent<Renderer>(), true);
                    break;
                case HideType.Meshrenderer:
                    rendererSet(collideredObjects[i].GetComponent<MeshRenderer>(), false);
                    break;
                default:
                    break;
            }
        }
    }

    //是否搞透明
    void SetMaterialsColor(Renderer r, bool isClear)
    {
        if (isClear)
        {
            int materialsNumber = r.sharedMaterials.Length;
            for (int i = 0; i < materialsNumber; i++)
            {
                r.materials[i].shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = r.materials[i].color;
                tempColor.a = 0.1f;
                r.materials[i].color = tempColor;
                Texture temp_tex = r.materials[i].mainTexture;
                r.materials[i].mainTexture = temp_tex;
            }
        }
        else
        {
            int materialsNumber = r.sharedMaterials.Length;
            for (int i = 0; i < materialsNumber; i++)
            {
                r.materials[i].shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = r.materials[i].color;
                tempColor.a = 1f;
                r.materials[i].color = tempColor;
                Texture temp_tex = r.materials[i].mainTexture;
                r.materials[i].mainTexture = temp_tex;
            }
        }
    }
    void rendererSet(MeshRenderer r, bool isClear)
    {
        if (isClear)
        {
            r.enabled = true;
            // r.gameObject.SetActive(true);
        }
        else
        {
            r.enabled = false;
            //  r.gameObject.SetActive(false);

        }
    }
}
