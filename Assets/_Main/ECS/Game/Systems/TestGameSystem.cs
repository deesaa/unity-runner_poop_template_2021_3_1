using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using Runtime.Services.CommonPlayerData.Data;
using UnityEngine;
using Zenject;

public class TestGameSystem : IEcsUpdateSystem
{
    private EcsWorld _world;
    private EcsFilter<GameDataComponent> _gameData;
    private EcsFilter<UIdComponent, MonoLinkComponent<PlayerView>> _player;
    [Inject] private SignalBus _signalBus;
    public void Run()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _gameData.Get1(0).ValueGameData.EarnedGems += 5;
            _gameData.Get1(0).ValueGameData.EarnedStars += 7;
            _signalBus.Fire(new SignalUpdateData()
            {
                TargetUI = ETargetUI.Shop,
                GameData = _gameData.Get1(0)
            });
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            _gameData.Get1(0).ValueGameData.EarnedGems = 0;
            _gameData.Get1(0).ValueGameData.EarnedStars = 0;
            _gameData.Get1(0).ReferenceGameData.PlayerItems.Clear();
            _signalBus.Fire(new SignalUpdateData()
            {
                TargetUI = ETargetUI.Shop,
                GameData = _gameData.Get1(0)
            });
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            _gameData.Get1(0) = new GameDataComponent();
            _world.NewEntity().Get<SaveGameDataEventComponent>();
        }
    }
}