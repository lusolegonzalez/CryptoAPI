using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoAPI.Models
{
    public class CryptoCurrency
    {
        [JsonPropertyName("data")]
        public Dictionary<string, CurrencyData> Data { get; set; }
    }
}
