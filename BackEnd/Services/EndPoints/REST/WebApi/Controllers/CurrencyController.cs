using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.DTO.Convert;
using ServiceModel.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private ICurrencyService Service { get; set; }

        public CurrencyController(ICurrencyService service)
        {
            Service = service;
        }

        [HttpGet]
        async public Task<ActionResult<ConvertResponse>> ListCurrencies()
        {
            var result = await Service.List();

            return StatusCode(200, result);
        }

        [HttpGet("convert")]
        async public Task<ActionResult<ConvertResponse>> Convert([FromQuery] string from, [FromQuery] string to, [FromQuery] decimal amount)
        {
            var result = await Service.Convert(from, to, amount);

            return StatusCode(200, result);
        }
    }
}