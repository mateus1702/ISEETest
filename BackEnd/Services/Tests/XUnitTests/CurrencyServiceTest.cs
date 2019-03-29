using CurrencyConverterService.Services;
using RepositoryModel.Repositories;
using ServiceModel.Interfaces;
using ServiceModel.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTests
{
    public class CurrencyServiceTest
    {
        ICurrencyService Service { get; set; }

        public CurrencyServiceTest()
        {
            var currencyRepository = new FakeCurrencyRepository();
            var currencyConverterService = new StubCurrencyConverterService();
            Service = new CurrencyService(currencyRepository, currencyConverterService);
        }

        [Fact]
        public async void List()
        {
            var response = await Service.List();

            var currencies = response.Currencies;

            Assert.Contains(response.Currencies, x => x.Code == "USD");

            Assert.Contains(response.Currencies, x => x.Code == "BRL");
        }

        [Fact]
        public async void Convert()
        {
            var response = await Service.Convert("USD", "BRL", 1.5M);

            var currencies = response.Result;

            Assert.Equal(5.86275M, response.Result);
        }
    }
}
