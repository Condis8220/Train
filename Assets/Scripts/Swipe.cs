using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : Singleton<Swipe>, IDragHandler, IEndDragHandler
{
    public Vector2 Delta { get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        Delta = new Vector2(eventData.delta.x / Screen.width, eventData.delta.y / Screen.height);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Delta = Vector2.zero;
    }
}
