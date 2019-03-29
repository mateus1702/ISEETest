using CurrencyConverterService.Interfaces;
using DomainModel;
using RepositoryModel.Interfaces;
using RestSharp;
using ServiceModel.DTO.Convert;
using ServiceModel.DTO.List;
using ServiceModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Services
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyRepository CurrencyRepository { get; set; }

        private ICurrencyConverterService CurrencyConverterService { get; set; }

        public CurrencyService(ICurrencyRepository currencyRepository , ICurrencyConverterService currencyConverterService)
        {
            CurrencyRepository = currencyRepository;
            CurrencyConverterService = currencyConverterService;
        }

        async Task<ConvertResponse> ICurrencyService.Convert(string sourceCurrencyCode, string targetCurrencyCode, decimal amount)
        {
            var result = await CurrencyConverterService.Convert(sourceCurrencyCode, targetCurrencyCode, amount);

            return new ConvertResponse()
            {
                From = result.SourceCurrencyCode,
                To = result.TargetCurrencyCode,
                Amount = result.SourceValue,
                Result = result.TargetValue
            };
        }

        async Task<ListResponse> ICurrencyService.List()
        {
            var result = await CurrencyRepository.List();

            return new ListResponse()
            {
                Currencies = result.Select(c => new DTO.Currency()
                {
                    Code = c.Code,
                    Name = c.Name
                })
            };
        }
    }
}
