using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moveback : MonoBehaviour,IDragHandler
{
    RectTransform currentRect;

    public void OnDrag(PointerEventData eventData)
    {
        /*Vector3 Point;
        Point = Camera.main.ScreenToWorldPoint(currentRect.anchoredPosition);
        transform.position = new Vector3(Point.x, Point.y, transform.position.z);*/
        
        currentRect.anchoredPosition += eventData.delta;
        Debug.Log("滑鼠變量:" + eventData.delta);
        Debug.Log("滑鼠座標:" + eventData.position);
        Debug.Log(currentRect.anchoredPosition);
    }

    private void Awake()
    {
        currentRect = GetComponent<RectTransform>();
    }
}
