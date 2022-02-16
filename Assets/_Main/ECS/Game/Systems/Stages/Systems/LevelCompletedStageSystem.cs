using System.Collections.Generic;
using DataBase.Game;
using ECS.Utils.Extensions;
using GameAnalyticsSDK;
using Leopotam.Ecs;
using Runtime.Game.Ui;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class LevelCompletedStageSystem : GameStageSystem
    {
        [Inject] private GameContext G;
        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.LevelCompleted;

        private EcsFilter<MonoLinkComponent<FinalSceneView>> _finalScene;

        protected override void OnPreEnter()
        {
            Amplitude.Instance.logEvent("level_complete", new Dictionary<string, object>() {
                {"level", G.GameData.Get1(0).ValueGameData.CurrentLevelIndex}
            });
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"Level {G.GameData.Get1(0).ValueGameData.CurrentLevelIndex}");
            G.Camera.Get1(0).View.SetState(EGameStage.LevelCompleted);
            _finalScene.Get1(0).View.OnFinalScene(true);
        }

        protected override void OnEnter()
        {
            G.SignalBus.OpenWindow<LevelFinishUiWindow>();
        }

        protected override void OnPreExit()
        {
            _finalScene.Get1(0).View.OnFinalScene(false);
            G.SignalBus.BackWindow();
        }
    }
}