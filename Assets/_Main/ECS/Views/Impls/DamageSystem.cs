using ECS.Core.Utils.ReactiveSystem;
using ECS.Utils.Extensions;
using Leopotam.Ecs;

public class DamageSystem : ReactiveSystem<DealDamageComponent>
{
    protected override EcsFilter<DealDamageComponent> ReactiveFilter { get; }
    protected override void Execute(EcsEntity entity)
    {
        if (entity.Has<MonoLinkComponent<DestroyableEnvironment>>())
        {
            entity.GetAndFire<DeathComponent>();
        }
        else if (entity.Has<MonoLinkComponent<EnemyView>>())
        {
            entity.GetAndFire<DeathComponent>();
        } 
        else if (entity.Has<MonoLinkComponent<PlayerView>>())
        {
            entity.GetAndFire<DeathComponent>();
        }
    }
}