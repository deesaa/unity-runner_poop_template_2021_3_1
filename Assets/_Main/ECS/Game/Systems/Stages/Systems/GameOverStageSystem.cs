using System.Collections.Generic;
using _Main.Scripts.Runtime.Services;
using DataBase.Game;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using GameAnalyticsSDK;
using Leopotam.Ecs;
using Runtime.Game.Ui.Windows.MainMenu;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class GameOverStageSystem : GameStageSystem
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        private EcsFilter<GameDataComponent> _gameData;
        private EcsFilter<MonoLinkComponent<MainCameraGroup>> _camera;
        [Inject] private VibrationService _vibrationService;
        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.GameOver;

        protected override void OnPreEnter()
        {
            Amplitude.Instance.logEvent("level_fail", new Dictionary<string, object>() {
                {"level", _gameData.Get1(0).ValueGameData.CurrentLevelIndex}
            });
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"Level {_gameData.Get1(0).ValueGameData.CurrentLevelIndex}");
            _camera.Get1(0).View.SetState(EGameStage.GameOver);
            _vibrationService.Vibrate(_gameData.Get1(0).ValueGameData, 25);
        }

        protected override void OnEnter()
        {
            _signalBus.OpenWindow<MainMenuWindow>();
        }

        protected override void OnPreExit()
        {
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