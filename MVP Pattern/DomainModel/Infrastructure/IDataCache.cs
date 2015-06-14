namespace DomainModel.Infrastructure
{
    public interface IDataCache
    {
        void AddDataToCache(string key, object data);
        bool IsCached(string key);
        void DeleteDataFromCache(string key);
        object GetDataFromCache(string key);
    }
}
