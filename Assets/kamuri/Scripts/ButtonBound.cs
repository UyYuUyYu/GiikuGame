using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonBound : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(0.3f, 1f)
            .SetRelative(true) //相対値
            .SetEase(Ease.OutQuart) //イージング方法指定
            .SetLoops(-1, LoopType.Restart); //アニメーションが終わったら再度最初からループ
    }
}
