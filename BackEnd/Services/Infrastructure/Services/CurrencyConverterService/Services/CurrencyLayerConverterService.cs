using CurrencyConverterService.Interfaces;
using CurrencyLayerService;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterService.Services
{
    public class CurrencyLayerConverterService : ICurrencyConverterService
    {
        private CurrencyLayerService.CurrencyLayerService Service { get; set; }

        public CurrencyLayerConverterService(CurrencyLayerServiceConfig config)
        {
            Service = new CurrencyLayerService.CurrencyLayerService(config);
        }

        async Task<CurrencyConversion> ICurrencyConverterService.Convert(string sourceCurrencyCode, string targetCurrencyCode, decimal amount)
        {
            var result = await Service.Convert(sourceCurrencyCode, targetCurrencyCode, amount);

            return new CurrencyConversion()
            {
                SourceCurrencyCode = result.From,
                TargetCurrencyCode = result.To,
                SourceValue = result.Amount,
                TargetValue = result.Result
            };
        }
    }
}
