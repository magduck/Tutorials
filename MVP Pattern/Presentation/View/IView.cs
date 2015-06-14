using System;
using System.Collections.Generic;
using System.ComponentModel;
using DomainModel.Infrastructure;

namespace Presentation.View
{
    public delegate void DebugArgs(string message);
    public delegate void ErrorArgs(Exception e);

    public interface IView: INotifyPropertyChanged
    {
        FilterParams CurrentDataFilter { get; set; }

        int OnePageRowsCount { get; set; }
        int CurrentPageNumber { get; set; }
        int TotalPagesCount { get; set; }

        void CheckPageParameters(int value);

        IEnumerable<string> FilterCountriesList { get; set; }
        IEnumerable<string> FilterCitiesList { get; set; }
        IEnumerable<Company> CompaniesList { get; set; }

        event EventHandler OnDataLoading;
        event EventHandler OnDataFiltering;
        event EventHandler OnCountryFilterSelected;
        event EventHandler OnNextPage;
        event EventHandler OnPrevPage;
        event EventHandler OnLastPage;
        event EventHandler OnFirstPage;
        event ErrorArgs OnError;
        event DebugArgs OnDebug;

        void RaiseDataLoading();
        void RaiseDataFiltering();
        void RaiseCountryFilterSelected();
        void RaiseNextPage();
        void RaisePrevPage();
        void RaiseLastPage();
        void RaiseFirstPage();
        void Debug(string message);
        void Error(Exception e);
    }
}
