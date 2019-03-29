using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.DTO.List
{
    public class ListResponse
    {
        public IEnumerable<Currency> Currencies { get; set; }
    }
}
