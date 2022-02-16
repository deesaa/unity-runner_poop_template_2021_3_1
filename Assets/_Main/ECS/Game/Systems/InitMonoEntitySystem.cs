using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Utils.Extensions;
using ECS.Views;
using Leopotam.Ecs;

public abstract class InitMonoEntitySystem<T> : ReactiveSystem<EventAddComponent<MonoLinkComponent<T>>> where T : ILinkable
{
    protected override void Execute(EcsEntity entity)
    {
        Init(entity, entity.Get<MonoLinkComponent<T>>().View);
    }

    protected abstract void Init(EcsEntity viewEntity, T view);
}