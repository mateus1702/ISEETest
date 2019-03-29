using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyLayerService.DTO.List
{
    public class ListResponse : BaseResponse
    {
        public Dictionary<string,string> Currencies { get; set; }
    }
}
