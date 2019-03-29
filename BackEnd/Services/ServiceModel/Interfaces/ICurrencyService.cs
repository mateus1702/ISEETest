using DomainModel;
using ServiceModel.DTO.Convert;
using ServiceModel.DTO.List;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Interfaces
{
    public interface ICurrencyService
    {
        Task<ListResponse> List();

        Task<ConvertResponse> Convert(string sourceCurrencyCode, string targetCurrencyCode, decimal amount);
    }
}
