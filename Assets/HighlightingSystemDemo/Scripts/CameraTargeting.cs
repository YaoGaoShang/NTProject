using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CameraTargeting : MonoBehaviour
{
    // Which layers targeting ray must hit (-1 = everything)
    public LayerMask targetingLayerMask = -1;

    // Targeting ray length
    private float targetingRayLength = Mathf.Infinity;

    // Camera component reference
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }
    public Transform targetTransform;
    void Update()
    {
        TargetingRaycast();
    }
    
    public void TargetingRaycast()
    {
        // Current mouse position on screen
        Vector3 mp = Input.mousePosition;

        // Current target object transform component
        targetTransform = null;

        // If camera component is available
        if (cam != null)
        {
            RaycastHit hitInfo;

            // Create a ray from mouse coords
            Ray ray = cam.ScreenPointToRay(new Vector3(mp.x, mp.y, 0f));

            // Targeting raycast
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, targetingRayLength, targetingLayerMask.value))
            {
                // Cache what we've hit
                targetTransform = hitInfo.collider.transform;
            }
        }

        // If we've hit an object during raycast
        if (targetTransform != null)
        {
            // And this object has HighlightableObject component
            //    HighlightableObject ho = targetTransform.root.GetComponentInChildren<HighlightableObject>();
            HighlightableObject ho = targetTransform.GetComponent<HighlightableObject>();
            if (ho != null && !IsMousePointUI)
            {
                ho.On(Color.cyan);//�����꾭�� �ͻ�ִ��
            }
        }
    }

    /// <summary>
    /// �ж�����Ƕ������UI����3d����
    /// </summary>
    public bool IsMousePointUI
    {
        get
        {
            //  if (Input.GetMouseButtonDown(0))
            //   {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return true;
            }
            //   }
            return false;
        }
    }

}
