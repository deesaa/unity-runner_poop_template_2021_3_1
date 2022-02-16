using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWalletView : MonoBehaviour
{
    public TMP_Text StarsCount;
    public TMP_Text GemsCount;

    public void SetWalletData(ValueGameData playerData)
    {
        StarsCount.text = playerData.EarnedStars.ToString();
        GemsCount.text = playerData.EarnedGems.ToString();
    }
}
