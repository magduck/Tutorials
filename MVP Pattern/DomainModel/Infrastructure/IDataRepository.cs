using System;
using System.Collections.Generic;

namespace DomainModel.Infrastructure
{
    public delegate void ErrorArgs(Exception e);

    public interface IDataRepository
    {
        IEnumerable<string> GetCountries();
        IEnumerable<string> GetCities(string countryName);
        IEnumerable<T> GetCompanies<T>(string countryName = "", string cityName = "", string partOfCompanyName = "");
        object GetDataFromCache(string key);

        event ErrorArgs OnError;
        void RaiseError(Exception e);
    }
}
