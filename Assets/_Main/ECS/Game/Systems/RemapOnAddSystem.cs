using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using ECS.Game.Components.Input;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems
{
    public class RemapOnAddSystem : ReactiveSystem<EventAddComponent<RemapPointComponent>>
    {
        protected override EcsFilter<EventAddComponent<RemapPointComponent>> ReactiveFilter { get; }
        private EcsFilter<MonoLinkComponent<PlayerView>, PlayerComponent> _player;
        protected override void Execute(EcsEntity entity)
        {
            if(_player.IsEmpty())
                return;

            entity.Get<RemapPointComponent>().Position = _player.Get1(0).View.SideMoveRoot.transform.localPosition;
        }
    }
}