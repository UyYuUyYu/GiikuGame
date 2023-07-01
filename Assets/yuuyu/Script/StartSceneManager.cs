using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StartSceneManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI inputFieldText;
    public static string myName;
    // Start is called before the first frame update
    void Start()
    {
        myName = "Player";
    }
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            myName = inputFieldText.text;
            SceneManager.LoadScene("WaitingScene");
            print(myName);
        }
        */
    }
    public void StartButton()
    {
        SceneManager.LoadScene("WaitingScene");
        myName = inputFieldText.text;
    }
    
}
