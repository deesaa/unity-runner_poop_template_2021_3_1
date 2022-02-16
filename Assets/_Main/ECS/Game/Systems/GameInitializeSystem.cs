using System;
using System.Collections.Generic;
using DataBase.Game;
using DG.Tweening;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Ecs.Views.Linkable.Impl;
using Game.Ui.InGameMenu;
using GameAnalyticsSDK;
using Leopotam.Ecs;
using PathCreation;
using Runtime.DataBase.General.GameCFG;
using Runtime.Services.CommonPlayerData;
using Runtime.Services.CommonPlayerData.Data;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace ECS.Game.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        [Inject] private readonly ICommonGameDataService<CommonGameData> _savedGameData;
        [Inject] private readonly IGameConfig _gameConfig;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        private EcsFilter<GameDataComponent> _gameData;
        private EcsFilter<RuntimeDataComponent> _runtimeData;
        [Inject] private IGameStageService _gameStage;
        private readonly EcsWorld _world;
        [Inject] private Canvas Canvas;
        
        public void Init()
        {
        
            var runtimeData = new RuntimeDataComponent();
            
            LoadGameData();

            foreach (var mainCameraGroup in Object.FindObjectsOfType<MainCameraGroup>())
            {
                _world.CreateMonoLinkEntity(mainCameraGroup);
                Canvas.worldCamera = mainCameraGroup.UICamera;
            }

            _world.NewEntity().Get<MonoComponent<PathCreator>>().Value = Object.FindObjectOfType<PathCreator>();

            foreach (var playerView in Object.FindObjectsOfType<PlayerView>())
            {
                var player = _world.CreateMonoLinkEntity(playerView);
            }
            
            foreach (var destroyableEnvironment in Object.FindObjectsOfType<DestroyableEnvironment>())
                _world.CreateMonoLinkEntity(destroyableEnvironment);
            
            foreach (var obstacleView in Object.FindObjectsOfType<ObstacleView>())
                _world.CreateMonoLinkEntity(obstacleView);
            
            foreach (var finalSceneView in Object.FindObjectsOfType<FinalSceneView>())
                _world.CreateMonoLinkEntity(finalSceneView);
            
            foreach (var enemyView in Object.FindObjectsOfType<CoinView>())
                _world.CreateMonoLinkEntity(enemyView);
            
            foreach (var choiceReactiveView in Object.FindObjectsOfType<ChoiceReactiveView>(true))
                _world.CreateMonoLinkEntity(choiceReactiveView);
            
            foreach (var finishView in Object.FindObjectsOfType<FinishView>())
                _world.CreateMonoLinkEntity(finishView);
            
            foreach (var roadResourceView in Object.FindObjectsOfType<RoadResourceView>())
                _world.CreateMonoLinkEntity(roadResourceView);
            
            foreach (var gateView in Object.FindObjectsOfType<GateView>())
                _world.CreateMonoLinkEntity(gateView);
            
            _world.NewEntity().Get<RuntimeDataComponent>() = runtimeData;

            Amplitude.Instance.logEvent("level_start", new Dictionary<string, object>() {
                {"level", _gameData.Get1(0).ValueGameData.CurrentLevelIndex}
            });
            
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, $"Level {_gameData.Get1(0).ValueGameData.CurrentLevelIndex}");

            _signalBus.Fire(new SignalUpdateData()
            {
                TargetUI = ETargetUI.Shop | ETargetUI.MainMenu | ETargetUI.GameHood,
                GameData = _gameData.Get1(0)
            });
            
            Observable.NextFrame().Subscribe(x => _gameStage.ChangeStage(EGameStage.GameStart)).AddTo(_sceneData);
        }

        private void LoadGameData()
        {
            foreach (var i in _gameData)
                _gameData.GetEntity(i).Destroy();

            var savedPlayerData =  _savedGameData.GetData();
            var playerData = savedPlayerData.GameData;

            playerData.ValueGameData.CurrentLevelIndex = _sceneData.LevelIndex;
            playerData.ValueGameData.CurrentLevelStartTime = DateTime.Now;



            _world.NewEntity().Get<GameDataComponent>() = playerData;
        }
    }
}