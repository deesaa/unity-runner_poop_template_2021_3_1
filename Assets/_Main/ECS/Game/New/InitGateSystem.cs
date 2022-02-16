using System;
using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;


public class InitGateSystem : InitMonoEntitySystem<GateView>
{
    [Inject] private GameContext G;
    protected override EcsFilter<EventAddComponent<MonoLinkComponent<GateView>>> ReactiveFilter { get; }
    protected override void Init(EcsEntity viewEntity, GateView view)
    {
        view.LeftGateCollider.OnTriggerEnterAsObservable().Subscribe(x =>
        {
            if (x.transform.parent != null && G.Player.TryGetLinkOf(x.transform.parent.gameObject, out var playerEntity))
            {
                playerEntity.Get<ChoiceMadeEvent>().Choice = viewEntity.Get<GateComponent>().LeftGate;
                view.OnGateEnter(ESide.Left);
                playerEntity.Get<MonoLinkComponent<PlayerView>>().View.DoBeam();
            }
        }).AddTo(view);
        
        view.RightGateCollider.OnTriggerEnterAsObservable().Subscribe(x =>
        {
            if (x.transform.parent != null && G.Player.TryGetLinkOf(x.transform.parent.gameObject, out var playerEntity))
            {
                playerEntity.Get<ChoiceMadeEvent>().Choice = viewEntity.Get<GateComponent>().RightGate;
                view.OnGateEnter(ESide.Right);
                playerEntity.Get<MonoLinkComponent<PlayerView>>().View.DoBeam();
            }
        }).AddTo(view);
    }
}

public interface IRoadObstaclesDatabase
{
    public ObstacleView Get(EObstacleType type);
}

public enum EObstacleType
{
    Saw,
    Hammer,
    Spikes_1,
    Spikes_2
}

public enum EEnvironmentType
{
    Null,
    Default
}

public class ChoiceReactSystem : ReactiveSystem<ChoiceMadeEvent>
{
    [Inject] private GameContext G;
    private EcsFilter<MonoLinkComponent<ChoiceReactiveView>> _reactiveViews;
    protected override EcsFilter<ChoiceMadeEvent> ReactiveFilter { get; }
    protected override void Execute(EcsEntity entity)
    {
        if (entity.Has<PlayerComponent>())
        {
            foreach (var i in _reactiveViews)
            {
                _reactiveViews.Get1(i).View.OnChoice(entity.Get<ChoiceMadeEvent>().Choice);
            }
        }
    }
}

[Serializable]
public struct ChoiceReactiveSwitchElement
{
    public EGameChoice Choice;
    public GameObject GameObject;
}

public enum ESide
{
    Left,
    Right
}
public struct ChoiceMadeEvent
{
    public EGameChoice Choice;
}

public class InitFinishSystem : InitMonoEntitySystem<FinishView>
{
    [Inject] private GameContext G;
    
    protected override void Init(EcsEntity viewEntity, FinishView view)
    {
        view.OnTriggerEnterAsObservable().Subscribe(x =>
        {
            if (x.transform.parent != null && G.Player.TryGetLinkOf(x.transform.parent.gameObject, out var playerEntity))
            {
                G.GameStage.ChangeStage(EGameStage.LevelCompleted);
            }
        }).AddTo(view);
    }

    protected override EcsFilter<EventAddComponent<MonoLinkComponent<FinishView>>> ReactiveFilter { get; }
}

public class InitObstacleSystem : InitMonoEntitySystem<ObstacleView>
{
    [Inject] private GameContext G;

    protected override EcsFilter<EventAddComponent<MonoLinkComponent<ObstacleView>>> ReactiveFilter { get; }
    protected override void Init(EcsEntity viewEntity, ObstacleView view)
    {
        view.DamageCollider.OnTriggerEnterAsObservable().Subscribe(x =>
        {
            if (x.transform.parent != null && G.Player.TryGetLinkOf(x.transform.parent.gameObject, out var playerEntity))
            {
                view.OnDamage();
                playerEntity.Get<MonoLinkComponent<PlayerView>>().View.OnDamage();
                playerEntity.Get<PlayerComponent>().InjuredTimer = 3f;
                Debug.Log(playerEntity.Get<PlayerComponent>().InjuredTimer);
            }
        }).AddTo(view);
    }
}

public class InitRoadResourcesSystem : InitMonoEntitySystem<RoadResourceView>
{
    [Inject] private GameContext G;

    protected override EcsFilter<EventAddComponent<MonoLinkComponent<RoadResourceView>>> ReactiveFilter { get; }
    protected override void Init(EcsEntity viewEntity, RoadResourceView view)
    {
        view.OnTriggerEnterAsObservable().Subscribe(x =>
        {
            if (x.transform.parent != null && G.Player.TryGetLinkOf(x.transform.parent.gameObject, out var playerEntity))
            {
                view.OnTake();
                playerEntity.Get<MonoLinkComponent<PlayerView>>().View.OnTake();
            }
        }).AddTo(view);
    }
}