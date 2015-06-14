using System;
using System.Collections.Generic;
using System.ComponentModel;
using DomainModel.Infrastructure;

namespace Presentation.View
{
    public class View : IView
    {
        #region IView Members

        public FilterParams CurrentDataFilter { get; set; }

        private int _onePageRowsCount;
        public int OnePageRowsCount
        {
            get { return _onePageRowsCount; }
            set
            {
                CheckPageParameters(value);
                _onePageRowsCount = value;
                Debug(string.Format("{0} rows in one page", _onePageRowsCount));
            }
        }

        private int _currentPageNumber;
        public int CurrentPageNumber
        {
            get { return _currentPageNumber; }
            set
            {
                CheckPageParameters(value);
                _currentPageNumber = value;
                Debug("Current page is " + value + " now");
                NotifyPropertyChanged("CurrentPageNumber");
            }
        }

        private int _totalPagesCount;
        public int TotalPagesCount
        {
            get { return _totalPagesCount; }
            set
            {
                CheckPageParameters(value);
                _totalPagesCount = value;
                Debug("Total pages is " + value + " now");
                NotifyPropertyChanged("TotalPagesCount");
            }
        }

        private List<string> _filterCountriesList;
        public IEnumerable<string> FilterCountriesList
        {
            get { return _filterCountriesList; }
            set
            {
                _filterCountriesList = new List<string>();
                _filterCountriesList.Add(string.Empty);
                _filterCountriesList.AddRange(value);
                NotifyPropertyChanged("FilterCountriesList");
            }
        }

        private List<string> _filterCitiesList;
        public IEnumerable<string> FilterCitiesList
        {
            get { return _filterCitiesList; }
            set
            {
                _filterCitiesList = new List<string>();
                _filterCitiesList.Add(string.Empty);
                _filterCitiesList.AddRange(value);
                NotifyPropertyChanged("FilterCitiesList");
            }
        }

        private List<Company> _companiesList;
        public IEnumerable<Company> CompaniesList
        {
            get { return _companiesList; }
            set
            {
                _companiesList = (List<Company>) value;
                NotifyPropertyChanged("CompaniesList");
            }
        }

        public void CheckPageParameters(int value)
        {
            if (value <= 0)
            {
                Error(new ArgumentException("Each page parameter must be greather than 0!"));
            }
        }

        #endregion

        #region IView events

        public event EventHandler OnDataLoading;
        public event EventHandler OnDataFiltering;
        public event EventHandler OnCountryFilterSelected;
        public event EventHandler OnNextPage;
        public event EventHandler OnPrevPage;
        public event EventHandler OnLastPage;
        public event EventHandler OnFirstPage;
        public event ErrorArgs OnError;
        public event DebugArgs OnDebug;

        public void RaiseDataLoading()
        {
            if (OnDataLoading != null)
            {
                OnDataLoading(this, EventArgs.Empty);
            }
        }

        public void RaiseDataFiltering()
        {
            if (OnDataFiltering != null)
            {
                OnDataFiltering(this, EventArgs.Empty);
            }
        }

        public void RaiseCountryFilterSelected()
        {
            if (OnCountryFilterSelected != null)
            {
                OnCountryFilterSelected(this, EventArgs.Empty);
            }
        }

        public void RaiseNextPage()
        {
            if (OnNextPage != null)
            {
                OnNextPage(this, EventArgs.Empty);
            }
        }

        public void RaisePrevPage()
        {
            if (OnPrevPage != null)
            {
                OnPrevPage(this, EventArgs.Empty);
            }
        }

        public void RaiseLastPage()
        {
            if (OnLastPage != null)
            {
                OnLastPage(this, EventArgs.Empty);
            }
        }

        public void RaiseFirstPage()
        {
            if (OnFirstPage != null)
            {
                OnFirstPage(this, EventArgs.Empty);
            }
        }

        public void Debug(string message)
        {
            if (OnDebug != null)
            {
                OnDebug(message);
            }
        }

        public void Error(Exception e)
        {
            if (OnError != null)
            {
                OnError(e);
            }
            else throw e;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

    }
}
