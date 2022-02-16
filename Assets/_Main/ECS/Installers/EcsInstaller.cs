using ECS.Game.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Installers
{
    public class EcsInstaller : MonoInstaller
    {
        [SerializeField] private SceneData _sceneData;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneData>().FromInstance(_sceneData).AsSingle();

            BindStages();
            BindSystems();
            
            Container.BindInterfacesTo<EcsMainBootstrap>().AsSingle();
        }

        private void BindStages()
        {
            Container.BindInterfacesAndSelfTo<GameStartStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelCompletedStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartGameStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuShopStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuStageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadNextLevelStageSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameStageUpdateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameStageService>().AsSingle().NonLazy();
         
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<GameContext>().AsSingle();

            
            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveGameDataSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroySystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<RemapOnAddSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverObserverSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitPlayerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TestGameSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<StickInputSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIUpdateDataSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitBulletSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<DamageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TutorialManageSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerSideMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitGateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitRoadResourcesSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChoiceReactSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitObstacleSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitFinishSystem>().AsSingle();
        }       
    }
}