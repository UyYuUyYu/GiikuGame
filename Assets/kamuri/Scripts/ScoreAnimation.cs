using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreAnimation : MonoBehaviour
{
    Text _text;
    [SerializeField] int score = 1000;
    float countTime = 1.5f;

    void Start()
    {
        if (this.gameObject.name == "PlayerScore")
            score = ResultAnim.playerScore;
        if (this.gameObject.name == "EnemyScore")
            score = ResultAnim.enemyScore;

        _text = GetComponent<Text>();
        _text.DOCounter(0, score, countTime, true);
    }
}
