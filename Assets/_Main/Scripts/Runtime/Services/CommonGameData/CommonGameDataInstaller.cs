using PdUtils.Dao;
using Runtime.Services.CommonPlayerData.Impl;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Runtime.Services.CommonPlayerData
{
    public static class CommonGameDataInstaller
    {
        public static void InstallServices(DiContainer container)
        {
            InstallDao(container);
            container.BindSubstituteInterfacesTo<ICommonGameDataService<Data.CommonGameData>, CommonGameDataService>().AsSingle();
        }

        private static void InstallDao(DiContainer container)
        {
            container.BindInterfacesTo<LocalStorageDao<Data.CommonGameData>>().AsTransient().WithArguments("commonPlayerData");
        }
    }
}