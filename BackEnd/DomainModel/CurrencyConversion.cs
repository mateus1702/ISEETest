using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class CurrencyConversion
    {
        public string SourceCurrencyCode { get; set; }

        public string TargetCurrencyCode { get; set; }

        public decimal SourceValue { get; set; }

        public decimal TargetValue { get; set; }
    }
}
