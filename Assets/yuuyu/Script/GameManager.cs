using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    public static bool isPlayGame = false;
    private const int _MaxPlayerPerRoom = 2;
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }
    
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
        print("マスターサーバー接続完了");
    }

    // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        // ルームの参加人数を2人に設定する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = _MaxPlayerPerRoom;

        PhotonNetwork.CreateRoom(null, roomOptions);
        print("ルーム作成");
    }

    //作成されたルームに入った時
    public override void OnJoinedRoom()
    {

        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }

        //Playerの人数がそろっていないとき
        if (PhotonNetwork.CurrentRoom.PlayerCount != _MaxPlayerPerRoom)
        {
            
        }
        //Playerの人数がそろったとき
        else
        {
            print("人数そろった");
            isPlayGame = true;
            
        }
    }
    //roomにプレイヤーが入ってきたとき
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == _MaxPlayerPerRoom)
            {
                print("人ははいってきた");
                PhotonNetwork.CurrentRoom.IsOpen = false;
                isPlayGame = true;
                PhotonNetwork.LoadLevel("Main");
            }
        }
    }

    public void LeaveRoby()
    {
        print("退出しました");
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Start");
    }

   

}
