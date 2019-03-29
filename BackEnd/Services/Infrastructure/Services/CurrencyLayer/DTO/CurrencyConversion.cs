using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyLayerService.DTO
{
    public class CurrencyConversion
    {
        public string From { get; set; }

        public string To { get; set; }

        public decimal Amount { get; set; }

        public decimal Result { get; set; }
    }
}
