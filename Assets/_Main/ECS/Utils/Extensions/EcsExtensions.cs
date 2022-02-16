using DataBase.Game;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using ECS.Game.Components.Input;
using ECS.Game.Systems;
using Leopotam.Ecs;
using PdUtils;
using UnityEngine;

namespace ECS.Utils.Extensions
{
    public static class EcsExtensions
    {
        public static EcsEntity GetEntity<T>(this EcsWorld world) where T : struct
        {
            var filter = world.GetFilter(typeof(EcsFilter<T>));
            foreach (var i in filter)
                return filter.GetEntity(i);
            Debug.LogError("EcsExtensions GetEntity null");
            return default;
        }
        
        public static EcsEntity GetEntity<T, T2>(this EcsWorld world) where T : struct where T2 : struct
        {
            var filter = world.GetFilter(typeof(EcsFilter<T, T2>));
            foreach (var i in filter)
                return filter.GetEntity(i);
            return default;
        }
        
        public static EcsEntity GetEntityWithUid(this EcsWorld world, Uid uid)
        {
            var value = new EcsEntity();
            var filter = world.GetFilter(typeof(EcsFilter<UIdComponent>));
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);
                if (uid.Equals(entity.Get<UIdComponent>().Value))
                    return entity;
            }
            return value;
        }

        public static void DeclareOneFrameEvents(this EcsSystems systems)
        {
            systems.OneFrame<TimerTickEventComponent>();
            systems.OneFrame<PointerUpComponent>();
            systems.OneFrame<PointerDragComponent>();
            systems.OneFrame<PointerDownComponent>();
            systems.OneFrame<StickInputComponent>();
        }
    }
}