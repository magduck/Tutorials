using System;
using System.Windows.Forms;
using Presentation.View;

namespace UI
{
    public partial class MainForm : Form
    {
        #region Init

        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IView _view;

        public MainForm(IView view)
        {
            InitializeComponent();

            if (view == null)
            {
                Error(new NullReferenceException("View can not be null reference!"));
            }
            _view = view;
            _view.OnError += Error;
            _view.OnDebug += Debug;
            _view.PropertyChanged += ViewPropertyChanged;
        }

        private void ViewPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug(String.Format("Property {0} has changed", e.PropertyName));
            switch(e.PropertyName)
            {
                case "FilterCountriesList":
                    CountryNameBox.DataSource = _view.FilterCountriesList;
                    _view.CurrentDataFilter.CountryName = CountryNameBox.Text;
                    break;
                case "FilterCitiesList":
                    CityNameBox.DataSource = _view.FilterCitiesList;
                    _view.CurrentDataFilter.CityName = CityNameBox.Text;
                    break;
                case "CompaniesList":
                    CompaniesGrid.Rows.Clear();
                    foreach (var company in _view.CompaniesList)
                    {
                        CompaniesGrid.Rows.Add(new string[]
                        {
                            company.Country,
                            company.City,
                            company.CompanyName
                        });
                    }
                    break;
                case "CurrentPageNumber": case "TotalPagesCount":
                    PageLabel.Text = String.Format("{0} of {1}", _view.CurrentPageNumber, _view.TotalPagesCount);
                    break;
            }
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(Exception e)
        {
            _logger.Error(e.Message);
            throw e; 
        }

        #endregion  

        #region Form's Events

        private void CountryNameBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Debug(String.Format("Filter country name has selected as {0}", CountryNameBox.Text));
            _view.CurrentDataFilter.CountryName = CountryNameBox.Text;
            _view.RaiseCountryFilterSelected();
        }

        private void CityNameBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Debug(String.Format("Filter city name has selected as {0}", CityNameBox.Text));
            _view.CurrentDataFilter.CityName = CityNameBox.Text;
        }

        private void CompanyNameText_TextChanged(object sender, EventArgs e)
        {
            Debug(String.Format("Filter company name has selected as \"{0}\"", CompanyNameText.Text));
            _view.CurrentDataFilter.CompanyName = CompanyNameText.Text;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            _view.RaiseDataFiltering();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Debug("The form is shown!");
            _view.RaiseDataLoading();
        }

        #endregion

        #region Paging 

        private void FirstBtn_Click(object sender, EventArgs e)
        {
            Debug("First page button is clicked");
            _view.RaiseFirstPage();
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            Debug("Previous page button is clicked");
            _view.RaisePrevPage();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            Debug("Next page button is clicked");
            _view.RaiseNextPage();
        }

        private void LastBtn_Click(object sender, EventArgs e)
        {
            Debug("Last page button is clicked");
            _view.RaiseLastPage();
        }

        private void SetTextValueForPageNumberInformation()
        {
            PageLabel.Text = _view.CurrentPageNumber + " of " + _view.TotalPagesCount;
        }

        #endregion

    }
}
