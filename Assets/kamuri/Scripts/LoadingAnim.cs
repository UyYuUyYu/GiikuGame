using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingAnim : MonoBehaviour
{
    private const float DURATION = 0.8f;

    void Start()
    {
        Image[] loadingImage = GetComponentsInChildren<Image>();
        for (var i = 0; i < loadingImage.Length; i++)
        {
            var angle = -2 * Mathf.PI * i / loadingImage.Length;
            // 初期位置の指定
            loadingImage[i].rectTransform.anchoredPosition = Vector2.zero;

            // UIを指定の場所に移動
            // 動作を連続して実行する
            Sequence sequence = DOTween.Sequence()
                .SetLoops(-1, LoopType.Yoyo) // 無限ループ(行き来)
                .AppendInterval(DURATION / 4)
                .Append(loadingImage[i].rectTransform.DOAnchorPos(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 50f, DURATION / 2))
                .AppendInterval(DURATION / 4);
            sequence.Play();
        }

        // UIを回転
        // 動作を連続して実行する
        Sequence sequenceParent = DOTween.Sequence()
            .SetLoops(-1, LoopType.Restart) // 無限ループ(加算)
            .Append(transform.DOLocalRotate(Vector3.forward * (180f / loadingImage.Length), DURATION / 4))
            .AppendInterval(DURATION / 2)
            .Append(transform.DOLocalRotate(Vector3.forward * (180f / loadingImage.Length), DURATION / 4));
        sequenceParent.Play();
    }
}
