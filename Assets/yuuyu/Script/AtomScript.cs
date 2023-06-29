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

    //Atomの名前をそれぞれ設定
    [SerializeField] private Atom _atom;

    public bool isDrag = false;
    public bool isEnterArea = false;

    //KetugouAreaのスクリプト
    private KetugouArea ketugouArea;

    //AtomGenerateの生成された場所のものを保存しておく
    public AtomGenerate atomGenerate;
    void Start()
    {
        ketugouArea = GameObject.Find("Area").GetComponent<KetugouArea>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶しておく
        prevPos = transform.position;

        offset2X = transform.position.x - eventData.position.x;
        offset2Y = transform.position.y - eventData.position.y;
        offset2 = new Vector2(offset2X, offset2Y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中は位置を更新する
        transform.position = eventData.position + offset2;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Areaに入っていたら消す、入っていなかったらドラッグ前の位置に戻す
        if (isEnterArea)
        {
            //アトムを追加する
            ketugouArea.AddAtom(_atom);
            //アトムをおけるか
            ketugouArea.EnterJudge();

            //別のアトムを生成する
            atomGenerate.Genrate();
            Destroy(this.gameObject);
        }
        else
            transform.position = prevPos;
    }

    

   

    

}
