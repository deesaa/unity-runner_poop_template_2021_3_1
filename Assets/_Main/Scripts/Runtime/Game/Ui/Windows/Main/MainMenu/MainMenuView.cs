using SimpleUi.Abstracts;
using CustomSelectables;
using Runtime.Game.Ui.Windows.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Game.Ui.Windows.MainMenu
{
    public class MainMenuView : UiView
    {
        public Button PlayButton;
        public Button RestartButton;
        public Button ShopButton;
        public Button SettingsOpenButton;

        public TMP_Text LevelText;
        public TMP_Text LevelText2;
        public Transform ShopNotification;
        
        public RectTransform CanvasRect;

        public SettingsUiView SettingsUiView;
        public FaderImage MainButtonsFader;
    }
}