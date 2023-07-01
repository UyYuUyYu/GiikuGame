using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattlePhaseAnim : MonoBehaviour
{
    [SerializeField] Image battleImage;
    float fadeDuration = 1f;
    [SerializeField] int blinlCount = 2;
    float blinkDuration = 0.2f;
    float battlePhaseStartX = -500f;
    float battlePhaseEndX = 500f;

    void Start()
    {
        battleImage.gameObject.SetActive(true);
        // 初期位置の指定
        battleImage.rectTransform.anchoredPosition = new Vector2(battlePhaseStartX, 0f);

        // フェードイン
        battleImage.rectTransform.DOAnchorPosX(0f, fadeDuration);
        battleImage.DOFade(1f, fadeDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // 点滅
                Sequence blinkSequence = DOTween.Sequence();
                for (int i = 0; i < blinlCount; i++)
                {
                    blinkSequence.Append(battleImage.DOFade(0f, blinkDuration)
                        .SetEase(Ease.Linear));
                    blinkSequence.Append(battleImage.DOFade(1f, blinkDuration)
                        .SetEase(Ease.Linear));
                }

                // フェードアウト
                blinkSequence.Append(battleImage.DOFade(0f, fadeDuration)
                    .SetEase(Ease.Linear));
                blinkSequence.Join(battleImage.rectTransform.DOAnchorPosX(battlePhaseEndX, fadeDuration)
                    .SetEase(Ease.Linear));
            });
    }
}
