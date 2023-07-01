using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class TimeUpAnim : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI timeupText;
    float duration = 1f;
    float scaleMult = 2f;

    public void TimeUpEffet()
    {
        
        timeupText.transform.SetAsLastSibling();
        timeupText.transform.localScale = Vector3.zero;
        timeupText.color = new Color(timeupText.color.r, timeupText.color.g, timeupText.color.g, 0f);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(timeupText.DOFade(0f, 0.5f));
        sequence.Append(timeupText.transform.DOScale(Vector3.zero, 0f));
        sequence.AppendCallback(() => timeupText.gameObject.SetActive(true));
        sequence.Append(timeupText.DOFade(1f, duration * 0.4f));
        sequence.Join(timeupText.transform.DOScale(Vector3.one * scaleMult, duration * 0.7f)
            .SetEase(Ease.OutBack));
        sequence.Append(timeupText.transform.DOScale(Vector3.zero, duration * 0.7f)
           .SetDelay(duration * 0.6f)
           .SetEase(Ease.InBack));
        sequence.Join(timeupText.DOFade(0f, duration * 0.4f)
            .SetDelay(duration * 0.6f));

        sequence.Play().OnComplete(() => { timeupText.gameObject.SetActive(false); SceneManager.LoadSceneAsync("Battle", LoadSceneMode.Single); });

        
        //;SceneManager.LoadSceneAsync("Battle", LoadSceneMode.Single);
    }
}
