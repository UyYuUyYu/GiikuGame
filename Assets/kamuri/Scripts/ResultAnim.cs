using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultAnim : MonoBehaviour
{
    [SerializeField] Image playerWaveImage;
    [SerializeField] Image enemyWaveImage;
    [SerializeField] Image winTextImage;
    [SerializeField] Image loseTextImage;
    [SerializeField] Image drawTextImage;
   // [SerializeField] int playerScore;
    //[SerializeField] int enemyScore;
    static public int playerScore;
    static public int enemyScore;
    float duration = 1f;

    [SerializeField] GameObject _QuitButton;

    void Start()
    {
        HalfAnim();
    }

    void HalfAnim()
    {
        playerWaveImage.DOFillAmount(0.6f, 1f);
        enemyWaveImage.DOFillAmount(0.6f, 1f)
            .OnComplete(() =>
            {
                if (playerScore > enemyScore)
                {
                    PlayerWinAnim();
                }
                else if (playerScore < enemyScore)
                {
                    EnemyWinAnim();
                }
                else
                {
                    DrawAnim();
                }
                
            });

    }

    void PlayerWinAnim()
    {
        playerWaveImage.transform.SetAsLastSibling();
        playerWaveImage.DOFillAmount(1, 1.5f);
        enemyWaveImage.DOFillAmount(0.3f, 1.5f)
            .OnComplete(() =>
            {
                winTextImage.gameObject.SetActive(true);
                winTextImage.transform.SetAsLastSibling();
                winTextImage.transform.localScale = Vector3.zero;
                winTextImage.color = new Color(winTextImage.color.r, winTextImage.color.g, winTextImage.color.b, 0f);
                winTextImage.transform.DOScale(Vector3.one, duration)
                .SetEase(Ease.OutElastic);
                winTextImage.DOFade(1f, duration)
                .SetDelay(duration / 2f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => { _QuitButton.SetActive(true); });
            });
    }

    void EnemyWinAnim()
    {
        enemyWaveImage.transform.SetAsLastSibling();
        playerWaveImage.DOFillAmount(0.3f, 1.5f);
        enemyWaveImage.DOFillAmount(1, 1.5f)
            .OnComplete(() =>
            {
                loseTextImage.gameObject.SetActive(true);
                loseTextImage.transform.SetAsLastSibling();
                loseTextImage.transform.localScale = Vector3.zero;
                loseTextImage.color = new Color(loseTextImage.color.r, loseTextImage.color.g, loseTextImage.color.b, 0f);
                loseTextImage.transform.DOScale(Vector3.one, duration)
                .SetEase(Ease.OutElastic);
                loseTextImage.DOFade(1f, duration)
                .SetDelay(duration / 2f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => { _QuitButton.SetActive(true); });
            });
    }

    void DrawAnim()
    {
        playerWaveImage.DOFillAmount(0.57f, 1.5f);
        enemyWaveImage.DOFillAmount(0.57f, 1.5f)
            .OnComplete(() =>
            {
                drawTextImage.gameObject.SetActive(true);
                drawTextImage.transform.SetAsLastSibling();
                drawTextImage.transform.localScale = Vector3.zero;
                drawTextImage.color = new Color(drawTextImage.color.r, drawTextImage.color.g, drawTextImage.color.b, 0f);
                drawTextImage.transform.DOScale(Vector3.one, duration)
                .SetEase(Ease.OutElastic);
                drawTextImage.DOFade(1f, duration)
                .SetDelay(duration / 2f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => { _QuitButton.SetActive(true); });
            });
    }
}
