using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUiView : MonoBehaviour
{
    public Button CloseButton;

    public Button VibrationButtonSwitch;
    public Image DisabledVibrationIcon;
    
    public void SetView(ValueGameData playerData)
    {
        DisabledVibrationIcon.gameObject.SetActive(playerData.DisabledVibration);
    }
}
