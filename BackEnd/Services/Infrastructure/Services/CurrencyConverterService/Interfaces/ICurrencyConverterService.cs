using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterService.Interfaces
{
    public interface ICurrencyConverterService
    {
        Task<CurrencyConversion> Convert(string sourceCurrencyCode, string targetCurrencyCode, decimal amount);
    }
}
