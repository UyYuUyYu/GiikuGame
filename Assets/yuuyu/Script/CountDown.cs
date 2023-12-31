using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviourPunCallbacks
{
    [SerializeField] float _time;
    [SerializeField] private TextMeshProUGUI _text;
    bool isCountDown = false;
    [SerializeField] TimeUpAnim _TimeUpAnim;

    bool isTimeUp = false;

    float zero = 0;
    // Start is called before the first frame update
    void Awake()
    {
        StartCountDown();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountDown)
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
                _text.text = _time.ToString("F2");
            }
            else
            {
                /*
                if(PhotonNetwork.IsMasterClient)
                    PhotonNetwork.LoadLevel("Battle");
                */
                if (isTimeUp == false)
                {
                    _text.text=zero.ToString("F2");
                    _TimeUpAnim.TimeUpEffet();
                    isTimeUp = true;
                }
                
                //SceneManager.LoadSceneAsync("Battle", LoadSceneMode.Single);
            }
            
        }
        
    }

    public void StartCountDown()
    {
        isCountDown = true;
    }
}
