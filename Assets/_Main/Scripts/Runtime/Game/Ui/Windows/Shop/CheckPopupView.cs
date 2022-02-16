using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CheckPopupView : MonoBehaviour
{
    public Sprite StarsCurrencyIcon;
    public Sprite GemsCurrencyIcon;
    
    public Button Yes;
    public Button No;
    public TMP_Text Text;
    public Image Icon;

    private IDisposable yesObserver;
    private IDisposable noObserver;

    public void Open(string text, ECurrencyType currencyType, Action<bool> onAnswer)
    {
        Text.text = text;

        switch (currencyType)
        {
            case ECurrencyType.Stars:
                Icon.sprite = StarsCurrencyIcon;
                break;
            case ECurrencyType.Gems:
                Icon.sprite = GemsCurrencyIcon;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currencyType), currencyType, null);
        }

        yesObserver = Yes.OnClickAsObservable().Subscribe(x =>
        {
            Close();
            onAnswer(true);
        }).AddTo(gameObject);
        
        noObserver = No.OnClickAsObservable().Subscribe(x =>
        {            
            Close();
            onAnswer(false);
        }).AddTo(gameObject);

        gameObject.SetActive(true);
        transform.DOPunchScale(Vector3.one * 0.1f, 0.3f);
    }

    private void Close()
    {
        yesObserver.Dispose();
        noObserver.Dispose();
        gameObject.SetActive(false);
    }
}