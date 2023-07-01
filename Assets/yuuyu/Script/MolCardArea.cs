using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MolCardArea : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject[] _MolCard;
    [SerializeField] private GameObject _EnemyMolCardPos;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Battle");
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print(MolCalculation(_MyMolCardNumber));
            for (int i = 0; i < MolCardList._MyMolCardNumber.Count; i++)
            {
                GenerateMolCard(MolCardList._MyMolCardNumber[i]);
            }
        }
        */
    }

    public void AddMolcard(int n)
    {
        if (n < 10)
        {
            MolCardList._MyMolCardNumber.Add(n);
            GenerateMolCard(n);
        }
       
    }
    //自分のMolCardをカードのエリアに生成する
    public void GenerateMolCard(int n)
    {
        print("aa");
            
        GameObject clone = Instantiate(_MolCard[n], this.gameObject.transform);
        clone.transform.position = this.transform.position;
    }
    //相手のMOlカードを生成
    public void GenerateEnemyMolCard(int n)
    {
        GameObject clone = Instantiate(_MolCard[n], _EnemyMolCardPos.transform);
        clone.transform.position = _EnemyMolCardPos.transform.position;
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
        MolCardList._MyMolCardNumber.RemoveRange(0, MolCardList._MyMolCardNumber.Count);
    }

    public int MolCalculation(List<int> MolCardNumber)
    {

        int goukei = 0;
        for(int i = 0; i < MolCardNumber.Count; i++)
        {
            goukei = goukei + _MolCard[MolCardNumber[i]].GetComponent<MolcardInfo>().mass;
        }
        return goukei;
    }
    
    [PunRPC]
    private void EnemyMolCardGenerate(List<int> MolCardNumber)
    {
        print("RPC");
        for (int i = 0; i < MolCardNumber.Count; i++)
        {
            GenerateEnemyMolCard(MolCardNumber[i]);
        }
    }
    
}
