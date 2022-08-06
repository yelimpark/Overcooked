using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Image point;
    public float radius;

    public RectTransform rectTr;

    private Vector2 originalPoint = Vector2.zero;

    private Vector2 direction;

    private void Start()
    {
        originalPoint = rectTr.position;
    }

    public float GetAxis(string axis)
    {
        var dir = direction / radius;
        switch (axis)
        {
            case "Horizontal":
                return dir.x;
            case "Vertical":
                return dir.y;
        }
        return 0f;
    }


    public void OnDrag(PointerEventData eventData)
    {
        var newPos = eventData.position;
        direction = newPos - originalPoint;
        if (direction.magnitude > radius)
        {
            newPos = originalPoint + direction.normalized * radius;
            direction = direction.normalized * radius;
        }
        point.rectTransform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        direction = Vector2.zero;
        point.rectTransform.position = originalPoint;
    }

    
    
}