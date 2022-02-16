using Game.Ui.SplashScreen.Impls;
using Initializers;
using Zenject;

namespace Installers
{
    public class SplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SplashLoadGameScreenWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<SplashLoadGameInitializer>().AsSingle();
        }
    }
}