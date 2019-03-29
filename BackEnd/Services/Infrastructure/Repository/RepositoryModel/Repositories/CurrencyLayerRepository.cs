using CurrencyLayerService;
using DomainModel;
using RepositoryModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModel.Repositories
{
    public class CurrencyLayerRepository : ICurrencyRepository
    {
        private CurrencyLayerService.CurrencyLayerService Service { get; set; }

        public CurrencyLayerRepository(CurrencyLayerServiceConfig config)
        {
            Service = new CurrencyLayerService.CurrencyLayerService(config);
        }

        async Task<IEnumerable<Currency>> ICurrencyRepository.List()
        {
            var result = await Service.List();

            return result.Select(c => new Currency()
            {
                Code = c.Key,
                Name = c.Value
            });
        }
    }
}
