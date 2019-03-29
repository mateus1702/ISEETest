using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.DTO.Convert
{
    public class ConvertResponse
    {
        public string From { get; set; }

        public string To { get; set; }

        public decimal Amount { get; set; }

        public decimal Result { get; set; }
    }
}
