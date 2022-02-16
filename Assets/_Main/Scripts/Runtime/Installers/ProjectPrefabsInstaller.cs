using DataBase.Objects;
using DataBase.Objects.Impl;
using Runtime.DataBase.General.GameCFG;
using Runtime.DataBase.General.GameCFG.Impl;
using UnityEditor;
using UnityEngine;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Runtime.Installers
{
    [CreateAssetMenu(menuName = "Installers/ProjectPrefabsInstaller", fileName = "ProjectPrefabsInstaller")]
    public class ProjectPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PrefabsBase prefabBase;
        [SerializeField] private ShopItemsBase shopItemsBase;
        [SerializeField] private FinishTextDatabase finishTextDatabase;
        [SerializeField] private GameConfig gameConfig;

        public override void InstallBindings()
        {
            Debug.Log("InstallBindings");
            Container.Bind<IPrefabsBase>().FromSubstitute(prefabBase).AsSingle();
            Container.Bind<IGameConfig>().FromSubstitute(gameConfig).AsSingle();

            shopItemsBase.Initialize();
            Container.Bind<IShopItemsBase>().FromSubstitute(shopItemsBase).AsSingle();
            Container.Bind<IFinishTextDatabase>().FromSubstitute(finishTextDatabase).AsSingle();

        }
#if UNITY_EDITOR
        [MenuItem("Assets/Bases/Project bases", false, 1000000)]
        public static void SelectBases()
        {
            Selection.activeObject = Resources.Load("Settings/Installers/ProjectPrefabsInstaller");
        }
        [MenuItem("Assets/Bases/Graph bases", false, 1000000)]
        public static void SelectGraphBases()
        {
            Selection.activeObject = Resources.Load("Settings/Bases/GameActionsGraphBase");
        }
        [MenuItem("Assets/Bases/Game actions bases", false, 1000000)]
        public static void SelectGameActionsBases()
        {
            Selection.activeObject = Resources.Load("Settings/Bases/MainGameActionsBase");
        }
        [MenuItem("Assets/Bases/Heroes base", false, 1000000)]
        public static void SelectHeroesBase()
        {
            Selection.activeObject = Resources.Load("Settings/Bases/HeroBase");
        }
#endif        
    }
}