using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolCardArea : MonoBehaviour
{
    [SerializeField] private GameObject[] _MolCard;
    private List<int> _MolCardNumber = new List<int>();

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MolCalculation();
        }
    }
    //MolCard���J�[�h�̃G���A�ɐ�������
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
    //�o�Ă���J�[�h������
    public void DeleteMolCard()
    {
        foreach (Transform n in this.gameObject.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
    public void DeleteMolCardNumber()
    {
        //List��molCard�̏�������
        _MolCardNumber.RemoveRange(0, _MolCardNumber.Count);
    }

    public void MolCalculation()
    {
        int goukei = 0;
        for(int i = 0; i < _MolCardNumber.Count; i++)
        {
            goukei = goukei + _MolCard[_MolCardNumber[i]].GetComponent<MolcardInfo>().mass;
        }
        //print(goukei);
    }
}
