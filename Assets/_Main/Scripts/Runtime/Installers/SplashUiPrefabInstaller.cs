using Game.Ui.BlackScreen;
using Game.Ui.SplashScreen.Impls;
using SimpleUi;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/SplashUiPrefabInstaller", fileName = "SplashUiPrefabInstaller")]
    public class SplashUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SplashLoadGameScreenView splashLoadGame;
        
        public override void InstallBindings()
        {
            Container.BindUiView<SplashScreenViewController, SplashLoadGameScreenView>(splashLoadGame, null);
        }
    }
}