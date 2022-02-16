using System;
using DataBase.Game;
using DG.Tweening;
using ECS.Game.Systems;
using Game.SceneLoading;
using Game.Ui.InGameMenu;
using SimpleUi.Abstracts;
using SimpleUi.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils.UiExtensions;
using Zenject;

namespace Runtime.Game.Ui.Windows.MainMenu
{
    public class RunnerMainMenuViewController : UiController<RunnerMainMenuView>, IInitializable
    {
        private readonly SignalBus _signalBus;
        [Inject] private SceneData _sceneData;
        [Inject] private IGameStageService _gameStage;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        public RunnerMainMenuViewController(SignalBus signalBus, ISceneLoadingManager sceneLoadingManager)
        {
            _signalBus = signalBus;
            _sceneLoadingManager = sceneLoadingManager;
        }

        public void Initialize()
        {
            View.OnPointerDownAction = () =>
            {
                _gameStage.ChangeStage(EGameStage.Play);
            };
        }

        public override void OnShow()
        {
            base.OnShow();
        }

        private void HideAll()
        {
            
        }
        
        
    }
}