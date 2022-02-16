using ECS.Game.Systems;
using Game.Ui.InGameMenu;
using Signals;
using Zenject;

namespace Installers
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalMakeHudButtonsVisible>();
            Container.DeclareSignal<SignalBlackScreen>();
            Container.DeclareSignal<SignalQuestionChoice>();
            
            Container.DeclareSignal<SignalUpdateLevelProgress>();
            Container.DeclareSignal<SignalHide>();
            Container.DeclareSignal<SignalUpdateData>();
        }
    }
}