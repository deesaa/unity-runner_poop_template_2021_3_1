using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components.Flags;
using ECS.Game.Components.Input;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Runtime.DataBase.General.GameCFG;
using UnityEngine;
using Zenject;

public class PlayerSideMoveSystem : ReactiveSystem<PointerDragComponent>
{
    [Inject] private IGameConfig _gameConfig;
    [Inject] private IGameStageService _gameStage;
        
    private readonly EcsFilter<MonoLinkComponent<PlayerView>, RemapPointComponent, PlayerComponent> _player;
    private EcsWorld _world;
    protected override EcsFilter<PointerDragComponent> ReactiveFilter { get; }

    protected override bool DeleteEvent => false;
    protected override void Execute(EcsEntity entity)
    {
        if(_gameStage.CurrentStage != EGameStage.Play)
            return;
        if(_player.IsEmpty())
            return;
            
        var inputPos = entity.Get<PointerDragComponent>().Position;
        var input = _player.Get2(0).Input.x ;
        var mapValueStart = _player.Get2(0).Position.x;
        var newX = inputPos.x.Remap(
            input - 20, 
            input + 20, 
            mapValueStart - _gameConfig.GlobalConfig.Sensitivity, 
            mapValueStart + _gameConfig.GlobalConfig.Sensitivity);
        
        Vector3 bounds = _gameConfig.GlobalConfig.SideMoveBounds;
        newX = Mathf.Clamp(newX, bounds.x, bounds.y);
        
        var sideMoveRoot = _player.Get1(0).View.SideMoveRoot;
        sideMoveRoot.localPosition = new Vector3(newX, sideMoveRoot.localPosition.y, sideMoveRoot.localPosition.z);
    }
}