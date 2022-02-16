using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFinalDescriptionPopupView : MonoBehaviour
{
    public Button CloseButton;
    public TMP_Text Text;
    public TMP_Text Title;
    

    private void Awake()
    {
        CloseButton.OnClickAsObservable().Subscribe(x =>
        {
            Open(false);
        }).AddTo(gameObject);
    }

    public void SetText(string text)
    {
        Text.text = text;
    }
    
    public void SetTitle(string text)
    {
        Title.text = text;
    }

    public void Open(bool open)
    {
        gameObject.SetActive(open);
    }
}