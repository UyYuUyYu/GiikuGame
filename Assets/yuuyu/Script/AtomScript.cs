using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class AtomScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
   
    private Vector2 prevPos;
    private Vector3 offset3;
    private Vector2 offset2;
    private float offset2X;
    private float offset2Y;

    //Atom�̖��O�����ꂼ��ݒ�
    [SerializeField] private Atom _atom;

    public bool isDrag = false;
    public bool isEnterArea = false;

    //KetugouArea�̃X�N���v�g
    private KetugouArea ketugouArea;

    //AtomGenerate�̐������ꂽ�ꏊ�̂��̂�ۑ����Ă���
    public AtomGenerate atomGenerate;
    void Start()
    {
        ketugouArea = GameObject.Find("Area").GetComponent<KetugouArea>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �h���b�O�O�̈ʒu���L�����Ă���
        prevPos = transform.position;

        offset2X = transform.position.x - eventData.position.x;
        offset2Y = transform.position.y - eventData.position.y;
        offset2 = new Vector2(offset2X, offset2Y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �h���b�O���͈ʒu���X�V����
        transform.position = eventData.position + offset2;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Area�ɓ����Ă���������A�����Ă��Ȃ�������h���b�O�O�̈ʒu�ɖ߂�
        if (isEnterArea)
        {
            //�A�g����ǉ�����
            ketugouArea.AddAtom(_atom);
            //�A�g���������邩
            ketugouArea.EnterJudge();

            //�ʂ̃A�g���𐶐�����
            atomGenerate.Genrate();
            Destroy(this.gameObject);
        }
        else
            transform.position = prevPos;
    }

    

   

    

}
