using CurrencyLayerService.DTO.List;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CurrencyLayerService.DTO.Convert;
using CurrencyLayerService.DTO;

namespace CurrencyLayerService
{
    public class CurrencyLayerService
    {
        private CurrencyLayerServiceConfig Config { get; set; }

        public CurrencyLayerService(CurrencyLayerServiceConfig config)
        {
            Config = config;
        }

        async public Task<Dictionary<string, string>> List()
        {
            var client = new RestClient($"{Config.BaseUrl}");

            var request = new RestRequest("api/list", Method.GET);

            request.AddParameter("access_key", $"{Config.AccessKey}");

            var restResponse = await client.ExecuteTaskAsync<ListResponse>(request);

            var response = restResponse.Data;

            if (!response.Success)
                throw new Exception($"The request to currency layer service was not successful - api/list - {response.Error?.Code} / {response.Error?.Info}");

            return response.Currencies;
        }

        async public Task<CurrencyConversion> Convert(string sourceCurrencyCode, string targetCurrencyCode, decimal amount)
        {
            var client = new RestClient($"{Config.BaseUrl}");

            var request = new RestRequest("api/convert", Method.GET);

            request.AddParameter("access_key", $"{Config.AccessKey}");
            request.AddParameter("from", sourceCurrencyCode);
            request.AddParameter("to", targetCurrencyCode);
            request.AddParameter("format", "1");
            request.AddParameter("amount", amount.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture));

            var restResponse = await client.ExecuteTaskAsync<ConvertResponse>(request);

            var response = restResponse.Data;

            if (!response.Success)
                throw new Exception($"The request to currency layer service was not successful - api/convert - {response.Error?.Code} / {response.Error?.Info}");

            return new CurrencyConversion()
            {
                From = response.Query.From,
                To = response.Query.To,
                Amount = response.Query.Amount,
                Result = response.Result
            };
        }
    }
}
