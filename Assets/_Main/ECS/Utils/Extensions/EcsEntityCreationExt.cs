using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components;
using ECS.Views;
using Leopotam.Ecs;
using PdUtils;
using Services.Uid;
using Zenject;

namespace ECS.Utils.Extensions
{
    public static class EcsEntityCreationExt
    {
        public static EcsEntity CreateUidEntity(this EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            return entity;
        }
        
        public static EcsEntity CreateUidEntity<T>(this EcsWorld world) where T : struct
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<T>();
            entity.Get<EventAddComponent<T>>();
            return entity;
        }
        
        public static EcsEntity CreateLinkedEntity<T>(this EcsWorld world, ILinkable link) where T : struct
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<LinkComponent>().View = link;
            entity.Get<T>();
            entity.Get<EventAddComponent<T>>();
            link.Link(entity);
            return entity;
        }
        
        public static EcsEntity CreateMonoLinkEntity<TV>(this EcsWorld world, TV link) where TV : ILinkable
        {
            var entity = world.CreateMonoLinkEntityBase(link);
            return entity;
        }

        private static EcsEntity CreateMonoLinkEntityBase<TV>(this EcsWorld world, TV link)
            where TV : ILinkable
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<MonoLinkComponent<TV>>().View = link;
            entity.Get<LinkComponent>().View = link;
            entity.Get<EventAddComponent<MonoLinkComponent<TV>>>();

            if (link is IReinitializable reinitializable)
                entity.Get<ReinitializableComponent>().Value = reinitializable;
            
            link.Link(entity);

            if (link is IMonoLinkCreator monoLinkCreator)
                monoLinkCreator.CreateLinks(world);

            return entity;
        }
        
        public static EcsEntity CreateMonoLinkEntity<TV>(this EcsWorld world, TV link, Uid parentUid) where TV : ILinkable
        {
            var entity = world.CreateMonoLinkEntityBase(link);
            entity.Get<OwnerComponent>().Value = parentUid;
            return entity;
        }
    }
}