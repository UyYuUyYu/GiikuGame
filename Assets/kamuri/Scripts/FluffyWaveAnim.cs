using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FluffyWaveAnim : MonoBehaviour
{
    Transform atomTransform;
    [SerializeField] float duration = 1f; //アニメーション時間
    [SerializeField] float amplitude = 0.2f; //振幅

    float DelayTime;
    void Start()
    {
        DelayTime = Random.Range(0, 3);
        StartCoroutine(TimeCount());//コルーチンの開始

    }
    private IEnumerator TimeCount()//コルーチンで行う処理の定義
    {
            yield return new WaitForSeconds(DelayTime);//５秒経過するまで待つ

        atomTransform = GetComponent<Transform>();
        Sequence sequence = DOTween.Sequence()
            .SetLoops(-1, LoopType.Restart);

        sequence.Append(atomTransform.DOBlendableMoveBy(new Vector3(0f, amplitude, 0f), duration * 0.5f)
            .SetEase(Ease.InOutQuad));
        sequence.Append(atomTransform.DOBlendableMoveBy(new Vector3(0f, -amplitude, 0f), duration)
            .SetEase(Ease.InOutQuad));

        sequence.Play();
    }


}
