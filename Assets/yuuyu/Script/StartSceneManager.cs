using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class StartSceneManager : MonoBehaviourPunCallbacks
{
    
    [SerializeField] private TextMeshProUGUI inputFieldText;
    public static string myName;
    // Start is called before the first frame update
    void Start()
    {
        myName = "Player";
    }
   
    public void StartButton()
    {
        PhotonNetwork.NickName= inputFieldText.text;
        myName = inputFieldText.text;
        print(PhotonNetwork.NickName);
        SceneManager.LoadScene("WaitingScene");
        
    }
    
}
