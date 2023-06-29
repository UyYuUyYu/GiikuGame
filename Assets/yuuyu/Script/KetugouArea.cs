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
    //Atom���t���X�R�̂Ȃ��Ő�������ꏊ
    [SerializeField] private Transform DropAtomPos;
    [SerializeField] private GameObject[] _atomObjS;
   

    private Atom _atomName;
    private bool isMouseEnter = false;
    private bool isEnterJudge = true;

    //���ܓ����Ă���atom��ۑ����郊�X�g
    private List<Atom> _inConnectArea = new List<Atom>();
    //�������Ă���A�g���̑��ޕʂ̌����i�[����
    private int[] AtomList = new int[4];

    //Atom�̃X�N���v�g��������
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
                Debug.Log("�t");
                num = 0;
                break;
            case Atom.O:
                Debug.Log("��");
                num = 1;
                break;
            case Atom.C:
                Debug.Log("�H");
                num = 2;
                break;
            case Atom.N:
                Debug.Log("�~");
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
