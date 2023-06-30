using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingPointAnim : MonoBehaviour
{
    float duration = 2f;

    void Start()
    {
        Image[] points = GetComponentsInChildren<Image>();
        for (var i = 0; i < points.Length; i++)
        {
            points[i].rectTransform.anchoredPosition = new Vector2((i - points.Length / 2) * 50f, 0);　//水平方向等間隔配置
            Sequence sequence = DOTween.Sequence()
                .SetLoops(-1, LoopType.Restart) //restart型無限ループ
                .SetDelay((duration / 2) * ((float)i / points.Length)) //各シーケンス開始時間の遅延
                .Append(points[i].DOFade(0f, duration / 4)) //フェードアウト
                .Append(points[i].DOFade(1f, duration / 4)) //フェードイン
                .AppendInterval((duration / 2) * ((float)(1 - i) / points.Length)); //次のアニメーションまでのインターバル
            sequence.Play();
        }
    }
}
