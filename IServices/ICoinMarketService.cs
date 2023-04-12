using CryptoAPI.Models;
using System.Threading.Tasks;

namespace CryptoAPI.IServices
{
    public interface ICoinMarketService
    {
        Task<CryptoCurrency> GetQuotes();
        Task<CryptoCurrency> GetExchange(string currency, string currencyToExchange);
    }

}
