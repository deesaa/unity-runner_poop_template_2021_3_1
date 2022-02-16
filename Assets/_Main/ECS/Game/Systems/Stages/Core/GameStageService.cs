using System;
using System.Reflection;
using DataBase.Game;
using ECS.Game.Systems;
using Leopotam.Ecs;
using UniRx;
using UnityEngine;
using Zenject;

//Stage1.ChangeStage(Stage2) -> Stage1.OnPreExit -> Stage2.OnPreEnter -> Transition(time) -> Stage1.OnExit -> Stage2.OnEnter

public class GameStageService : IEcsInitSystem, IGameStageService
{
    private EGameStage LastStage;
    [Inject] private SceneData _sceneData;
    private bool _inTransition;

    public EGameStage CurrentStage
    {
        get
        {
            if (_activeStage.IsEmpty())
                return EGameStage.Empty;
            return _activeStage.Get1(0).Stage;
        }
    }


    private EcsFilter<StageHandlerComponent> _stages;
    private EcsFilter<StageHandlerComponent, ActiveComponent> _activeStage;

    public void Init() { }

    public void ChangeStage(EGameStage TargetStage, float transitionTime)
    {
        if (_inTransition)
        {
            Debug.LogWarning(
                $"Can't change stage while transition : TargetStage : {TargetStage}");
        }
        
        if (TargetStage == EGameStage.Transition)
        {
            Debug.LogWarning(
                $"Can't directly change on Transition : TargetStage : {TargetStage}");
        }

        _inTransition = true;

        Action OnPreExit = null;
        EGameStage PreExitStage = EGameStage.Empty;
        Action OnPreEnter = null;
        EGameStage PreEnterStage = EGameStage.Empty;

        foreach (var i in _stages)
        {
            if (_stages.Get1(i).Stage == TargetStage)
            {
                OnPreEnter = _stages.Get1(i).OnPreEnter;
                PreEnterStage = _stages.Get1(i).Stage;
                break;
            }
        }

        foreach (var i in _activeStage)
        {
            OnPreExit = _activeStage.Get1(i).OnPreExit;
            PreExitStage = _activeStage.Get1(i).Stage;
            LastStage = _activeStage.Get1(i).Stage;
            _activeStage.GetEntity(i).Del<ActiveComponent>();
            break;
        }
        
        foreach (var i in _stages)
        {
            if (_stages.Get1(i).Stage == EGameStage.Transition)
            {
                _stages.GetEntity(i).Get<ActiveComponent>();
            }
        }
        
        Debug.Log($"STAGE: PreExit {PreExitStage}");
        OnPreExit?.Invoke();
        Debug.Log($"STAGE: PreEnter {PreEnterStage}");
        OnPreEnter?.Invoke();
        Debug.Log($"STAGE: ------------- ENTER TRANSITION -----------------");

        if (transitionTime <= 0)
        {
            DoChange(TargetStage);
        }
        else
        {
            Observable.Timer(TimeSpan.FromSeconds(transitionTime), Scheduler.MainThreadIgnoreTimeScale).Subscribe(x =>
            {
                DoChange(TargetStage);
            }).AddTo(_sceneData);
        }
    }

    private void DoChange(EGameStage TargetStage)
    {
        Action OnExit = null;
        EGameStage ExitStage = EGameStage.Empty;
        Action OnEnter = null;
        EGameStage EnterStage = EGameStage.Empty;

        foreach (var i in _stages)
        {
            if (_stages.Get1(i).Stage == LastStage)
            {
                OnExit = _stages.Get1(i).OnExit;
                ExitStage = LastStage;
            }
            if (_stages.Get1(i).Stage == TargetStage)
            {
                OnEnter = _stages.Get1(i).OnEnter;
                EnterStage = _stages.Get1(i).Stage;
                _stages.GetEntity(i).Get<ActiveComponent>();
            }
            if (_stages.Get1(i).Stage == EGameStage.Transition)
            {
                _stages.GetEntity(i).Del<ActiveComponent>();
            }
        }

        _inTransition = false;
            
        Debug.Log($"STAGE: ------------- EXIT TRANSITION -----------------");
        Debug.Log($"STAGE: Exit {ExitStage}");
        OnExit?.Invoke();
        Debug.Log($"STAGE: Enter {EnterStage}");
        OnEnter?.Invoke();
    }
}