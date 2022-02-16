using DataBase.Game;
using DG.Tweening;
using ECS.Game.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace ECS.Game.Systems
{
    public class RestartGameStageSystem : GameStageSystem
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        [Inject] private IGameStageService _gameStage;
        private EcsFilter<GameDataComponent> _gameData;
        private EcsFilter<MonoLinkComponent<MainCameraGroup>> _camera;
        
        private EcsFilter<ReinitializableComponent> _objects;
        private EcsFilter<MonoLinkComponent<PlayerView>, DelayedDestroyComponent> _unitsToDestroy;
        private EcsFilter<PlayerComponent> _player;
        private EcsWorld _world;

        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.Restart;

        protected override void OnEnter()
        {
            Restart();
            _gameStage.ChangeStage(EGameStage.MainMenu);
        }

        private void Restart()
        {
            DOTween.KillAll();
            foreach (var i in _objects)
            {
                _objects.Get1(i).Value.Reinitialize();
            }
            
            _signalBus.BackWindow();

            foreach (var i in _unitsToDestroy)
            {
                _unitsToDestroy.Get2(i).Delay = 0f;
            }
        }
    }
}