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
    //private Atom _atomName;
    private bool isMouseEnter = false;
    private bool isEnterJudge = true;

    //いま入っているatomを保存するリスト
    private List<Atom> _inConnectArea = new List<Atom>();
    //今入っているアトムの巣類別の個数を格納する
    private int[] AtomList = new int[4];

    //Atomのスクリプトを代入する
    private AtomScript _atomScript;

    /*
    void OnMouseEnter()
    {
        isMouseEnter = true;
        print("a");
    }

    void OnMouseExit()
    {
        isMouseEnter = false;
        print("b");
    }
    */

    public void OnTriggerEnter2D(Collider2D other)
    {
       
        _atomScript = other.gameObject.GetComponent<AtomScript>();
        //_atomName =_atomScript.CheckAtomName();
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
        //_atomName = atom;
        _inConnectArea.Add(atom);


        //print(_inConnectArea.Count);
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
    public void Ketugou()
    {

    }

}
