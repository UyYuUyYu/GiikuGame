using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] _atomObj;
    //private Transform canvasParent;
    
    void Start()
    {
        //canvasParent = GameObject.Find("Canvas").transform;
        Genrate();
    }


    public void Genrate()
    {
        int randomNumber = Random.Range(0, 4);
        
        //GameObject clone=Instantiate(_atomObj[randomNumber], canvasParent);
        GameObject clone = Instantiate(_atomObj[randomNumber], this.gameObject.transform);
        clone.transform.position = this.transform.position;
        AtomScript atomScript = clone.GetComponent<AtomScript>();
        atomScript.atomGenerate = this.GetComponent<AtomGenerate>();

        //GameObject clone = Instantiate(_atomObj[randomNumber], this.GetComponent<RectTransform>().anchoredPosition, Quaternion.identity);
    }
}
