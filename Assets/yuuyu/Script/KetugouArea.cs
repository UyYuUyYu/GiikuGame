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
    //フラスコのなかで生成するAtom
    [SerializeField] private GameObject[] _atomObjS;



    private Atom _atomName;
    
    private bool isFullStack = false;

    //いま入っているatomを保存するリスト
    private List<Atom> _inConnectArea = new List<Atom>();
    //今入っているアトムの巣類別の個数を格納する
    private int[] AtomList = new int[4];

    //Atomのスクリプトを代入する
    private AtomScript _atomScript;
    //MolCardのスクリプトを入れる
    [SerializeField] private MolCardArea _molCardArea;

    void Start()
    {
        //DropAtomPos = GameObject.Find("AtomDropArea").transform;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        _atomScript = other.gameObject.GetComponent<AtomScript>();
       
        if (isFullStack == false)
        {
            _atomScript.isEnterArea = true;
        }
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
        //中身が5個以上はいらないように
        if (_inConnectArea.Count == 5)
        {
            isFullStack = true;
            //print("もう入らない");
        }
        DropAtom();

    }

    //結合ボタンおすとよびだされる何を結合するかを判断する関数
    public int EnterJudge()
    {

        AtomList[0]=_inConnectArea.Count(x => x == Atom.H);
        AtomList[1]=_inConnectArea.Count(x => x == Atom.O);
        AtomList[2]=_inConnectArea.Count(x => x == Atom.C);
        AtomList[3]=_inConnectArea.Count(x => x == Atom.N);

        //配列に入れたカードを呼び出すための番号（100は絶対にありえない数値を初期値としている）
        int cardNumber = 1000;

        if (AtomList[0] == 2)
        {
            if (AtomList[1] == 1 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("H2O");
                return cardNumber = 0;

            }
            else if (AtomList[1] == 0 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("H2");
                return cardNumber = 1;
            }
        }
        else if (AtomList[0] == 3 && AtomList[1] == 0 && AtomList[2] == 0 && AtomList[3] == 1)
        {
            print("NH3");
            return cardNumber = 2;
        }
        else if (AtomList[0] == 4 && AtomList[1] == 0 && AtomList[2] == 1 && AtomList[3] == 0)
        {
            print("CH4");
            return cardNumber = 3;
        }

        if (AtomList[1] == 1)
        {
            if (AtomList[0] == 0 && AtomList[2] == 1 && AtomList[3] == 0)
            {
                print("CO");
                return cardNumber = 4;
            }
            else if (AtomList[0] == 0 && AtomList[2] == 0 && AtomList[3] == 1)
            {
                print("NO");
                return cardNumber = 5;
            }
        }
        else if (AtomList[1] == 2)
        {
            if (AtomList[0] == 0 && AtomList[2] == 1 && AtomList[3] == 0)
            {
                print("CO2");
                return cardNumber = 6;
            }
            else if (AtomList[0] == 0 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("O2");
                return cardNumber = 7;
            }
        }
        else if (AtomList[1] == 3 )
        {
            if( AtomList[0] == 0 && AtomList[2] == 0 && AtomList[3] == 0)
            {
                print("O3");
                return cardNumber = 8;
            }
            
        }
        if (AtomList[0] == 0 && AtomList[1] == 0 && AtomList[2] == 0 && AtomList[3] == 2)
        {
            print("N2");
            return cardNumber = 9;
        }

        return cardNumber;
        
    }

    public void ListDerete()
    {
        //Listのアトムの情報を消去
        _inConnectArea.RemoveRange(0, _inConnectArea.Count);
        //中に生成されたAtomを消去
        foreach (Transform n in DropAtomPos)
        {
            GameObject.Destroy(n.gameObject);
        }
        isFullStack = false;
    }

    //Atomをフラスコないに生成
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
        
        float randomPosX = Random.Range(-40, 40);
        Vector3 generateAtomSPos = new Vector3(DropAtomPos.position.x + randomPosX, DropAtomPos.position.y, DropAtomPos.position.z);
        //clone.transform.position = DropAtomPos.position;
        clone.transform.position = generateAtomSPos;
    }

    public void Ketugou()
    {
        if (MolCardArea.isFullCardCount==false)
        {
            int n = EnterJudge();
            //モルカードそ生成するエリアのほうで生成
            _molCardArea.AddMolcard(n);
            _molCardArea.MolCalculationList(MolCardList._MyMolCardNumber);
            if (n < 10)
            {
                ListDerete();
                isFullStack = false;
            }
        }
        


    }

}
