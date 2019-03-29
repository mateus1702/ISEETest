using DomainModel;
using RepositoryModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModel.Repositories
{
    public class FakeCurrencyRepository : ICurrencyRepository
    {
        async Task<IEnumerable<Currency>> ICurrencyRepository.List()
        {
            return await Task.FromResult(new List<Currency>()
                {
                    new Currency()
                    {
                        Code = "BRL",
                        Name = "Brazilian Real"
                    },
                    new Currency()
                    {
                        Code = "USD",
                        Name = "United States Dollar"
                    }
                });
        }
    }
}
