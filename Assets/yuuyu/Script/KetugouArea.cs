using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Atom
{
    H,
    O,
    C,
    N
}

public class KetugouArea : MonoBehaviour
{
    //Atomをフラスコのなかで生成する場所
    [SerializeField] private Transform DropAtomPos;
    [SerializeField] private GameObject[] _atomObjS;
   

    private Atom _atomName;
    private bool isMouseEnter = false;
    private bool isEnterJudge = true;

    //いま入っているatomを保存するリスト
    private List<Atom> _inConnectArea = new List<Atom>();
    //今入っているアトムの巣類別の個数を格納する
    private int[] AtomList = new int[4];

    //Atomのスクリプトを代入する
    private AtomScript _atomScript;

    void Start()
    {
        //DropAtomPos = GameObject.Find("AtomDropArea").transform;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
       
        _atomScript = other.gameObject.GetComponent<AtomScript>();
       
        if (isEnterJudge)
            _atomScript.isEnterArea = true;
        else
        {

        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        _atomScript.isEnterArea = false;
        
    }
    public void AddAtom(Atom atom)
    {
        _atomName = atom;
        _inConnectArea.Add(atom);
        DropAtom();

    }

    public void EnterJudge()
    {

        AtomList[0]=_inConnectArea.Count(x => x == Atom.H);
        AtomList[1]=_inConnectArea.Count(x => x == Atom.O);
        AtomList[2]=_inConnectArea.Count(x => x == Atom.C);
        AtomList[3]=_inConnectArea.Count(x => x == Atom.N);

        
        /*
        print(AtomList[0]);
        print(AtomList[1]);
        print(AtomList[2]);
        print(AtomList[3]);
        */

        isEnterJudge = true;
        
    }

    public void ListDerete()
    {
        _inConnectArea.RemoveRange(0, _inConnectArea.Count);
    }

    public void DropAtom()
    {
        int num=0;
        switch (_atomName)
        {
            case Atom.H:
                Debug.Log("春");
                num = 0;
                break;
            case Atom.O:
                Debug.Log("夏");
                num = 1;
                break;
            case Atom.C:
                Debug.Log("秋");
                num = 2;
                break;
            case Atom.N:
                Debug.Log("冬");
                num = 3;
                break;
        }

        GameObject clone = Instantiate(_atomObjS[num], DropAtomPos);
        clone.transform.position = DropAtomPos.position;
    }
    public void Ketugou()
    {

    }

}
