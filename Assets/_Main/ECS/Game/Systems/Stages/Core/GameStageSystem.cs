using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public abstract class GameStageSystem : IEcsInitSystem
    {
        protected abstract EcsWorld World { get; set; }
        protected abstract EGameStage Stage { get; set; }

        protected EcsEntity Entity;
        public void Init()
        {
            if(Stage == EGameStage.Empty)
                return;

            Entity = World.NewEntity();
            Entity.Get<StageHandlerComponent>() = new StageHandlerComponent()
            {
                Stage = Stage,
                OnEnter = OnEnter,
                OnPreEnter = OnPreEnter,
                OnExit = OnExit,
                OnPreExit = OnPreExit,
                Update = Update
            };
        }
        
        protected virtual void OnPreEnter() {}
        protected virtual void OnEnter() {}
        protected virtual void OnPreExit() {}
        protected virtual void OnExit() {}
        protected virtual void Update() {}
    }
}