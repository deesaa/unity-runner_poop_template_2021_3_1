using System;
using System.Collections.Generic;
using DataBase.Game;
using DG.Tweening;
using ECS.Game.Components;
using ECS.Game.Systems;
using ECS.Utils.Extensions;
using Game.SceneLoading;
using Leopotam.Ecs;
using Runtime.DataBase.General.GameCFG;
using Runtime.Services.CommonPlayerData;
using Runtime.Services.CommonPlayerData.Data;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UnityEngine;
using Utils.UiExtensions;
using Zenject;

namespace Game.Ui.InGameMenu
{
    /*public class InGameMenuViewController : UiController<InGameMenuView>, IInitializable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly EcsWorld _world;
        private readonly SignalBus _signalBus;
        [Inject] private ICommonGameDataService<CommonGameData> _gameData;
        [Inject] private IGameConfig _gameConfig;
        [Inject] private IGameStageService _gameStage;


        public InGameMenuViewController(ISceneLoadingManager sceneLoadingManager, EcsWorld world, SignalBus signalBus)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _world = world;
            _signalBus = signalBus;
        }

        public override void OnShow()
        {
            base.OnShow();
            
            var startPos = new Vector3(View.CanvasRect.rect.width, View.transform.position.y, View.transform.position.z);
            View.transform.localPosition = startPos;
            View.transform.DOLocalMove(new Vector3(0f, 0f, View.transform.position.z), 1f);
            

            HideAll();

            Debug.Log(_gameStage.CurrentStage);
            switch (_gameStage.CurrentStage)
            {
                case EGameStage.GameOver:
                    View.RetryButton.gameObject.SetActive(true);
                    break;
                case EGameStage.LevelCompleted:
                    View.NextLevelButton.gameObject.SetActive(true);
                    break;
                case EGameStage.GameStart:
                    View.PlayButton.gameObject.SetActive(true);
                    View.NextLevelButton.interactable = true;
                    break;
                case EGameStage.Play:
                    break;
                case EGameStage.FinalWheel:
                    View.NextLevelButton.gameObject.SetActive(true);
                    View.NextLevelButton.interactable = false;
                    Observable.Timer(TimeSpan.FromSeconds(1f)).Subscribe(x => View.NextLevelButton.interactable = true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HideAll()
        {
            View.PlayButton.gameObject.SetActive(false);
            View.RetryButton.gameObject.SetActive(false);
            View.NextLevelButton.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            View.PlayButton.OnClickAsObservable().Subscribe(x => OnPlayButton()).AddTo(View.PlayButton).AddTo(View);
            View.RetryButton.OnClickAsObservable().Subscribe(x => OnRestart()).AddTo(View.PlayButton).AddTo(View);
            View.NextLevelButton.OnClickAsObservable().Subscribe(x => OnNextLevelButton()).AddTo(View.PlayButton).AddTo(View);
            

            _signalBus.GetStream<SignalHide>().Subscribe(x =>
            {
                var endPos = new Vector3(-View.CanvasRect.rect.width, View.transform.position.y, View.transform.position.z);
                View.transform.DOLocalMove(new Vector3(endPos.x, endPos.y, endPos.z), 1f);
            }).AddTo(View);
        }

        private void OnPlayButton()
        {
            _gameStage.ChangeStage(EGameStage.Play, 1f);
        }
        
        private void OnRestart()
        {
            Amplitude.Instance.logEvent("restart", new Dictionary<string, object>()
            {
                {"level", _gameData.GetData().GameData.ValueGameData.CurrentLevelIndex},
            });
            
            DOTween.KillAll();
            _gameStage.ChangeStage(EGameStage.Restart);
        }

        private void OnNextLevelButton()
        {
            DOTween.KillAll();
            _sceneLoadingManager.LoadScene("Level_"+(_gameData.GetData().GameData.ValueGameData.CurrentLevelIndex));
        }
    }*/
}