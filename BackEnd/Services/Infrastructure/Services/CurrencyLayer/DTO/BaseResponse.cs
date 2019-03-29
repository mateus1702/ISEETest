using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyLayerService.DTO
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public string Terms { get; set; }

        public string Privacy { get; set; }

        public ErrorDTO Error { get; set; }

        public class ErrorDTO
        {
            public string Code { get; set; }

            public string Info { get; set; }
        }
    }
}
