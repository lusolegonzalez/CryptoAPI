using CryptoAPI.IServices;
using CryptoAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public class CoinMarketService : ICoinMarketService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoinMarketService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<CryptoCurrency> GetQuotes()
        {
            HttpClient client = _httpClientFactory.CreateClient("CoinMarketHttpClient");
            string path = $"quotes/latest?symbol=btc,eth,bnb,usdt,ada";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<CryptoCurrency>(responseBody);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<CryptoCurrency> GetExchange(string currency, string currencyToExchange)
        {
            HttpClient client = _httpClientFactory.CreateClient("CoinMarketHttpClient");
            string path = $"quotes/latest?symbol={currency}&convert=";

            HttpResponseMessage response = await client.GetAsync(path + currencyToExchange);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<CryptoCurrency>(responseBody);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }
}
