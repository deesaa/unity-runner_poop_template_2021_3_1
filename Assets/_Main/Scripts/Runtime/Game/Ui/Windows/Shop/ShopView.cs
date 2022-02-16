using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runtime.Game.Ui.Windows.Shop
{
    public class ShopView : UiView
    {
        public ShopItemContainerView ShopItemContainerViewPrefab;
        public CheckPopupView CheckPopupView;
        
        public Transform ShopItemsContainer;

        public FaderImage BackFader;
        public FaderImage ShopFader;
        public Button CloseButton;

        public PlayerWalletView PlayerWalletView;
        public RectTransform CanvasRect;

        public PageSwitchView PageSwitchView;
    }
}