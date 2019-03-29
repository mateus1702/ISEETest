using CurrencyConverterService.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterService.Services
{
    public class StubCurrencyConverterService : ICurrencyConverterService
    {
        async Task<CurrencyConversion> ICurrencyConverterService.Convert(string sourceCurrencyCode, string targetCurrencyCode, decimal amount)
        {
            if (sourceCurrencyCode == "USD" && targetCurrencyCode == "BRL")
            {
                return await Task.FromResult(new CurrencyConversion()
                {
                    SourceCurrencyCode = "USD",
                    TargetCurrencyCode = "BRL",
                    SourceValue = amount,
                    TargetValue = amount * 3.9085M
                });
            }
            else
            {
                throw new Exception("Can only convert from USD to BRL.");
            }

        }
    }
}
