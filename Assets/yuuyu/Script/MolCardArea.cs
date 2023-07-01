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
    int enemyGoukei = 0;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        _MyMolCardPos = this.gameObject;
        
        
        
    }
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Battle")
        {
            // SetBattleCard();
            StartCoroutine(TimeCount());//コルーチンの開始
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
            SetBattleCard();

        }
        
    }

    private IEnumerator TimeCount()//コルーチンで行う処理の定義
    {
        yield return new WaitForSeconds(0.5f);
        SetBattleCard();
        SetScore();
    }


    void SetScore()
    {
        MolCalculation(MyMolHairetu);
        photonView.RPC(nameof(MolCalculationEnemy), RpcTarget.Others, MyMolHairetu);
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
        
        if (n < 10)
        {
            MolCardList._MyMolCardNumber.Add(n);
            GenerateMolCard(n);
        }
       
    }
    //自分のMolCardをカードのエリアに生成する
    public void GenerateMolCard(int n)
    {
       
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

   //自分のカードの合計値を求める
    public void MolCalculation(int[] MolCardNumber)
    {

        int goukei = 0;
        for(int i = 0; i < MolCardNumber.Length; i++)
        {
            if(MolCardNumber[i]<10)
                goukei = goukei + _MolCard[MolCardNumber[i]].GetComponent<MolcardInfo>().mass;
        }
        print("自分" + goukei);
        ResultAnim.playerScore=goukei;
    }
    //敵のカードの合計値を求める
    [PunRPC]
    public void MolCalculationEnemy(int[] MolCardNumber)
    {

        int goukei = 0;
        for (int i = 0; i < MolCardNumber.Length; i++)
        {
            if (MolCardNumber[i] < 10)
                goukei = goukei + _MolCard[MolCardNumber[i]].GetComponent<MolcardInfo>().mass;
        }
        ResultAnim.enemyScore = goukei;
        //enemyGoukei=goukei;
        print("あいての" + ResultAnim.enemyScore);
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
