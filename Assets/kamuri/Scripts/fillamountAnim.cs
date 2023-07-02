using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class fillamountAnim : MonoBehaviour
{
    [SerializeField] Image playerWaveImage;
    [SerializeField] Image enemyWaveImage;
    [SerializeField] Image winTextImage;
    [SerializeField] Image loseTextImage;
    [SerializeField] Image drawTextImage;
    //変更点
    [SerializeField] Text playerScoreText;
    [SerializeField] Text enemyScoreText;

    [SerializeField] int playerScore;
    [SerializeField] int enemyScore;
    float duration = 1f;

    void Start()
    {
        HalfAnim();
    }

    void HalfAnim()
    {
        //変更点
        playerScoreText.gameObject.SetActive(true);
        enemyScoreText.gameObject.SetActive(true);

        playerWaveImage.DOFillAmount(0.6f, 1f);
        enemyWaveImage.DOFillAmount(0.6f, 1f)
            .OnComplete(() =>
            {
                if(playerScore > enemyScore)
                {
                    PlayerWinAnim();
                }
                else if(playerScore < enemyScore)
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
        //変更点
        playerScoreText.transform.SetAsLastSibling();
        enemyScoreText.transform.SetAsLastSibling();

        playerWaveImage.DOFillAmount(1, 1.5f);
        enemyWaveImage.DOFillAmount(0.3f, 1.5f)
            .OnComplete(() =>
            {
                winTextImage.gameObject.SetActive(true);
                //変更点
                playerScoreText.gameObject.SetActive(false);
                enemyScoreText.gameObject.SetActive(false);

                winTextImage.transform.SetAsLastSibling();
                winTextImage.transform.localScale = Vector3.zero;
                winTextImage.color = new Color(winTextImage.color.r, winTextImage.color.g, winTextImage.color.b, 0f);
                winTextImage.transform.DOScale(Vector3.one, duration)
                .SetEase(Ease.OutElastic);
                winTextImage.DOFade(1f, duration)
                .SetDelay(duration / 2f)
                .SetEase(Ease.OutQuad);
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
                .SetEase(Ease.OutQuad);
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
                .SetEase(Ease.OutQuad);
            });
    }
}
