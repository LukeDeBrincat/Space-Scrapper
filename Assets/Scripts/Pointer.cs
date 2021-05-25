using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float defaulLength = 3f;

    private LineRenderer lineRenderer = null;

    public EventSystem eventSystem;
    public StandaloneInputModule inputModule;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, GetEnd());
    }

    private Vector3 GetEnd()
    {
        float distance = GetCanvasDistance();
        Vector3 endPosition = DefaultEnd(defaulLength);

        if (distance != 0)
        {
            endPosition = DefaultEnd(distance);
        }

        return endPosition;
    }

    private float GetCanvasDistance()
    {
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = inputModule.inputOverride.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);

        RaycastResult closest = FindFirstRaycast(results);
        float distance = closest.distance;

        distance = Mathf.Clamp(distance, 0, defaulLength);
        return distance;
    }

    private RaycastResult FindFirstRaycast(List<RaycastResult> results)
    {
        foreach(RaycastResult result in results)
        {
            if (!result.gameObject)
            {
                continue;
            }

            return result;
        }

        return new RaycastResult();
    }

    private Vector3 DefaultEnd(float Length)
    {
        return transform.position + (transform.forward * defaulLength);
    }
}
