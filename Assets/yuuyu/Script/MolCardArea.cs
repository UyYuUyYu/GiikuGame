using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolCardArea : MonoBehaviour
{
    [SerializeField] private GameObject[] _MolCard;
    private List<int> _MolCardNumber = new List<int>();

    //MolCardをカードのエリアに生成する
    public void GenerateMolCard(int n)
    {
        if (n < 10)
        {
            print("aa");
            _MolCardNumber.Add(n);
            GameObject clone = Instantiate(_MolCard[n], this.gameObject.transform);
            clone.transform.position = this.transform.position;
        }
        
    }
    //出ているカードを消す
    public void DeleteMolCard()
    {
        foreach (Transform n in this.gameObject.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
    public void DeleteMolCardNumber()
    {
        //ListのmolCardの情報を消去
        _MolCardNumber.RemoveRange(0, _MolCardNumber.Count);
    }
}
