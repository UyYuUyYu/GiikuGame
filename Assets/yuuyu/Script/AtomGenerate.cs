using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] _atomObj;
    private Transform canvasParent;
    // Start is called before the first frame update
    void Start()
    {
        canvasParent = GameObject.Find("Canvas").transform;
        Genrate();
    }


    public void Genrate()
    {
        int randomNumber = Random.Range(0, 4);
        
        GameObject clone=Instantiate(_atomObj[randomNumber], canvasParent);
        clone.transform.position = this.transform.position;
        AtomScript atomScript = clone.GetComponent<AtomScript>();
        atomScript.atomGenerate = this.GetComponent<AtomGenerate>();

        //GameObject clone = Instantiate(_atomObj[randomNumber], this.GetComponent<RectTransform>().anchoredPosition, Quaternion.identity);
    }
}
