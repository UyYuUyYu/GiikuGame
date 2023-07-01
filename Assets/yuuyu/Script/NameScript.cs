using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NameScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI myNameText;
    [SerializeField] private TextMeshProUGUI enemyNameText;
    void Start()
    {
        SetMyName();
        EnemyMyName();
    }

    public void SetMyName()
    {
        myNameText.text = PhotonNetwork.NickName;
    }
    public void EnemyMyName()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            enemyNameText.text = PhotonNetwork.PlayerList[1].NickName;
        }
        else
        {
            enemyNameText.text = PhotonNetwork.PlayerList[0].NickName;
        }
           
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
