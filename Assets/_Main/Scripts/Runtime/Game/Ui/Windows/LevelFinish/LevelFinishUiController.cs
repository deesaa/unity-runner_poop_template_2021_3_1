
using System;
using DataBase.Game;
using DG.Tweening;
using ECS.Game.Systems;
using Game.SceneLoading;
using Leopotam.Ecs;
using SimpleUi;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Ui.InGameMenu
{
    public class LevelFinishUiController : UiController<LevelFinishUiView>, IInitializable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly EcsWorld _world;
        private readonly SignalBus _signalBus;
        [Inject] private IGameStageService _gameStage;
        [Inject] private IFinishTextDatabase FinishTextDatabase;


        private int _currentCoinCountView;
        public LevelFinishUiController(ISceneLoadingManager sceneLoadingManager, EcsWorld world, SignalBus signalBus)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _world = world;
            _signalBus = signalBus;
        }

        public override void OnShow()
        {
            base.OnShow();
            Restart();
            ShowFinalStats();
        }

        public void Initialize()
        {
            _signalBus.GetStream<SignalUpdateData>().Subscribe(x =>
            {
                if((x.TargetUI & ETargetUI.LevelFinish) != ETargetUI.LevelFinish)
                    return;
                UpdateGameHoodInfo(x.GameData, x.RuntimeData);
            }).AddTo(View);

            View.ContinueButton.OnClickAsObservable().Subscribe(x =>
            {
                _gameStage.ChangeStage(EGameStage.LoadNextLevel);
            }).AddTo(View);

            View.OpenMoreButton.OnClickAsObservable().Subscribe(x =>
            {
                View.PopupView.Open(true);
            }).AddTo(View);
            
        }

        public void UpdateGameHoodInfo(GameDataComponent gameData, RuntimeDataComponent runtimeData)
        {
            
        }

        public void Restart()
        {
            foreach (var infoUiView in View.StatInfoUiViews)
            {
                infoUiView.SetProgress(0f);
                infoUiView.Hider.color = Color.white;
            }

            View.ContinueButton.gameObject.SetActive(false);
            View.OpenMoreButton.gameObject.SetActive(false);
        }

        public void UpdateText()
        {
            float currentMax = 0f;
            int maxIndex = 0;
            int i = 0;
            foreach (var infoUiView in View.StatInfoUiViews)
            {
                if (infoUiView.score > currentMax)
                {
                    currentMax = infoUiView.score;
                    maxIndex = i;
                }
                i++;
            }
            
            View.PopupView.SetText(FinishTextDatabase.Get(View.StatInfoUiViews[maxIndex].StatType));
            View.PopupView.SetTitle(View.StatInfoUiViews[maxIndex].StatType.ToString());
        }

        public void ShowFinalStats()
        {
            View.StatInfoUiViews[0].ShowStats(() =>
            {
                View.StatInfoUiViews[1].ShowStats(() =>
                {
                    View.StatInfoUiViews[2].ShowStats(() =>
                    {
                        View.StatInfoUiViews[3].ShowStats(() =>
                        {
                            Observable.Timer(TimeSpan.FromSeconds(0.3f))
                                .Subscribe(x => View.OpenMoreButton.gameObject.SetActive(true)).AddTo(View);
                            Observable.Timer(TimeSpan.FromSeconds(1f))
                                .Subscribe(x => View.ContinueButton.gameObject.SetActive(true)).AddTo(View);
                            
                            UpdateText();
                        });
                    });
                });
            });
        }
    }
}