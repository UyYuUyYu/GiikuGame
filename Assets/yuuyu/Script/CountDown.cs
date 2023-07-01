using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float _time;
    [SerializeField] private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time-=Time.deltaTime;
        _text.text = _time.ToString("F2");
    }
}
