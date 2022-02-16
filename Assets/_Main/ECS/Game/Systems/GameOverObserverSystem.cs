using System;
using System.Collections.Generic;
using DataBase.Game;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

public class GameOverObserverSystem : IEcsUpdateSystem
{
    private EcsFilter<MonoLinkComponent<PlayerView>, PlayerComponent, DeathComponent> _playerDeath;
    private EcsFilter<GameDataComponent> _gameData;
    private EcsFilter<RuntimeDataComponent> _runtimeData;
    private EcsWorld _world;
    [Inject] private SignalBus _signalBus;
    [Inject] private IGameStageService _gameStage;

    public void Run()
    {
        if(_gameStage.CurrentStage != EGameStage.Play)
            return;
        
        if (!_playerDeath.IsEmpty())
        {
            _runtimeData.Get1(0).ForceUnfreeze = true;
            _gameStage.ChangeStage(EGameStage.GameOver, 1f);
        }
    }
}