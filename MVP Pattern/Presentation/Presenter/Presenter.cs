using System;
using System.Collections.Generic;
using System.Linq;
using Presentation.View;
using DomainModel.Infrastructure;

namespace Presentation.Presenter
{
    public class Presenter
    {
        #region Init 

        private readonly IView _view;
        private readonly IDataRepository _model;

        public Presenter(IView view, IDataRepository model)
        {
            if (view == null)
                throw new NullReferenceException("View is a null reference!");
            if (model == null)
                view.Error(new Exception("Model is a null reference!"));

            _view = view;
            _model = model;

            _view.CurrentDataFilter = new FilterParams();
            _view.CompaniesList = new List<Company>();
            _view.FilterCitiesList = new List<string>();
            _view.FilterCountriesList = new List<string>();

            SubscribeToViewEvents();
            SubscribeToModelEvents();
        }

        private void SubscribeToModelEvents()
        {
            _model.OnError += _view.Error;
        }

        private void SubscribeToViewEvents()
        {
            _view.OnDataLoading += LoadData;
            _view.OnDataFiltering += FilterData;
            _view.OnCountryFilterSelected += CountryFilterSelected;
            _view.OnFirstPage += FirstPage;
            _view.OnLastPage += LastPage;
            _view.OnNextPage += NextPage;
            _view.OnPrevPage += PrevPage;
        }

        #endregion

        #region Paging

        private void PrevPage(object sender, EventArgs e)
        {
            if (_view.CurrentPageNumber > 1)
            {
                _view.CurrentPageNumber -= 1;
                RefreshCompaniesList();
            }
        }

        private void NextPage(object sender, EventArgs e)
        {
            if (_view.CurrentPageNumber < _view.TotalPagesCount)
            {
                _view.CurrentPageNumber += 1;
                RefreshCompaniesList();
            }
        }

        private void LastPage(object sender, EventArgs e)
        {
            if (_view.CurrentPageNumber < _view.TotalPagesCount)
            {
                _view.CurrentPageNumber = _view.TotalPagesCount;
                RefreshCompaniesList();
            }
        }

        private void FirstPage(object sender, EventArgs e)
        {
            if (_view.CurrentPageNumber > 1)
            {
                _view.CurrentPageNumber = 1;
                RefreshCompaniesList();
            }
        }

        #endregion

        #region View Events

        private void CountryFilterSelected(object sender, EventArgs e)
        {
            RefreshCitiesList();
        }

        private void FilterData(object sender, EventArgs e)
        {
            _view.Debug("Filtering data...");
            _view.CurrentPageNumber = 1;
            CalcTotalPagesCount();
            RefreshCompaniesList();    
            _view.Debug("Filtering is completed");
        }

        private void LoadData(object sender, EventArgs e)
        {
            _view.Debug("Loading data...");
            SetDefaultFilterValue();
            RefreshCountiesList();
            RefreshCitiesList();
            RefreshCompaniesList();
            CalcTotalPagesCount();
            SetFirstPageAsCurrentPage();
            _view.Debug("Loading data is completed");
        }

        #endregion

        #region Refresh data in a view represantation

        private void SetDefaultFilterValue()
        {
            _view.Debug("Set default filter values");
            _view.CurrentDataFilter.CityName = "";
            _view.CurrentDataFilter.CompanyName = "";
            _view.CurrentDataFilter.CountryName = "";
        }

        private void CalcTotalPagesCount()
        {
            _view.Debug("Calulating total pages count");
            int rowsCount = _model.GetCompanies<Company>(
                _view.CurrentDataFilter.CountryName,
                _view.CurrentDataFilter.CityName,
                _view.CurrentDataFilter.CompanyName
                ).Count();
            if (_view.OnePageRowsCount > 0)
            {
                int pagesCount = rowsCount/_view.OnePageRowsCount;
                pagesCount += ((rowsCount%_view.OnePageRowsCount) > 0) ? 1 : 0;
                _view.TotalPagesCount = (pagesCount == 0) ? 1 : pagesCount;
            }
            else
                _view.TotalPagesCount = 0;
        }

        private void SetFirstPageAsCurrentPage()
        {
            _view.Debug("Set first page as a current page");
            _view.CurrentPageNumber = 1;
        }

        private void RefreshCompaniesList()
        {
            _view.Debug(String.Format("Refresh companies list for {0} page of {1} pages", _view.CurrentPageNumber, _view.TotalPagesCount));
            _view.CompaniesList = _model.GetCompanies<Company>(
                _view.CurrentDataFilter.CountryName,
                _view.CurrentDataFilter.CityName,
                _view.CurrentDataFilter.CompanyName
                )
                .Skip(_view.OnePageRowsCount * (_view.CurrentPageNumber - 1))
                .Take(_view.OnePageRowsCount).ToList();
        }

        private void RefreshCitiesList()
        {
            _view.Debug("Refresh cities list");
            _view.FilterCitiesList = _model.GetCities(_view.CurrentDataFilter.CountryName);
        }

        private void RefreshCountiesList()
        {
            _view.Debug("Refresh countries list");
            _view.FilterCountriesList = _model.GetCountries();
        }

        #endregion
    }
}
