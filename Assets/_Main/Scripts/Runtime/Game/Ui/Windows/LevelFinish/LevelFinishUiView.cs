using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.InGameMenu
{
    public class LevelFinishUiView : UiView
    {
        public List<StatInfoUiView> StatInfoUiViews;
        public Button OpenMoreButton;
        public PlayerFinalDescriptionPopupView PopupView;
        public Button ContinueButton;
    }
}