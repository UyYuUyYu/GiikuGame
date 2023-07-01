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
            StartCoroutine(TimeCount());//�R���[�`���̊J�n
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

    private IEnumerator TimeCount()//�R���[�`���ōs�������̒�`
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

    //Battle�V�[���ŊJ���ĂƎ����̃J�[�h��\��
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
    //������MolCard���J�[�h�̃G���A�ɐ�������
    public void GenerateMolCard(int n)
    {
       
        GameObject clone = Instantiate(_MolCard[n], _MyMolCardPos.transform);
        clone.transform.position = _MyMolCardPos.transform.position;
    }
    //�����MOl�J�[�h�𐶐�
    public void GenerateEnemyMolCard(int n)
    {
        if (n < 10)
        {
            GameObject clone = Instantiate(_MolCard[n], _EnemyMolCardPos.transform);
            clone.transform.position = _EnemyMolCardPos.transform.position;
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
        MolCardList._MyMolCardNumber.RemoveRange(0, MolCardList._MyMolCardNumber.Count);
    }

   //�����̃J�[�h�̍��v�l�����߂�
    public void MolCalculation(int[] MolCardNumber)
    {

        int goukei = 0;
        for(int i = 0; i < MolCardNumber.Length; i++)
        {
            if(MolCardNumber[i]<10)
                goukei = goukei + _MolCard[MolCardNumber[i]].GetComponent<MolcardInfo>().mass;
        }
        print("����" + goukei);
        ResultAnim.playerScore=goukei;
    }
    //�G�̃J�[�h�̍��v�l�����߂�
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
        print("�����Ă�" + ResultAnim.enemyScore);
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
