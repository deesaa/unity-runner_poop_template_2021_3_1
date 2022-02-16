using System.Collections.Generic;
using PdUtils.Interfaces;
using Runtime.Game.Ui;
using Runtime.Game.Ui.Windows.TouchPad;
using SimpleUi.Signals;
using Zenject;

namespace Runtime.Initializers
{
    public class GameInitializer : IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly ITouchpadViewController _touchpadViewController;
        private readonly IList<IUiInitializable> _uiInitializables; //late initialize after ecs init

        public GameInitializer(SignalBus signalBus, ITouchpadViewController touchpadViewController,
            IList<IUiInitializable> uiInitializables)
        {
            _signalBus = signalBus;
            _touchpadViewController = touchpadViewController;
            _uiInitializables = uiInitializables;
        }

        public void Initialize()
        {
            foreach (var ui in _uiInitializables)
                ui.Initialize();
            _signalBus.OpenWindow<GameHudWindow>();
            _touchpadViewController.SetActive(true);
        }
    }
}