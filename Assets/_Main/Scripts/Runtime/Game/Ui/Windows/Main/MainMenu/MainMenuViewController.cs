using DataBase.Game;
using DG.Tweening;
using ECS.Game.Systems;
using Game.SceneLoading;
using Game.Ui.InGameMenu;
using SimpleUi.Abstracts;
using SimpleUi.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils.UiExtensions;
using Zenject;

namespace Runtime.Game.Ui.Windows.MainMenu
{
    public class MainMenuViewController : UiController<MainMenuView>, IInitializable
    {
        private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        [Inject] private IGameStageService _gameStage;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        public MainMenuViewController(SignalBus signalBus, ISceneLoadingManager sceneLoadingManager)
        {
            _signalBus = signalBus;
            _sceneLoadingManager = sceneLoadingManager;
        }

        public void Initialize()
        {
            View.PlayButton.OnClickAsObservable().Subscribe(x =>
            {
                _gameStage.ChangeStage(EGameStage.GameStart);
            }).AddTo(View);
            
            View.ShopButton.OnClickAsObservable().Subscribe(x =>
            {
                _gameStage.ChangeStage(EGameStage.MenuShop, 0.3f);
            }).AddTo(View);
            
            View.RestartButton.OnClickAsObservable().Subscribe(x =>
            {
                _gameStage.ChangeStage(EGameStage.Restart, 0.3f);
            }).AddTo(View);
            
            View.SettingsOpenButton.OnClickAsObservable().Subscribe(x =>
            {
                View.SettingsUiView.gameObject.SetActive(true);
                View.MainButtonsFader.DoFade(true);
            }).AddTo(View);
            
            View.SettingsUiView.CloseButton.OnClickAsObservable().Subscribe(x =>
            {
                View.SettingsUiView.gameObject.SetActive(false);
                View.MainButtonsFader.DoFade(false);
            }).AddTo(View);
            
            _signalBus.GetStream<SignalHide>().Subscribe(x =>
            {
                if((x.TargetUI & ETargetUI.MainMenu) != ETargetUI.MainMenu)
                    return;
                
                HideAnimation();
            }).AddTo(_sceneData);

            _signalBus.GetStream<SignalUpdateData>().Subscribe(x =>
            {
                if((x.TargetUI & ETargetUI.MainMenu) != ETargetUI.MainMenu)
                    return;
                
                UpdateData(x.GameData);
            }).AddTo(View);
        }

        public override void OnShow()
        {
            base.OnShow();

            Debug.Log(_gameStage.CurrentStage);
            if (_gameStage.CurrentStage == EGameStage.MainMenu)
            {
                View.PlayButton.gameObject.SetActive(true);
                View.ShopButton.gameObject.SetActive(true);
                View.SettingsOpenButton.gameObject.SetActive(true);
                View.RestartButton.gameObject.SetActive(false);
            } 
            else if (_gameStage.CurrentStage == EGameStage.GameOver)
            {
                View.PlayButton.gameObject.SetActive(false);
                View.ShopButton.gameObject.SetActive(false);
                View.SettingsOpenButton.gameObject.SetActive(false);
                View.RestartButton.gameObject.SetActive(true);
            }

            var startPos = new Vector3(View.CanvasRect.rect.width, View.transform.localPosition.y, 0f);
            View.transform.localPosition = startPos;
            View.transform.DOLocalMove(Vector3.zero, 0.3f).SetEase(Ease.OutCubic).SetUpdate(true);;
        }

        private void HideAnimation()
        {
            View.transform
                .DOLocalMove(
                    new Vector3(View.CanvasRect.rect.width, View.transform.localPosition.y,
                        View.transform.localPosition.z), 0.3f).SetEase(Ease.OutCubic).SetUpdate(true);
        }

        public void UpdateData(GameDataComponent dataComponent)
        {
            View.LevelText.text = $"Lvl {dataComponent.ValueGameData.CurrentLevelIndex + 1}";
            View.LevelText2.text = $"Lvl {dataComponent.ValueGameData.CurrentLevelIndex + 1}";
            View.ShopNotification.gameObject.SetActive(dataComponent.ValueGameData.IsNewItemAvaibleNotification);
        }
        
        private void OnNewGame()
        {
            _sceneLoadingManager.LoadScene("Game");
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}