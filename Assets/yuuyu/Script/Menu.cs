using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    bool isClicked=false;
    public void OnClickMenu()
    {
        if (isClicked)
        {
            _menu.SetActive(false);
            isClicked = false;
        }
        else
        {
            _menu.SetActive(true);
            isClicked = true;
        }
           
    }

    
}
