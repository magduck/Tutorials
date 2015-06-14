using System.Collections.Generic;
using DomainModel.Infrastructure;

namespace DomainModel.SQL
{
    public class SqlDataCache: IDataCache
    {
        private readonly Dictionary<string, object> _data;

        public SqlDataCache()
        {
            _data = new Dictionary<string, object>();
        }

        public void AddDataToCache(string key, object data)
        {
            if (IsCached(key) == false)
            {
                _data.Add(key, data);
            }
        }

        public bool IsCached(string key)
        {
            return (_data.ContainsKey(key));
        }

        public void DeleteDataFromCache(string key)
        {
            _data.Remove(key);
        }

        public object GetDataFromCache(string key)
        {
            object value;
            _data.TryGetValue(key, out value);
            return value;
        }
    }
}
