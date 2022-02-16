using DataBase.Game;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Game.Components.Input;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class StickInputSystem : IEcsUpdateSystem
{
    private EcsFilter<PointerDownComponent> _pointnerDown;
    private EcsFilter<PointerUpComponent> _pointnerUp;
    private EcsFilter<PointerDragComponent> _pointnerDrag;
    [Inject] private IGameStageService _gameStage;
    
    private EcsWorld _world;
    private bool isHold = false;
    private Vector2 _firstPosition;
    private Vector2 _lastPosition;
    public void Run()
    {
        if (_gameStage.CurrentStage != EGameStage.Play)
        {
            _lastPosition = Vector2.zero;
            _firstPosition = Vector2.zero;
            isHold = false;
            
            StickInputComponent newInput = new StickInputComponent()
            {
                Direction = Vector2.zero
            };
            _world.NewEntity().Get<StickInputComponent>() = newInput;
            return;
        }
            
        
        if (isHold)
        {
            if (!_pointnerDrag.IsEmpty())
                _lastPosition = _pointnerDrag.Get1(0).Position;
            
            if (!_pointnerUp.IsEmpty())
            {
                isHold = false;
            }
        }
        else
        {
            if (!_pointnerDown.IsEmpty())
            {
                isHold = true;
                _lastPosition = _firstPosition = _pointnerDown.Get1(0).Position;
            }
        }

        if (isHold)
        {
            StickInputComponent newInput = new StickInputComponent()
            {
                Direction = (_lastPosition - _firstPosition).normalized
            };
            
            _world.NewEntity().Get<StickInputComponent>() = newInput;
        }
        else
        {
            StickInputComponent newInput = new StickInputComponent()
            {
                Direction = Vector2.zero
            };
            
            _world.NewEntity().Get<StickInputComponent>() = newInput;
        }
    }
}