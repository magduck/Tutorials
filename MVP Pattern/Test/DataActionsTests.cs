using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Infrastructure;
using Moq;
using NUnit.Framework;
using Presentation.Presenter;
using Presentation.View;
using UI;

namespace Test
{
    [TestFixture]
    public class DataActionsTests
    {
        Mock<IDataRepository> repository;
        View view;
        Presenter presenter;

        [SetUp]
        public void Init()
        {
            repository = new Mock<IDataRepository>();
            view = new View();
            presenter = new Presenter(view, repository.Object);

            view.OnePageRowsCount = 2;

            repository.Setup(s => s.GetCountries()).Returns(new List<string>
            {
                "Russia",
                "USA",
                "Germany",
                "Brazil"
            });

            repository.Setup(c => c.GetCities(It.Is<string>(s => s == string.Empty))).Returns(new List<string>
            {
                "Moscow",
                "Krasnodar",
                "New York",
                "Los Angeles",
                "Berlin",
                "Brazilia"
            });

            repository.Setup(c => c.GetCompanies<Company>(string.Empty, string.Empty, string.Empty)).Returns(new List<Company>
            {
                new Company() {Country = "Russia", City = "Moscow", CompanyName = "Ozon"},
                new Company() {Country = "Russia", City = "Moscow", CompanyName = "Yandex"},
                new Company() {Country = "USA", City = "Los Angeles", CompanyName = "Google"}
            });

            repository.Setup(c => c.GetCities(It.Is<string>(s => s == "Russia"))).Returns(new List<string>
            {
                "Moscow",
                "Krasnodar"
            });

        }

        [Test]
        public void LoadDataFromRepositoryTest()
        {
            Assert.That(view.CurrentPageNumber, Is.EqualTo(0));
            Assert.That(view.TotalPagesCount, Is.EqualTo(0));
            Assert.That(view.FilterCountriesList.Count(), Is.EqualTo(1)); // empty one by default
            Assert.That(view.FilterCitiesList.Count(), Is.EqualTo(1)); // empty one by default
            Assert.That(view.CompaniesList.Count(), Is.EqualTo(0));

            view.RaiseDataLoading();

            Assert.That(view.CurrentPageNumber, Is.EqualTo(1));
            Assert.That(view.TotalPagesCount, Is.EqualTo(2));
            Assert.That(view.FilterCountriesList.Count(), Is.EqualTo(5));
            Assert.That(view.FilterCitiesList.Count(), Is.EqualTo(7));
            Assert.That(view.CompaniesList.Count(), Is.EqualTo(2));
        }

        [Test]
        public void PagingTest()
        {
            view.RaiseDataLoading();
            Assert.That(view.CompaniesList.Count(), Is.EqualTo(2));

            view.RaiseNextPage();
            Assert.That(view.CompaniesList.Count(), Is.EqualTo(1));

            view.RaisePrevPage();
            Assert.That(view.CompaniesList.Count(), Is.EqualTo(2));

            view.RaiseLastPage();
            Assert.That(view.CompaniesList.Count(), Is.EqualTo(1));

            view.RaiseFirstPage();
            Assert.That(view.CompaniesList.Count(), Is.EqualTo(2));
        }

        [Test]
        public void FilterCitiesListIfCountryChangedTest()
        {
            view.CurrentDataFilter.CountryName = "Russia";
            view.RaiseCountryFilterSelected();
            Assert.That(view.FilterCitiesList.Count(), Is.EqualTo(3));
        }

        [Test]
        public void ResetFilterForCitiesIfCountryNotSetUpTest()
        {
            view.CurrentDataFilter.CountryName = "";
            view.RaiseCountryFilterSelected();
            Assert.That(view.FilterCitiesList.Count(), Is.EqualTo(7));
        }

        [Test]
        public void OnePageRowsCountMustBeMoreThanZero()
        {
            Assert.Throws<ArgumentException>(() => view.CheckPageParameters(0));
            Assert.Throws<ArgumentException>(() => view.CheckPageParameters(-1));
        }
    }
}
