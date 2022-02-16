
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
    public class GameHoodController : UiController<GameHoodView>, IInitializable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly EcsWorld _world;
        private readonly SignalBus _signalBus;
        [Inject] private IGameStageService _gameStage;


        private int _currentCoinCountView;
        public GameHoodController(ISceneLoadingManager sceneLoadingManager, EcsWorld world, SignalBus signalBus)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _world = world;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.GetStream<SignalUpdateLevelProgress>().Subscribe(x =>
            {
                View.UpdateLevelProgress(x.Value);
            }).AddTo(View);

            _signalBus.GetStream<SignalUpdateData>().Subscribe(x =>
            {
                View.levelIndex.text = $"LEVEL {x.GameData.ValueGameData.CurrentLevelIndex + 1}";
            }).AddTo(View);

            _signalBus.GetStream<SignalUpdateData>().Subscribe(x =>
            {
                if((x.TargetUI & ETargetUI.GameHood) != ETargetUI.GameHood)
                    return;
                UpdateGameHoodInfo(x.GameData, x.RuntimeData);
            }).AddTo(View);

            /*_signalBus.GetStream<SignalOpenFinishPopup>().Subscribe(x =>
            {
                View.LevelRewardsView.Set(x.RewardCoins);
                View.FinishCheckPopupView.Open("Do you want to complete\n the mission?", ECurrencyType.Gems, answer =>
                {
                    if(answer)
                        _gameStage.ChangeStage(EGameStage.GameOver, 0.3f);
                });
            }).AddTo(View);*/
        }

        public void UpdateGameHoodInfo(GameDataComponent gameData, RuntimeDataComponent runtimeData)
        {
            View.coinsCount.text = (runtimeData.StarsEarnedThisRun + gameData.ValueGameData.EarnedStars).ToString();
            View.gemsCount.text = gameData.ValueGameData.EarnedGems.ToString();
            View.levelIndex.text = (gameData.ValueGameData.CurrentLevelIndex + 1).ToString();
        }
    }
}