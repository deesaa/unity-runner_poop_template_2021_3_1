using DataBase.Game;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using Runtime.Game.Ui;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class PlayStageSystem : GameStageSystem
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        private EcsFilter<GameDataComponent> _gameData;
        private EcsFilter<MonoLinkComponent<MainCameraGroup>> _camera;
        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.Play;

        protected override void OnPreEnter()
        {
            _camera.Get1(0).View.SetState(EGameStage.Play);
        }
        
        protected override void OnEnter()
        {
            _signalBus.OpenWindow<GameHudWindow>();
        }

        protected override void OnPreExit() { }
        protected override void OnExit() { }
    }
}