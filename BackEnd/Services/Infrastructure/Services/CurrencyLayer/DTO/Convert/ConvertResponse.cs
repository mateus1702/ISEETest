using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyLayerService.DTO.Convert
{
    public class ConvertResponse : BaseResponse
    {
        public QueryDTO Query { get; set; }

        public InfoDTO Info { get; set; }

        public decimal Result { get; set; }

        public class QueryDTO
        {
            public string From { get; set; }

            public string To { get; set; }

            public decimal Amount { get; set; }
        }

        public class InfoDTO
        {
            public long Timestamp { get; set; }

            public decimal Quote { get; set; }

        }
    }
}
