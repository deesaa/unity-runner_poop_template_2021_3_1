using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSwitchView : MonoBehaviour
{
    public PageButtonView WeaponsPage;
    public PageButtonView SkinsPage;

    public void OpenPage(EItemType currentPage)
    {
        switch (currentPage)
        {
            case EItemType.Weapon:
                WeaponsPage.SetOpen(true);
                SkinsPage.SetOpen(false);
                break;
            case EItemType.Skin:
                SkinsPage.SetOpen(true);
                WeaponsPage.SetOpen(false);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentPage), currentPage, null);
        }
    }
}
