using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Utils.Extensions;
using Game.Ui.InGameMenu;
using Leopotam.Ecs;
using Runtime.Game.Ui;
using Runtime.Game.Ui.Windows.MainMenu;
using SimpleUi.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace ECS.Game.Systems
{
    public class GameStartStageSystem : GameStageSystem
    {
        [Inject] private GameContext G;
        
        protected override EcsWorld World { get; set; }
        protected override EGameStage Stage { get; set; } = EGameStage.GameStart;

        protected override void OnPreEnter()
        {
            G.RuntimeData.Get1(0).StarsEarnedThisRun = 0;
        }

        protected override void OnEnter()
        {
            G.SignalBus.OpenWindow<RunnerMainMenuWindow>();
        }

        protected override void OnPreExit()
        {
            G.SignalBus.BackWindow();

        }
    }
}