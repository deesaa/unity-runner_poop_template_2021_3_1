using _Main.Scripts.Runtime.Services;
using DataBase.Game;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using Runtime.Game.Ui.Windows.MainMenu;
using Runtime.Game.Ui.Windows.Shop;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class MainMenuStageSystem : GameStageSystem
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        [Inject] private VibrationService _vibrationService;
        private EcsFilter<GameDataComponent> _gameData;
        private EcsFilter<MonoLinkComponent<MainCameraGroup>> _camera;
        private EcsFilter<RuntimeDataComponent> _runtimeData;
        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.MainMenu;
        
        protected override void OnEnter()
        {
            _vibrationService.Vibrate(_gameData.Get1(0).ValueGameData, 25);
            _signalBus.OpenWindow<MainMenuWindow>();
            _camera.Get1(0).View.SetState(EGameStage.MainMenu);
        }

        protected override void OnPreExit()
        {
            _runtimeData.Get1(0).ForceUnfreeze = false;
            _signalBus.Fire(new SignalHide()
            {
                TargetUI = ETargetUI.MainMenu
            });
        }

        protected override void OnExit()
        {
            _signalBus.BackWindow();
        }
    }
}