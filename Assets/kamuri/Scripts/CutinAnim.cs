using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CutinAnim : MonoBehaviour
{
    [SerializeField] Image vsPlayerImage;
    [SerializeField] Image vsEnemyImage;
    [SerializeField] Image fadeImage;
    [SerializeField] Transform readyTransform;
    [SerializeField] Transform goTransform;
    float fadeDuration = 1f;
    [SerializeField] int blinlCount = 2;
    float blinkDuration = 0.2f;
    float readyDuration = 1.3f;
    [SerializeField] float vsPlayerStartY = -1000;
    [SerializeField] float vsEnemyStartY = 1000;
    [SerializeField] float vsPlayerEndY = 1000;
    [SerializeField] float vsEnemyEndY = -1000;
    [SerializeField] float phaseStartX = -500f;
    [SerializeField] float phaseEndX = 500f;
    [SerializeField] float readygoEndY = 630f;

    void Start()
    {
        VsAnim();
    }

    void VsAnim()
    {
        // 初期位置の指定
        vsPlayerImage.rectTransform.anchoredPosition = new Vector2(-200, vsPlayerStartY);
        vsEnemyImage.rectTransform.anchoredPosition = new Vector2(200, vsEnemyStartY);

        // フェードイン
        vsPlayerImage.rectTransform.DOAnchorPosY(0f, fadeDuration);
        vsPlayerImage.DOFade(1f, fadeDuration)
            .SetEase(Ease.Linear);
        vsEnemyImage.rectTransform.DOAnchorPosY(0f, fadeDuration);
        vsEnemyImage.DOFade(1f, fadeDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                DOVirtual.DelayedCall(2f, () =>
                {
                    //フェードアウト
                    vsPlayerImage.DOFade(0f, fadeDuration)
                         .SetEase(Ease.Linear);
                    vsPlayerImage.rectTransform.DOAnchorPosY(vsPlayerEndY, fadeDuration);
                    vsEnemyImage.DOFade(0f, fadeDuration)
                        .SetEase(Ease.Linear);
                    vsEnemyImage.rectTransform.DOAnchorPosY(vsEnemyEndY, fadeDuration)
                    .OnComplete(() =>
                    {
                        PhaseAnim();
                    });
                });
            });

    }

    void PhaseAnim()
    {
        fadeImage.gameObject.SetActive(true);
        // 初期位置の指定
        fadeImage.rectTransform.anchoredPosition = new Vector2(phaseStartX, 0f);

        // フェードイン
        fadeImage.rectTransform.DOAnchorPosX(0f, fadeDuration);
        fadeImage.DOFade(1f, fadeDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // 点滅
                Sequence blinkSequence = DOTween.Sequence();
                for (int i = 0; i < blinlCount; i++)
                {
                    blinkSequence.Append(fadeImage.DOFade(0f, blinkDuration)
                        .SetEase(Ease.Linear));
                    blinkSequence.Append(fadeImage.DOFade(1f, blinkDuration)
                        .SetEase(Ease.Linear));
                }

                // フェードアウト
                blinkSequence.Append(fadeImage.DOFade(0f, fadeDuration)
                    .SetEase(Ease.Linear));
                blinkSequence.Join(fadeImage.rectTransform.DOAnchorPosX(phaseEndX, fadeDuration)
                    .SetEase(Ease.Linear))
                .OnComplete(() => ReadyAnim());
            });
    }

    void ReadyAnim()
    {
        readyTransform.gameObject.SetActive(true);
        // フェードインのアニメーション
        readyTransform.DOMoveY(readygoEndY, readyDuration)
            .OnComplete(() =>
            {
                // アニメーション完了後、非アクティブにする
                readyTransform.gameObject.SetActive(false);
                goTransform.gameObject.SetActive(true);
                goTransform.DOMoveY(readygoEndY, readyDuration)
                .OnComplete(() =>
                {
                    goTransform.gameObject.SetActive(false);
                });
            });
    }

}