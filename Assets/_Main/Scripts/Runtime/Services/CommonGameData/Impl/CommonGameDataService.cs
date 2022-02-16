using PdUtils.Dao;

namespace Runtime.Services.CommonPlayerData.Impl
{
    public class CommonGameDataService : ICommonGameDataService<Data.CommonGameData>
    {
        private readonly IDao<Data.CommonGameData> _dao;
        private Data.CommonGameData _cachedData;

        public CommonGameDataService(IDao<Data.CommonGameData> dao)
        {
            _dao = dao;
        }
        public Data.CommonGameData GetData() => _cachedData ??= _dao.Load() ?? new Data.CommonGameData();

        public void Save(Data.CommonGameData value)
        {
            _cachedData = value;
            _dao.Save(value);
        }

        public void Remove()
        {
            _cachedData = null;
            _dao.Remove();
        }

        public void Cache(Data.CommonGameData value)
        {
            _cachedData = value;
        }
    }
}