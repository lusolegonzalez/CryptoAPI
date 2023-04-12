using System;
using System.Text.Json.Serialization;

namespace CryptoAPI.Models
{
    public class QuoteData
    {
        [JsonPropertyName("price")]
        public float Price { get; set; }
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
