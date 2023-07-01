using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FillamoutAnim : MonoBehaviour
{
    [SerializeField] Image fillamoutImage;

    void Start()
    {
        Fill();
    }

    void Fill()
    {
        fillamoutImage.DOFillAmount(1, 1.5f);
    }
}
