using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoAPI.Models
{
    public class CurrencyData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("quote")]
        public Dictionary<string, QuoteData> Quote { get; set; }
    }
}
