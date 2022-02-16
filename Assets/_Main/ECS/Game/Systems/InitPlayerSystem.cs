using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Flags;
using ECS.Game.Systems.Initialize;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace ECS.Game.Systems
{
    public class InitPlayerSystem : InitMonoEntitySystem<PlayerView>
    {
        private EcsFilter<MonoLinkComponent<CoinView>, CoinComponent> _coins;
        private EcsFilter<MonoLinkComponent<EnemyView>, CoinComponent> _enemies;
        private EcsFilter<GameDataComponent> _gameData;
        private EcsFilter<RuntimeDataComponent> _runtimeData;
        [Inject] private IGameStageService _gameStage;
        [Inject] private SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        protected override EcsFilter<EventAddComponent<MonoLinkComponent<PlayerView>>> ReactiveFilter { get; }
        protected override void Init(EcsEntity playerEntity, PlayerView view)
        {
            view.OnTriggerEnterAsObservable().Subscribe(x =>
            {
                if(_gameStage.CurrentStage != EGameStage.Play)
                    return;
                
                if (_coins.TryGetLinkOf(x.gameObject, out var coinEntity))
                {
                    
                }
                
                if (_enemies.TryGetLinkOf(x.gameObject, out var enemyEntity))
                {
                    playerEntity.Get<DeathComponent>();
                }

            }).AddTo(view);
        }
    }
}