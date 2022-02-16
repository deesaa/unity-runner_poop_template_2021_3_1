
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyButtonView : MonoBehaviour
{
    public Image CurrenyIcon; 
    public Sprite StarsCurrencyIcon;
    public Sprite GemsCurrencyIcon;
    public TMP_Text Price;
    public Button Button;

    public Sprite BuyButtonSprite;
    public Sprite CanBuyButtonSprite;

    public void SetButtonView(int price, ECurrencyType type, ValueGameData playerData)
    {
        Price.text = $"x{price}";
        switch (type)
        {
            case ECurrencyType.Stars:
                CurrenyIcon.sprite = StarsCurrencyIcon;
                break;
            case ECurrencyType.Gems:
                CurrenyIcon.sprite = GemsCurrencyIcon;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        if (playerData.EarnedGems < price)
        {
            Button.interactable = false;
        }
        else
        {
            Button.interactable = true;
        }
    }

    public void SetAllObtained(bool isMaxObtained = false)
    {
        if (isMaxObtained)
        {
            
        }
    }
}
