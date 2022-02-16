using Game.Ui.InGameMenu;
using Runtime.Game.Ui;
using Runtime.Game.Ui.Windows.MainMenu;
using Runtime.Game.Ui.Windows.Shop;
using Runtime.Initializers;
using Runtime.UI.QuitConcentPopUp;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindWindows();
            Container.BindInterfacesAndSelfTo<GameInitializer>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<ConsentWindow>().AsSingle();
            //Container.BindInterfacesAndSelfTo<InGameMenuWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameHudWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShopWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<RunnerMainMenuWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelFinishUiWindow>().AsSingle();
        }
    }
}