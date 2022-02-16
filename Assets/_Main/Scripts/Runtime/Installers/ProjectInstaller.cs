using _Main.Scripts.Runtime.Services;
using ECS.Game.Systems;
using Facebook.Unity;
using Game.SceneLoading;
using Game.Ui.BlackScreen;
using Game.Utils;
using GameAnalyticsSDK;
using PdUtils;
using PdUtils.Dao;
using PdUtils.PlayerPrefs;
using PdUtils.PlayerPrefs.Impl;
using Runtime.Services.CommonPlayerData;
using Runtime.Services.PlayerSettings;
using Runtime.Services.SceneLoading.Impls;
using UniRx;
using Utils.SeparateThreadExecutor.Impl;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MainThreadDispatcher.Initialize();
            SignalBusInstaller.Install(Container);
            CommonGameDataInstaller.InstallServices(Container);
            
            FB.Init();
            GameAnalytics.Initialize();
            
            Container.BindInterfacesTo<DefaultSeparateThreadExecutor<string>>().AsSingle();
            Container.BindInterfacesTo<DefaultSeparateThreadExecutor>().AsSingle();
            Container.BindInterfacesTo<DefaultSeparateThreadExecutor<DataPool>>().AsSingle();

            Container.BindSubstituteInterfacesTo<ISceneLoadingManager, SceneLoadingManager>().AsSingle();
            Container.BindFromSubstitute<IPlayerPrefsManager, PersistancePlayerPrefsManager>().AsSingle();
            Container.BindInterfacesTo<PdAudioInitializer>().AsSingle().NonLazy();

            Container.BindInterfacesTo<LocalStorageDao<PlayerSettings>>()
                .AsTransient().WithArguments("playerSettings");

            Container.BindInterfacesAndSelfTo<VibrationService>().AsSingle();

            BindWindows();
        }
        
        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<BlackScreenWindow>().AsSingle();
        }
    }
}