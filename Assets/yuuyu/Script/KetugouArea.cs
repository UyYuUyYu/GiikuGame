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
    //�t���X�R�̂Ȃ��Ő�������Atom
    [SerializeField] private GameObject[] _atomObjS;

    [SerializeField] private GameObject[] _MolCard;


    private Atom _atomName;
    
    private bool isFullStack = false;

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
       
        if (isFullStack==false)
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
        //���g��5�ȏ�͂���Ȃ��悤��
        if (_inConnectArea.Count == 5)
        {
            isFullStack = true;
            //print("��������Ȃ�");
        }
        DropAtom();

    }

    //�����{�^�������Ƃ�т�����鉽���������邩�𔻒f����֐�
    public void EnterJudge()
    {

        AtomList[0]=_inConnectArea.Count(x => x == Atom.H);
        AtomList[1]=_inConnectArea.Count(x => x == Atom.O);
        AtomList[2]=_inConnectArea.Count(x => x == Atom.C);
        AtomList[3]=_inConnectArea.Count(x => x == Atom.N);

        if (AtomList[0] == 2)
        {
            if (AtomList[1] == 1 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("H2O");

            }
            else if (AtomList[1] == 0 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("H2");
            }
        }
        else if (AtomList[0] == 3 && AtomList[1] == 0 && AtomList[2] == 0 && AtomList[3] == 1)
        {
            print("NH3");
        }
        else if (AtomList[0] == 4 && AtomList[1] == 0 && AtomList[2] == 1 && AtomList[3] == 0)
        {
            print("CH4");
        }

        if (AtomList[1] == 1)
        {
            if (AtomList[0] == 0 && AtomList[2] == 1 && AtomList[3] == 0)
            {
                print("CO");
            }
            else if (AtomList[0] == 0 && AtomList[2] == 0 && AtomList[3] == 1)
            {
                print("NO");
            }
        }
        else if (AtomList[1] == 2)
        {
            if (AtomList[0] == 0 && AtomList[2] == 1 && AtomList[3] == 0)
            {
                print("CO2");
            }
            else if (AtomList[0] == 0 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("O2");
            }
        }
        else if (AtomList[1] == 3 )
        {
            if( AtomList[0] == 0 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("O3");
            }
            
        }
        if (AtomList[0] == 0 && AtomList[1] == 0 && AtomList[2] == 0 && AtomList[3] == 2)
        {
            print("N2");
        }
        

        
        /*
        print(AtomList[0]);
        print(AtomList[1]);
        print(AtomList[2]);
        print(AtomList[3]);
        */

       
        
    }

    public void ListDerete()
    {
        _inConnectArea.RemoveRange(0, _inConnectArea.Count);
        isFullStack = false;
    }

    public void DropAtom()
    {
        int num=0;
        switch (_atomName)
        {
            case Atom.H:
                num = 0;
                break;
            case Atom.O:
                num = 1;
                break;
            case Atom.C:
                num = 2;
                break;
            case Atom.N:
                num = 3;
                break;
        }

        GameObject clone = Instantiate(_atomObjS[num], DropAtomPos);
        clone.transform.position = DropAtomPos.position;
    }

    public void Ketugou()
    {
        print("����");
        EnterJudge();
        isFullStack = false;
    }

}
