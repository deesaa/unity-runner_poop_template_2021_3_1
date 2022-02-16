using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UniRx;
using UniRx.Triggers;

public class InitBulletSystem : InitMonoEntitySystem<BulletView>
{
    protected override EcsFilter<EventAddComponent<MonoLinkComponent<BulletView>>> ReactiveFilter { get; }
    private EcsFilter<MonoLinkComponent<DestroyableEnvironment>> _destroyables;
    private EcsFilter<MonoLinkComponent<EnemyView>>.Exclude<DeathComponent> _enemies;
    private EcsFilter<MonoLinkComponent<PlayerView>>.Exclude<DeathComponent> _player;
    protected override void Init(EcsEntity bulletEntity, BulletView view)
    {
        view.OnCollisionEnterAsObservable().Subscribe(x =>
        {
            if (x.transform.parent != null)
            {
                if (_destroyables.TryGetLinkOf(x.transform.parent.gameObject, out var destroyable))
                {
                    destroyable.Get<DealDamageComponent>();
                }
            }
            
            if (_enemies.TryGetLinkOf(x.gameObject, out var enemy))
            {
                enemy.Get<DealDamageComponent>();
            }

            if (_player.TryGetLinkOf(x.gameObject, out var player))
            {
                player.Get<DealDamageComponent>();
            }
            
            bulletEntity.Get<MonoLinkComponent<BulletView>>().View.OnHit(x.contacts[0]);
            bulletEntity.Get<DelayedDestroyComponent>().Delay = 0f;
        }).AddTo(view);
    }
}