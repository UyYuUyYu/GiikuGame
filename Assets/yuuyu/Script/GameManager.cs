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
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }
    
    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
        print("�}�X�^�[�T�[�o�[�ڑ�����");
    }

    // �����_���ŎQ���ł��郋�[�������݂��Ȃ��Ȃ�A�V�K�Ń��[�����쐬����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        // ���[���̎Q���l����2�l�ɐݒ肷��
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = _MaxPlayerPerRoom;

        PhotonNetwork.CreateRoom(null, roomOptions);
        print("���[���쐬");
    }

    //�쐬���ꂽ���[���ɓ�������
    public override void OnJoinedRoom()
    {

        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }

        //Player�̐l����������Ă��Ȃ��Ƃ�
        if (PhotonNetwork.CurrentRoom.PlayerCount != _MaxPlayerPerRoom)
        {
            
        }
        //Player�̐l������������Ƃ�
        else
        {
            print("�l���������");
            isPlayGame = true;
            
        }
    }
    //room�Ƀv���C���[�������Ă����Ƃ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == _MaxPlayerPerRoom)
            {
                print("�l�͂͂����Ă���");
                PhotonNetwork.CurrentRoom.IsOpen = false;
                isPlayGame = true;
                PhotonNetwork.LoadLevel("Main");
            }
        }
    }

    public void LeaveRoby()
    {
        print("�ޏo���܂���");
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Start");
    }

   

}
