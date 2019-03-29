using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModel.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> List();
    }
}
