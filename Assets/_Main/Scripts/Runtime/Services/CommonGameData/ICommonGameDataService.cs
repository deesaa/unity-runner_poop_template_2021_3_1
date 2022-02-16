namespace Runtime.Services.CommonPlayerData
{
    public interface ICommonGameDataService<T>
    {
        T GetData();
        void Save(T value);
        void Remove();
        void Cache(T value);
    }
}