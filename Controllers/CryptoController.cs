using CryptoAPI.IServices;
using CryptoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICoinMarketService _coinMarketService;

        public CryptoController(ICoinMarketService coinMarketService)
        {
            _coinMarketService = coinMarketService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CryptoResponse>>> GetAsync()
        {
            try
            {
                List<CryptoResponse> cr = new List<CryptoResponse>();

                CryptoCurrency currency = await this._coinMarketService.GetQuotes();

                foreach (var item in currency.Data.Values.ToList())
                {
                    cr.Add(new CryptoResponse
                    {
                        Name = item.Name,
                        Price = item.Quote.Values.ToList()[0].Price,
                        LastUpdated = item.Quote.Values.ToList()[0].LastUpdated
                    });
                }

                return cr;
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ExchangeResponse>>> PostAsync(ExchangeParams exchangeParams)
        {
            try
            {
                List<ExchangeResponse> er = new List<ExchangeResponse>();

                foreach (var currency in exchangeParams.CurrenciesToExchange)
                {

                    CryptoCurrency crypto = await _coinMarketService.GetExchange(exchangeParams.Currency, currency);

                    foreach (var item in crypto.Data.Values.ToList())
                    {
                        er.Add(new ExchangeResponse
                        {
                            Name = item.Quote.Keys.ToList()[0],
                            Price = item.Quote.Values.ToList()[0].Price * exchangeParams.Amount
                        });
                    }
                }
                return er;
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
