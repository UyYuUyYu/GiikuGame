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
        // �h���b�O�O�̈ʒu���L�����Ă���
        prevPos = transform.position;

        offset2X = transform.position.x- eventData.position.x;
        offset2Y = transform.position.y - eventData.position.y;
        offset2 = new Vector2(offset2X, offset2Y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �h���b�O���͈ʒu���X�V����
        transform.position = eventData.position+offset2;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �h���b�O�O�̈ʒu�ɖ߂�
        transform.position = prevPos;
    }

  
}
