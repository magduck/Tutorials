using System;
using DomainModel.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace DomainModel.SQL
{
    public class AdoDataRepository : IDataRepository
    {
        private readonly DataContext _dataContext;
        private readonly IDataCache _cache;

        public AdoDataRepository(string connectionString, IDataCache cache = null)
        {
            _dataContext = new DataContext(connectionString);
            _cache = cache;
        }

        public event ErrorArgs OnError;

        public void RaiseError(Exception e)
        {
            if (OnError != null)
            {
                OnError(e);
            }
            else throw e;
        }

        public object GetDataFromCache(string key)
        {
            return (_cache != null) 
                ? _cache.GetDataFromCache(key)
                : null;
        }

        private void OpenConnection()
        {
            try
            {
                if (_dataContext.Connection.State != ConnectionState.Open)
                    _dataContext.Connection.Open();
            }
            catch
            {
                RaiseError(new Exception(String.Format("Error while connecting to DB. Connection string is \"{0}\" ", _dataContext.Connection.ConnectionString)));
            }    
        }

        public IEnumerable<string> GetCountries()
        {
            OpenConnection();

            const string cacheKey = "countries";
            var countries = GetDataFromCache(cacheKey) ??
                 _dataContext.ExecuteQuery<string>
                    (
                        "SELECT DISTINCT Country FROM dbo.Customers ORDER BY Country"
                    ).ToList();

            if (_cache != null)
            {
                _cache.AddDataToCache(cacheKey, countries);
            }

            return (IEnumerable<string>)countries;
        }

        public IEnumerable<string> GetCities(string countryName)
        {
            string cacheKey = String.Format("cities: country={0}", countryName);
            var cities = GetDataFromCache(cacheKey);
            if (cities != null)
                return (IEnumerable<string>) cities;

            OpenConnection();
       
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT DISTINCT City FROM dbo.Customers");
            sb.Append(" WHERE (Country = {0} OR {0} = '')");
            sb.Append(" ORDER BY City");
            cities = _dataContext.ExecuteQuery<string>(sb.ToString(), countryName).ToList();
            if (_cache != null)
            {
                _cache.AddDataToCache(cacheKey, cities);
            }

            return (IEnumerable<string>)cities;
        }

        public IEnumerable<T> GetCompanies<T>(string countryName = "", string cityName = "", string partOfCompanyName = "")
        {
            string cacheKey = String.Format("companies: country={0}, cityName={1}, partOfCompanyName={2}", countryName, cityName, partOfCompanyName);
            var companies = GetDataFromCache(cacheKey);
            if (companies != null)
                return ((IEnumerable<T>)companies);

            OpenConnection();

            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT DISTINCT Country, City, CompanyName FROM dbo.Customers");
            sb.Append(" WHERE 1 = 1");
            sb.Append(" AND (Country = {0} OR {0} = '')");
            sb.Append(" AND (City = {1} OR {1} = '')");
            sb.Append(" AND (CompanyName like '%' + {2} + '%')");
            sb.Append(" ORDER BY Country, City, CompanyName");

            companies = _dataContext.ExecuteQuery<T>(sb.ToString(), countryName, cityName, partOfCompanyName).ToList();
            if (_cache != null)
            {
                _cache.AddDataToCache(cacheKey, companies);
            }

            return (IEnumerable<T>)companies;
        }

    }
}
