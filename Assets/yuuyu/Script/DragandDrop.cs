using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragandDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] Camera _cam;
    private Vector2 prevPos;
    private Vector3 offset3;
    private Vector2 offset2;
    private float offset2X;
    private float offset2Y;
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶しておく
        prevPos = transform.position;

        offset2X = transform.position.x- eventData.position.x;
        offset2Y = transform.position.y - eventData.position.y;
        offset2 = new Vector2(offset2X, offset2Y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中は位置を更新する
        transform.position = eventData.position+offset2;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置に戻す
        transform.position = prevPos;
    }

  
}
