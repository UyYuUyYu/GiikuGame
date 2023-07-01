using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NameScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text myNameText;
    [SerializeField] private Text enemyNameText;

    public void SetMyName()
    {
        myNameText.text = PhotonNetwork.NickName;
    }
    public void EnemyMyName()
    {
        enemyNameText.text = PhotonNetwork.PlayerList[0].NickName;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
