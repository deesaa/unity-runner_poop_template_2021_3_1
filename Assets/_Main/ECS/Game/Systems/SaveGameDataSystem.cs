using System.Collections.Generic;
using ECS.Core.Utils.ReactiveSystem;
using Leopotam.Ecs;
using Runtime.Services.CommonPlayerData;
using Runtime.Services.CommonPlayerData.Data;
using UnityEngine;
using Zenject;

public class SaveGameDataSystem : ReactiveSystem<SaveGameDataEventComponent>
{
    [Inject] private readonly ICommonGameDataService<CommonGameData> _savedGameData;
    private EcsFilter<GameDataComponent> _gameData;
    private readonly EcsWorld _world;
    protected override EcsFilter<SaveGameDataEventComponent> ReactiveFilter { get; }
    protected override void Execute(EcsEntity playerEntity)
    {
        var data = new CommonGameData();
        data.GameData = _gameData.Get1(0);
        _savedGameData.Save(data);


        Debug.Log("SAVEE");
    }
}