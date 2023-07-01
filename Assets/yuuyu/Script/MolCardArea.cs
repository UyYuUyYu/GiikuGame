using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MolCardArea : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject[] _MolCard;
    private GameObject _MyMolCardPos;
    [SerializeField] private GameObject _EnemyMolCardPos;
    private int[] MyMolHairetu=new int[] { 100,100,100,100,100,100};

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        _MyMolCardPos = this.gameObject;
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            SetBattleCard();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PhotonNetwork.LoadLevel("Battle");
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {


        }
        
    }

    //Battleシーンで開いてと自分のカードを表示
    private void SetBattleCard()
    {
        for (int i = 0; i < MolCardList._MyMolCardNumber.Count; i++)
        {
            GenerateMolCard(MolCardList._MyMolCardNumber[i]);
            MyMolHairetu[i] = MolCardList._MyMolCardNumber[i];
        }
        photonView.RPC(nameof(EnemyMolCardGenerate), RpcTarget.Others, MyMolHairetu);
    }

    public void AddMolcard(int n)
    {
        print("ADd");
        if (n < 10)
        {
            MolCardList._MyMolCardNumber.Add(n);
            GenerateMolCard(n);
        }
       
    }
    //自分のMolCardをカードのエリアに生成する
    public void GenerateMolCard(int n)
    {
        print("gene");
        GameObject clone = Instantiate(_MolCard[n], _MyMolCardPos.transform);
        clone.transform.position = _MyMolCardPos.transform.position;
    }
    //相手のMOlカードを生成
    public void GenerateEnemyMolCard(int n)
    {
        if (n < 10)
        {
            GameObject clone = Instantiate(_MolCard[n], _EnemyMolCardPos.transform);
            clone.transform.position = _EnemyMolCardPos.transform.position;
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
    public void EnemyMolCardGenerate(int[] MolCardNumber)
    {
        Debug.Log("RPC");
        for (int i = 0; i < MolCardNumber.Length; i++)
        {
            GenerateEnemyMolCard(MolCardNumber[i]);
        }
    }
    
}
