using System.Collections.Generic;
using DataBase.Game;
using DG.Tweening;
using ECS.Game.Systems;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Ui.Windows.Shop
{
    public class ShopController : UiController<ShopView>, IInitializable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private IShopItemsBase _shopItemsBase;
        [Inject] private SceneData _sceneData;
        [Inject] private EcsWorld _world;
        [Inject] private IGameStageService _gameStage;

        private List<ShopItemContainerView> _runtimeItemContainerViews = new List<ShopItemContainerView>();

        private EItemType _currentPageItemType = EItemType.Weapon;

        public void Initialize()
        {
            _signalBus.GetStream<SignalUpdateData>().Subscribe(x =>
            {
                if((x.TargetUI & ETargetUI.Shop) != ETargetUI.Shop)
                    return;
                
                UpdateShopInfo(x.GameData);
            }).AddTo(_sceneData);
            
            _signalBus.GetStream<SignalHide>().Subscribe(x =>
            {
                if((x.TargetUI & ETargetUI.Shop) != ETargetUI.Shop)
                    return;
                
                HideAnimation();
            }).AddTo(_sceneData);

            View.CloseButton.OnClickAsObservable().Subscribe(x =>
            {
                _gameStage.ChangeStage(EGameStage.MainMenu, 0.3f);
            }).AddTo(_sceneData);

            View.PageSwitchView.WeaponsPage.ClosedPageButtonView.OnClickAsObservable().Subscribe(x =>
            {
                _currentPageItemType = EItemType.Weapon;
                View.PageSwitchView.OpenPage(_currentPageItemType);
                _world.NewEntity().Get<SignalUpdateData>().TargetUI = ETargetUI.Shop;
            }).AddTo(_sceneData);
            
            View.PageSwitchView.SkinsPage.ClosedPageButtonView.OnClickAsObservable().Subscribe(x =>
            {
                _currentPageItemType = EItemType.Skin;
                View.PageSwitchView.OpenPage(_currentPageItemType);
                _world.NewEntity().Get<SignalUpdateData>().TargetUI = ETargetUI.Shop;;
            }).AddTo(_sceneData);
            
            _currentPageItemType = EItemType.Weapon;
            View.PageSwitchView.OpenPage(_currentPageItemType);
        }

        public override void OnShow()
        {
            base.OnShow();
            
            View.PageSwitchView.OpenPage(_currentPageItemType);

            View.BackFader.DoFade(true);
            View.ShopFader.DoFade(false);
            
            var startPos = new Vector3(View.CanvasRect.rect.width, View.transform.localPosition.y, 0f);
            View.transform.localPosition = startPos;
            View.transform.DOLocalMove(Vector3.zero, 0.3f).SetEase(Ease.OutCubic).SetUpdate(true);
        }

        public void HideAnimation()
        {
            View.BackFader.DoFade(false);
            View.ShopFader.DoFade(false);

            View.transform
                .DOLocalMove(
                    new Vector3(View.CanvasRect.rect.width, View.transform.localPosition.y,
                        View.transform.localPosition.z), 0.3f).SetEase(Ease.OutCubic).SetUpdate(true);;
        }

        public void UpdateShopInfo(GameDataComponent gameData)
        {
            foreach (var itemContainerView in _runtimeItemContainerViews)
            {
                Object.Destroy(itemContainerView.gameObject);
            }
            _runtimeItemContainerViews.Clear();
            
            View.PlayerWalletView.SetWalletData(gameData.ValueGameData);

            var allItems = _shopItemsBase.GetAllConfigs();
            foreach (var shopItemConfig in allItems)
            {
                if(shopItemConfig.ItemID.ItemID.ItemType != _currentPageItemType)
                    continue;
                
                var itemContainer = Object.Instantiate(View.ShopItemContainerViewPrefab, View.ShopItemsContainer);
                _runtimeItemContainerViews.Add(itemContainer);

                if (gameData.ReferenceGameData.PlayerItems.Exists(x => x.itemID == shopItemConfig.ItemID.ItemID))
                {
                    var playerItemData =
                        gameData.ReferenceGameData.PlayerItems.Find(x => x.itemID == shopItemConfig.ItemID.ItemID);
                    itemContainer.SetItemContainerView(shopItemConfig, playerItemData, gameData.ValueGameData);
                }
                else
                {
                    itemContainer.SetItemContainerView(shopItemConfig, null, gameData.ValueGameData);
                }

                itemContainer.ButtonBuy.Button.OnClickAsObservable().Subscribe(x =>
                {
                    OnBuyItemButton(shopItemConfig);
                }).AddTo(itemContainer).AddTo(View);
                
                itemContainer.ButtonEquip.OnClickAsObservable().Subscribe(x =>
                {
                    OnEquipButton(shopItemConfig);
                }).AddTo(itemContainer).AddTo(View);
            }
        }

        private void OnEquipButton(ShopItemConfig item)
        {
            _world.NewEntity().Get<EquipNewItemEventComponent>().EquipItem = item;
        }

        private void OnBuyItemButton(ShopItemConfig item)
        {
            View.ShopFader.DoFade(true);
            View.CheckPopupView.Open($"Buy a {item.NameInShop} for {item.PriceConfig.Price}", item.PriceConfig.CurrencyType, answer => {
                View.ShopFader.DoFade(false);
                if(answer)
                    ClaimItem(item);
            });
        }

        private void ClaimItem(ShopItemConfig item)
        {
            _world.NewEntity().Get<ClaimNewItemEventComponent>().ClaimedItem = item;
        }
    }
}