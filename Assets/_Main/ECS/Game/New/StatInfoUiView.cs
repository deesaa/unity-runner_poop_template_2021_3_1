using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StatInfoUiView : MonoBehaviour
{
    public TMP_Text Score;
    public Image ProgressImage;
    public EStatType StatType;
    public TMP_Text Label;
    public Image Hider;
    public float score;
    
    private void Awake()
    {
        Label.text = StatType.ToString().ToUpper();
    }

    public void SetProgress(float progress)
    {
        Score.text = ((int)(progress * 100f)).ToString();
        ProgressImage.fillAmount = progress;
    }

    public void ShowStats(Action onComplete)
    {
        float randomScore = Random.Range(0.4f, 1f);
        score = randomScore;
        
        DOTween.Sequence()
            .Append(Hider.DOColor(new Color(1f, 1f, 1f, 0f), 0.3f))
            .Append(DOVirtual.Float(0f, randomScore, 1.7f, SetProgress))
            .AppendInterval(0.25f)
            .OnComplete(() => onComplete());
    }
}