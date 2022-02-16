using System;
using DG.Tweening;
using Game.SceneLoading;
using Plugins.PdUtils.Runtime.PdAudio;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using Zenject;

namespace Game.Ui.BlackScreen
{
    public class StickInputViewController : UiController<StickInputView>, IInitializable
    {
        private readonly SignalBus _signalBus;

        public StickInputViewController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
           
        }
    }
}